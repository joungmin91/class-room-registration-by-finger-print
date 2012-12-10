using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Database;
using System.Threading;

namespace ClassRoomRegistration
{
    public partial class TeachingViewFrm : Form
    {
        public string TechID { get; set; }
        public MySQLDatabase _db = null;
        public MySQLDatabase _db2 = null;
        private ContextMenu _contextMenu = null;
        private bool _allowUdateRow = false;
        private string _sqlShowAllSubject = "SELECT s.sub_id, s.sub_title, t.year FROM teaching t JOIN subject s ON t.sub_id = s.sub_id";
        private string _sqlShowAllRegister = "SELECT r.std_id, s.std_name, s.std_fp_key, r.reg_id FROM registration r JOIN student s ON r.std_id = s.std_id";
        private bool _bAlreadyRegis = false;

        public TeachingViewFrm()
        {
            InitializeComponent();
        }

        private void TeachingViewFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            _db = ((MainFrm)this.MdiParent)._db;

            _db2 = new MySQLDatabase();
            _db2.DBServer = _db.DBServer;
            _db2.DBUser = _db.DBUser;
            _db2.DBPassword = _db.DBPassword;
            _db2.DBName = _db.DBName;

            try
            {
                if (_db2.Connect() == false)
                {
                    MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Setup datagrid columns
            AddColumnForStudentDGV();

            // Setup datagrid columns
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubject.AllowUserToAddRows = false;
            dgvSubject.AllowUserToDeleteRows = false;
            dgvSubject.MultiSelect = false;
            dgvSubject.ReadOnly = true;
            dgvSubject.ColumnCount = 3;
            dgvSubject.Columns[0].HeaderText = "รหัสวิชา";
            dgvSubject.Columns[0].Width = 100;
            dgvSubject.Columns[1].HeaderText = "ชื่อวิชา";
            dgvSubject.Columns[1].Width = 450;
            dgvSubject.Columns[2].HeaderText = "ปีการศึกษา";
            dgvSubject.Columns[2].Width = 100;

            string sql = _sqlShowAllSubject + " WHERE t.tech_id='" + TechID + "'";
            LoadSubjectToDGV(sql);

            _allowUdateRow = true;
            dgvSubject_SelectionChanged(null, null);
            BuildContextualMenu();
        }

        void AddColumnForStudentDGV()
        {
            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudent.AllowUserToAddRows = false;
            dgvStudent.AllowUserToDeleteRows = false;
            dgvStudent.MultiSelect = false;
            dgvStudent.ReadOnly = true;
            if (_bAlreadyRegis == false)
            {
                dgvStudent.CellContentClick += new DataGridViewCellEventHandler(dgvStudent_CellContentClick);
                _bAlreadyRegis = true;
            }
            dgvStudent.ColumnCount = 0;
            dgvStudent.ColumnCount = 4;
            dgvStudent.Columns[0].HeaderText = "รหัสนิสิต";
            dgvStudent.Columns[0].Width = 100;
            dgvStudent.Columns[0].Frozen = true;
            dgvStudent.Columns[1].HeaderText = "ชื่อนิสิต";
            dgvStudent.Columns[1].Width = 200;
            dgvStudent.Columns[1].Frozen = true;
            dgvStudent.Columns[2].HeaderText = "สถานะ";
            dgvStudent.Columns[2].Visible = false;
            dgvStudent.Columns[3].HeaderText = "รหัสลงทะเบียน";
            dgvStudent.Columns[3].Visible = false;
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "ลายนิ้วมือ";
            imgCol.Width = 60;
            imgCol.Frozen = true;
            dgvStudent.Columns.Add(imgCol);
        }

        void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = dgvStudent.Columns.Count - 2;
            if (e.ColumnIndex == idx)
            {
                string subID = dgvSubject.CurrentRow.Cells[0].Value as string;
                string stdID = dgvStudent.CurrentRow.Cells[0].Value as string;
                string year = dgvSubject.CurrentRow.Cells[2].Value as string;
                string date = DateTime.Now.ToShortDateString();
                string value = dgvStudent.Rows[e.RowIndex].Cells[idx+1].Value as string;
                if (value == "uncheck")
                {
                    // if the record is not in database, just insert.
                    _db.SQLCommand = "SELECT * FROM checkin WHERE sub_id='" + subID + "' AND std_id='" + stdID + "' AND chkin_year='" + year + "' AND chkin_date='" + date + "'";
                    _db.Query();
                    if (_db.Result.HasRows == false)
                    {
                        _db.SQLCommand = "INSERT INTO checkin (sub_id, std_id, chkin_year, chkin_date) VALUES ('" + subID + "', '" + stdID + "', '" + year + "', '" + date + "')";
                        _db.Query();
                        dgvStudent.Rows[e.RowIndex].Cells[idx].Value = LoadImage("check.png");
                        dgvStudent.Rows[e.RowIndex].Cells[idx+1].Value = "check";
                    }
                }
                else
                {
                    // if the record is in database, just delete.
                    _db.SQLCommand = "DELETE FROM checkin WHERE sub_id='" + subID + "' AND std_id='" + stdID + "' AND chkin_year='" + year + "' AND chkin_date='" + date + "'";
                    _db.Query();
                    dgvStudent.Rows[e.RowIndex].Cells[idx].Value = LoadImage("uncheck.png");
                    dgvStudent.Rows[e.RowIndex].Cells[idx + 1].Value = "uncheck";
                }
            }
        }

