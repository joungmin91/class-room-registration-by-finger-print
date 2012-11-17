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
        private ContextMenu _contextMenu = null;
        private bool _allowUdateRow = false;
        private string _sqlShowAllSubject = "SELECT s.sub_id, s.sub_title, t.year FROM teaching t JOIN subject s ON t.sub_id = s.sub_id";
        private string _sqlShowAllRegister = "SELECT r.std_id, s.std_name, s.std_fp_key FROM registration r JOIN student s ON r.std_id = s.std_id";

        public TeachingViewFrm()
        {
            InitializeComponent();
        }

        private void TeachingViewFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            _db = ((MainFrm)this.MdiParent)._db;

            // Setup datagrid columns
            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudent.AllowUserToAddRows = false;
            dgvStudent.AllowUserToDeleteRows = false;
            dgvStudent.MultiSelect = false;
            dgvStudent.ReadOnly = true;
            dgvStudent.ColumnCount = 3;
            dgvStudent.Columns[0].HeaderText = "รหัสนิสิต";
            dgvStudent.Columns[0].Width = 100;
            dgvStudent.Columns[1].HeaderText = "ชื่อนิสิต";
            dgvStudent.Columns[1].Width = 540;
            dgvStudent.Columns[2].HeaderText = "สถานะ";
            dgvStudent.Columns[2].Visible = false;
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "ลายนิ้วมือ";
            imgCol.Width = 60;
            dgvStudent.Columns.Add(imgCol);

            // Setup datagrid columns
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubject.AllowUserToAddRows = false;
            dgvSubject.AllowUserToDeleteRows = false;
            dgvSubject.MultiSelect = false;
            dgvSubject.ReadOnly = true;
            dgvSubject.ColumnCount = 3;
            dgvSubject.Columns[0].HeaderText = "รหัสวิชา";
            dgvStudent.Columns[0].Width = 100;
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
            MessageBox.Show("รอการพัฒนา");
        }

        void givePoint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("รอการพัฒนา");
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
            frm.StdName = (string)dgvStudent.CurrentRow.Cells[1].Value; ;
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
                        LoadImage("finger2.png")
                        );
                }
                else
                {
                    dgvStudent.Rows.Add(
                        _db.Result.GetValue(0),
                        _db.Result.GetValue(1),
                        "noscan",
                        LoadImage("nofinger2.png")
                        );
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

        private void btnScore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("รอการพัฒนา");
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("รอการพัฒนา");
        }
    }
}
