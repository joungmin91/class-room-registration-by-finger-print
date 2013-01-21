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
        private string _sqlShowAllSubject = "SELECT s.id, s.sub_id, s.sub_title, s.sub_lec, s.sub_lab, t.year, t.id as teaching_id FROM teaching t JOIN subject s ON t.sub_id = s.id";
        private string _sqlShowAllRegister = "SELECT r.std_id, s.std_name, s.std_fp_key, r.reg_id FROM registration r JOIN student s ON r.std_id = s.std_id";
        private bool _bAlreadyRegis = false;
        private List<int> _lstPoint = new List<int>();

        public TeachingViewFrm()
        {
            InitializeComponent();
        }

        private void TeachingViewFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            _db = ((MainFrm)this.MdiParent)._db;

            // Setup datagrid columns
            AddColumnForStudentDGV();

            // Setup datagrid columns
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubject.AllowUserToAddRows = false;
            dgvSubject.AllowUserToDeleteRows = false;
            dgvSubject.MultiSelect = false;
            dgvSubject.ReadOnly = true;
            dgvSubject.ColumnCount = 7;
            dgvSubject.Columns[0].HeaderText = "ไอดีวิชา";
            dgvSubject.Columns[0].Name = "ID";
            dgvSubject.Columns[0].Visible = false;  
            dgvSubject.Columns[1].HeaderText = "รหัสวิชา";
            dgvSubject.Columns[1].Width = 100;
            dgvSubject.Columns[1].Name = "SubID";
            dgvSubject.Columns[2].HeaderText = "ชื่อวิชา";
            dgvSubject.Columns[2].Width = 250;
            dgvSubject.Columns[2].Name = "SubTitle";
            dgvSubject.Columns[3].HeaderText = "หมู่บรรยาย";
            dgvSubject.Columns[3].Width = 100;
            dgvSubject.Columns[3].Name = "SubLec";
            dgvSubject.Columns[4].HeaderText = "หมู่ปฏิบัติ";
            dgvSubject.Columns[4].Width = 100;
            dgvSubject.Columns[4].Name = "SubLab";
            dgvSubject.Columns[5].HeaderText = "ปีการศึกษา";
            dgvSubject.Columns[5].Width = 100;
            dgvSubject.Columns[5].Name = "SubYear";
            dgvSubject.Columns[6].HeaderText = "ไอดีสอน";
            dgvSubject.Columns[6].Width = 100;
            dgvSubject.Columns[6].Name = "TechID";
            dgvSubject.Columns[6].Visible = false;

            string sql = _sqlShowAllSubject + " WHERE t.tech_id='" + TechID + "'";
            LoadSubjectToDGV(sql);

            // Setup score datagrid
            dgvScore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScore.AllowUserToAddRows = false;
            dgvScore.AllowUserToDeleteRows = false;
            dgvScore.MultiSelect = false;
            //dgvScore.ReadOnly = true;
            dgvScore.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvScore.ColumnCount = 12;
            dgvScore.Columns[0].HeaderText = "รหัสนิสิต";
            dgvScore.Columns[0].Width = 100;
            dgvScore.Columns[0].ReadOnly = true;
            dgvScore.Columns[0].Frozen = true;
            dgvScore.Columns[1].HeaderText = "ชื่อนิสิต";
            dgvScore.Columns[1].Width = 200;
            dgvScore.Columns[1].ReadOnly = true;
            dgvScore.Columns[1].Frozen = true;
            dgvScore.Columns[2].HeaderText = "เกรด";
            dgvScore.Columns[2].Width = 50;
            dgvScore.Columns[2].ReadOnly = true;
            dgvScore.Columns[2].Frozen = true;
            dgvScore.Columns[3].HeaderText = "คะแนนรวม";
            dgvScore.Columns[3].Width = 90;
            dgvScore.Columns[3].ReadOnly = true;
            dgvScore.Columns[3].Frozen = true;

            dgvScore.Columns[4].HeaderText = "กลางภาค";
            dgvScore.Columns[4].Width = 100;
            dgvScore.Columns[5].HeaderText = "ปลายภาค";
            dgvScore.Columns[5].Width = 100;
            dgvScore.Columns[6].HeaderText = "จิตพิสัย";
            dgvScore.Columns[6].Width = 100;
            dgvScore.Columns[7].HeaderText = "คะแนนเก็บ 1";
            dgvScore.Columns[7].Width = 100;
            dgvScore.Columns[8].HeaderText = "คะแนนเก็บ 2";
            dgvScore.Columns[8].Width = 100;
            dgvScore.Columns[9].HeaderText = "คะแนนเก็บ 3";
            dgvScore.Columns[9].Width = 100;
            dgvScore.Columns[10].HeaderText = "คะแนนเก็บ 4";
            dgvScore.Columns[10].Width = 100;
            dgvScore.Columns[11].HeaderText = "คะแนนเก็บ 5";
            dgvScore.Columns[11].Width = 100;

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
                int subID = (int)dgvSubject.CurrentRow.Cells["ID"].Value;
                string stdID = dgvStudent.CurrentRow.Cells[0].Value as string;
                string year = dgvSubject.CurrentRow.Cells["SubYear"].Value as string;
                string date = DateTime.Now.ToShortDateString();
                string value = dgvStudent.Rows[e.RowIndex].Cells[idx+1].Value as string;
                if (value == "uncheck")
                {
                    // if the time is over setup time then mark as late status.
                    string status = "normal";
                    int h = DateTime.Now.Hour;
                    int m = DateTime.Now.Minute;
                    int sh = Convert.ToInt16(dtLate.Text.Substring(0, 2));
                    int sm = Convert.ToInt16(dtLate.Text.Substring(3, 2));
                    if (h > sh || m > (sm + 15))
                    {
                        status = "late";
                    }
                    // if the record is not in database, just insert.
                    _db.SQLCommand = "SELECT * FROM checkin WHERE sub_id='" + subID + "' AND std_id='" + stdID + "' AND chkin_year='" + year + "' AND chkin_date='" + date + "'";
                    _db.Query();
                    if (_db.Result.HasRows == false)
                    {
                        _db.SQLCommand = "INSERT INTO checkin (sub_id, std_id, chkin_year, chkin_date, chkin_status) VALUES ('" + subID + "', '" + stdID + "', '" + year + "', '" + date + "', '" + status + "')";
                        _db.Query();
                        if (status == "normal")
                        {
                            dgvStudent.Rows[e.RowIndex].Cells[idx].Value = LoadImage("check.png");    
                        }
                        else
                        {
                            dgvStudent.Rows[e.RowIndex].Cells[idx].Value = LoadImage("late.png");
                        }
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
            frm.TimeLate = dtLate.Value.TimeOfDay;
            frm.Parent = this;
            frm.SubID = (int)dgvSubject.CurrentRow.Cells["ID"].Value;
            frm.Year = (string)dgvSubject.CurrentRow.Cells["SubYear"].Value;
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
                    _db.Result["id"],
                    _db.Result["sub_id"],
                    _db.Result["sub_title"],
                    _db.Result["sub_lec"],
                    _db.Result["sub_lab"],
                    _db.Result["year"],
                    _db.Result["teaching_id"]
                    );
            }
        }

        private void LoadScoreToDGV()
        {
            if (dgvSubject.CurrentRow == null)
            {
                return;
            }

            // Clear DGV
            dgvScore.Rows.Clear();
            // Load all registered student
            _db.SQLCommand = "SELECT s.std_id, s.std_name FROM registration r JOIN student s ON r.std_id=s.std_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "'";
            _db.Query();

            if (_db.Result.HasRows == false)
            {
                MessageBox.Show("ไม่มีรายการที่ต้องการแสดง", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                dgvScore.Rows.Add(_db.Result["std_id"], _db.Result["std_name"]);
            }

            _lstPoint.Clear();

            // Retrieve student's score
            foreach (DataGridViewRow item in dgvScore.Rows)
            {
                int score = 0;

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='1'";
                _db.Query();
                if (_db.Result.Read() == false)
                {
                    item.Cells[3].Value = 0;
                    item.Cells[4].Value = 0;
                    item.Cells[5].Value = 0;
                    item.Cells[6].Value = 0;
                    item.Cells[7].Value = 0;
                    item.Cells[8].Value = 0;
                    item.Cells[9].Value = 0;
                    item.Cells[10].Value = 0;
                    item.Cells[11].Value = 0;
                    continue;
                }

                item.Cells[4].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[4].Value);

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='2'";
                _db.Query();
                _db.Result.Read();
                item.Cells[5].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[5].Value);

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='3'";
                _db.Query();
                _db.Result.Read();
                item.Cells[6].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[6].Value);

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='4'";
                _db.Query();
                _db.Result.Read();
                item.Cells[7].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[7].Value);

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='5'";
                _db.Query();
                _db.Result.Read();
                item.Cells[8].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[8].Value);

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='6'";
                _db.Query();
                _db.Result.Read();
                item.Cells[9].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[9].Value);

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='7'";
                _db.Query();
                _db.Result.Read();
                item.Cells[10].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[10].Value);

                _db.SQLCommand = "SELECT s.score_point, s.score_type FROM registration r JOIN score s ON r.reg_id = s.reg_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.std_id='" + item.Cells[0].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND s.score_type='8'";
                _db.Query();
                _db.Result.Read();
                item.Cells[11].Value = _db.Result["score_point"];
                score += Convert.ToInt16(item.Cells[11].Value);

                item.Cells[3].Value = score;
                _lstPoint.Add(score);

                //item.Cells[2].Value = score;
                _db.SQLCommand = "SELECT * FROM score_rate_type WHERE tech_id='" + dgvSubject.CurrentRow.Cells["TechID"].Value + "'";
                _db.Query();

                if (_db.Result.HasRows == true)
                {
                    _db.Result.Read();
                    //if (_db.Result["type"].ToString() == "grade")
                    {
                        if (score >= Convert.ToInt16(_db.Result["F"]))
                        {
                            item.Cells[2].Value = "F";
                        }

                        if (score >= Convert.ToInt16(_db.Result["D"]))
                        {
                            item.Cells[2].Value = "D";
                        }

                        if (score >= Convert.ToInt16(_db.Result["DP"]))
                        {
                            item.Cells[2].Value = "D+";
                        }

                        if (score >= Convert.ToInt16(_db.Result["C"]))
                        {
                            item.Cells[2].Value = "C";
                        }

                        if (score >= Convert.ToInt16(_db.Result["CP"]))
                        {
                            item.Cells[2].Value = "C+";
                        }

                        if (score >= Convert.ToInt16(_db.Result["B"]))
                        {
                            item.Cells[2].Value = "B";
                        }

                        if (score >= Convert.ToInt16(_db.Result["BP"]))
                        {
                            item.Cells[2].Value = "B+";
                        }

                        if (score >= Convert.ToInt16(_db.Result["A"]))
                        {
                            item.Cells[2].Value = "A";
                        }
                    }
                }
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

            int subID = (int)dgvSubject.CurrentRow.Cells["ID"].Value;
            string year = (string)dgvSubject.CurrentRow.Cells["SubYear"].Value;
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
                        _db.Result.Read();
                        if (_db.Result["chkin_status"] as string == "normal")
                        {
                            item.Cells[i].Value = LoadImage("check.png");
                        }
                        else
                        {
                            item.Cells[i].Value = LoadImage("late.png");
                        }
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
                    _db.Result.Read();
                    if (_db.Result["chkin_status"] as string == "normal")
                    {
                        item.Cells[idx].Value = LoadImage("check.png");
                        item.Cells[idx + 1].Value = "check";
                    }
                    else
                    {
                        item.Cells[idx].Value = LoadImage("late.png");
                        item.Cells[idx + 1].Value = "check";
                    }
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
		        string sql = _sqlShowAllRegister + " WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "'";
                LoadRegisterToDGV(sql);
                LoadScoreToDGV();
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
                frm.TimeLate = dtLate.Value.TimeOfDay;
                frm.Parent = this;
                frm.SubID = (int)dgvSubject.CurrentRow.Cells["ID"].Value;
                frm.Year = (string)dgvSubject.CurrentRow.Cells["SubYear"].Value;
                frm.ShowDialog();
                frm.GetStopAutoCheckin(ref bStopCheckin);
                dgvSubject_SelectionChanged(null, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Each row in DGV
            foreach (DataGridViewRow item in dgvScore.Rows)
            {
                // Use sub_id, std_id and year to retrieve record from registration then index to score
                _db.SQLCommand = "SELECT * FROM registration WHERE sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND std_id='" + item.Cells[0].Value +"' AND year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "'";
                _db.Query();
                if (_db.Result.Read() == true)
                {
                    int reg_id = (int)_db.Result["reg_id"];
                    _db.SQLCommand = "SELECT * FROM score WHERE reg_id='" + reg_id.ToString() + "'";
                    _db.Query();
                    _db.Result.Read();
                    if (_db.Result.HasRows == true)
                    {
                        // Update record
                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[3].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='1' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();

                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[4].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='2' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();

                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[5].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='3' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();

                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[6].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='4' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();

                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[7].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='5' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();

                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[8].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='6' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();

                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[9].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='7' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();

                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "score_point='" + item.Cells[10].Value + "' ";
                        _db.SQLCommand += "WHERE score_type='8' AND reg_id='" + reg_id.ToString() + "'";
                        _db.Query();
                    }
                    else
                    {
                        // New record
                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[3].Value + "', '1', '" + reg_id.ToString() + "')";
                        _db.Query();

                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[4].Value + "', '2', '" + reg_id.ToString() + "')";
                        _db.Query();

                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[5].Value + "', '3', '" + reg_id.ToString() + "')";
                        _db.Query();

                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[6].Value + "', '4', '" + reg_id.ToString() + "')";
                        _db.Query();

                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[7].Value + "', '5', '" + reg_id.ToString() + "')";
                        _db.Query();

                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[8].Value + "', '6', '" + reg_id.ToString() + "')";
                        _db.Query();

                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[9].Value + "', '7', '" + reg_id.ToString() + "')";
                        _db.Query();

                        _db.SQLCommand = "INSERT INTO score (score_point, score_type, reg_id) VALUES ('" + item.Cells[10].Value + "', '8', '" + reg_id.ToString() + "')";
                        _db.Query();
                    }
                }
            }
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadScoreToDGV();
        }

        private void btnScoreSetting_Click(object sender, EventArgs e)
        {
            if (dgvSubject.CurrentRow == null)
            {
                return;
            }

            ScoreRateFrm frm = new ScoreRateFrm();
            frm.Parent = this.MdiParent;
            frm.TeachingID = (int)dgvSubject.CurrentRow.Cells["TechID"].Value;
            frm._lstPoint = _lstPoint;
            frm.ShowDialog();

            LoadScoreToDGV();
        }
    }
}