        private void BuildContextualMenu()
        {
            // Create Contextual Menu
            _contextMenu = new ContextMenu();

            // Create MenuItem
            MenuItem scanFinger = new MenuItem("เก็บลายนิ้วมือนิสิตคนนี้");
            scanFinger.Click += new EventHandler(scanFinger_Click);
            _contextMenu.MenuItems.Add(scanFinger);

            MenuItem givePoint = new MenuItem("ให้คะแนนนิสิตคนนี้");
            givePoint.Click += new EventHandler(givePoint_Click);
            _contextMenu.MenuItems.Add(givePoint);

            MenuItem checkinStd = new MenuItem("เช็คชื่อนิสิตคนนี้");
            checkinStd.Click += new EventHandler(checkinStd_Click);
            _contextMenu.MenuItems.Add(checkinStd);
        }

        void checkinStd_Click(object sender, EventArgs e)
        {
            if (dgvStudent.CurrentRow == null && dgvSubject.CurrentRow == null)
            {
                return;
            }

            CheckinStdFrm frm = new CheckinStdFrm();
            frm.Parent = this;
            frm.SubID = (string)dgvSubject.CurrentRow.Cells[0].Value;
            frm.Year = (string)dgvSubject.CurrentRow.Cells[2].Value;
            frm.ShowDialog();

            dgvSubject_SelectionChanged(null, null);
        }

        void givePoint_Click(object sender, EventArgs e)
        {
            if (dgvStudent.CurrentRow == null)
            {
                return;
            }

            ScoreFrm frm = new ScoreFrm();
            frm.Parent = this;
            frm.RegisID = Convert.ToString(dgvStudent.CurrentRow.Cells[3].Value);
            frm.StdID = (string)dgvStudent.CurrentRow.Cells[0].Value;
            frm.StdName = (string)dgvStudent.CurrentRow.Cells[1].Value;
            frm.ShowDialog();
        }

        void scanFinger_Click(object sender, EventArgs e)
        {
            if (dgvStudent.CurrentRow == null)
            {
                return;
            }

            ScanFingerStdFrm frm = new ScanFingerStdFrm();
            frm.Parent = this;
            frm.StdID = (string)dgvStudent.CurrentRow.Cells[0].Value;
            frm.StdName = (string)dgvStudent.CurrentRow.Cells[1].Value;
            frm.ShowDialog();

            dgvSubject_SelectionChanged(null, null);
        }

        private void LoadSubjectToDGV(string sqlCmd)
        {
            // Clear DGV
            dgvSubject.Rows.Clear();
            // Query all teacher.
            _db.SQLCommand = sqlCmd;
            _db.Query();

            if (_db.Result.HasRows == false)
            {
                MessageBox.Show("ไม่มีรายการที่ต้องการแสดง", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                dgvSubject.Rows.Add(
                    _db.Result.GetValue(0),
                    _db.Result.GetValue(1),
                    _db.Result.GetValue(2)
                    );
            }
        }

        private void LoadRegisterToDGV(string sqlCmd)
        {
            AddColumnForStudentDGV();
            // Clear DGV
            dgvStudent.Rows.Clear();
            // Query all teacher.
            _db.SQLCommand = sqlCmd;
            _db.Query();

            if (_db.Result.HasRows == false)
            {
                MessageBox.Show("ไม่มีรายการที่ต้องการแสดง", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                if ((string)_db.Result.GetValue(2) != "")
                {
                    dgvStudent.Rows.Add(
                        _db.Result.GetValue(0),
                        _db.Result.GetValue(1),
                        "scaned",
                        _db.Result.GetValue(3),
                        LoadImage("finger2.png")
                        );
                }
                else
                {
                    dgvStudent.Rows.Add(
                        _db.Result.GetValue(0),
                        _db.Result.GetValue(1),
                        "noscan",
                        _db.Result.GetValue(3),
                        LoadImage("nofinger2.png")
                        );
                }
            }

            string subID = dgvSubject.CurrentRow.Cells[0].Value as string;
            string year = dgvSubject.CurrentRow.Cells[2].Value as string;
            string date = DateTime.Now.ToShortDateString();

            // Load others groups
            _db.SQLCommand = "SELECT chkin_date FROM checkin WHERE sub_id='" + subID + "' AND chkin_year='" + year + "' AND chkin_date<>'" + date + "' GROUP BY chkin_date";
            _db.Query();
            if (_db.Result.HasRows == true)
            {
                while (_db.Result.Read() == true)
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.HeaderText = _db.Result.GetValue(0) as string;
                    imgCol.Width = 70;
                    dgvStudent.Columns.Add(imgCol);
                }
            }

            // Get history status
            for (int i = 5; i < dgvStudent.Columns.Count; i++)
            {
                foreach (DataGridViewRow item in dgvStudent.Rows)
                {
                    string stdID = item.Cells[0].Value as string;
                    string hisDate = dgvStudent.Columns[i].HeaderText;

                    _db.SQLCommand = "SELECT * FROM checkin WHERE sub_id='" + subID + "' AND std_id='" + stdID + "' AND chkin_year='" + year + "' AND chkin_date='" + hisDate + "'";
                    _db.Query();

                    if (_db.Result.HasRows == true)
                    {
                        item.Cells[i].Value = LoadImage("check.png");
                    }
                    else
                    {
                        item.Cells[i].Value = LoadImage("uncheck.png");
                    }
                }
            }

            // Get today status
            DataGridViewImageColumn todayCol = new DataGridViewImageColumn();
            todayCol.HeaderText = DateTime.Now.ToShortDateString();
            todayCol.Width = 70;
            dgvStudent.Columns.Add(todayCol);

            DataGridViewTextBoxColumn todayStatusCol = new DataGridViewTextBoxColumn();
            todayStatusCol.HeaderText = "TodayStatus";
            todayStatusCol.Width = 70;
            todayStatusCol.Visible = false;
            dgvStudent.Columns.Add(todayStatusCol);

            int idx = dgvStudent.Columns.Count - 2;

            foreach (DataGridViewRow item in dgvStudent.Rows)
            {
                string stdID = item.Cells[0].Value as string;

                _db.SQLCommand = "SELECT * FROM checkin WHERE sub_id='" + subID + "' AND std_id='" + stdID + "' AND chkin_year='" + year + "' AND chkin_date='" + date + "'";
                _db.Query();

                if (_db.Result.HasRows == true)
                {
                    item.Cells[idx].Value = LoadImage("check.png");
                    item.Cells[idx+1].Value = "check";
                }
                else
                {
                    item.Cells[idx].Value = LoadImage("uncheck.png");
                    item.Cells[idx + 1].Value = "uncheck";
                }
            }
        }

        private Image LoadImage(string imageName)
        {
            Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\images\" + imageName);
            return img;
        }

        private void dgvSubject_SelectionChanged(object sender, EventArgs e)
        {
            if (_allowUdateRow == true)
	        {
		        string sql = _sqlShowAllRegister + " WHERE r.sub_id='" + (string)dgvSubject.CurrentRow.Cells[0].Value + "' AND r.year='" + (string)dgvSubject.CurrentRow.Cells[2].Value + "'";
                LoadRegisterToDGV(sql);
	        }
        }

        private void dgvStudent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _contextMenu.Show(dgvStudent, e.Location);
            }
        }

        private void btnFinger_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvStudent.Rows)
            {
                item.Selected = true;
                if ((string)item.Cells[2].Value == "noscan")
                {
                    ScanFingerStdFrm frm = new ScanFingerStdFrm();
                    frm.Parent = this;
                    frm.AutoScanMode = true;
                    frm.StdID = (string)item.Cells[0].Value;
                    frm.StdName = (string)item.Cells[1].Value; ;
                    frm.ShowDialog();
                    dgvSubject_SelectionChanged(null, null);
                    if (frm.StopAutoScan == true)
                    {
                        break;
                    }
                }
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            bool bStopCheckin = false;
            while (bStopCheckin == false)
            {
                CheckinStdFrm frm = new CheckinStdFrm();
                frm.Parent = this;
                frm.SubID = (string)dgvSubject.CurrentRow.Cells[0].Value;
                frm.Year = (string)dgvSubject.CurrentRow.Cells[2].Value;
                frm.ShowDialog();
                frm.GetStopAutoCheckin(ref bStopCheckin);
                dgvSubject_SelectionChanged(null, null);
            }
        }
    }
}
