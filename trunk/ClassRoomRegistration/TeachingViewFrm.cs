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
using System.Drawing.Printing;

namespace ClassRoomRegistration
{
    public partial class TeachingViewFrm : Form
    {
        public string TechID { get; set; }
        public MySQLDatabase _db = null;
        private ContextMenu _contextMenu = null;
        private bool _allowUdateRow = false;
        private string _sqlShowAllSubject = "SELECT s.id, s.sub_id, s.sub_title, s.sub_lec, s.sub_lab, t.year, t.term, t.id as teaching_id FROM teaching t JOIN subject s ON t.sub_id = s.id";
        private string _sqlShowAllRegister = "SELECT r.std_id, s.std_name, s.std_fp_key, r.reg_id FROM registration r JOIN student s ON r.std_id = s.std_id";
        private bool _bAlreadyRegis = false;
        private List<int> _lstPoint = new List<int>();

        private class Record
        {
            public string StdID { get; set; }
            public string StdName { get; set; }
            public int RegID { get; set; }
        };

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
            dgvSubject.ColumnCount = 8;
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
            dgvSubject.Columns[6].HeaderText = "ภาคศึกษา";
            dgvSubject.Columns[6].Width = 100;
            dgvSubject.Columns[6].Name = "SubTerm";
            dgvSubject.Columns[7].HeaderText = "ไอดีสอน";
            dgvSubject.Columns[7].Width = 100;
            dgvSubject.Columns[7].Name = "TechID";
            dgvSubject.Columns[7].Visible = false;

            string sql = _sqlShowAllSubject + " WHERE t.tech_id='" + TechID + "'";
            LoadSubjectToDGV(sql);

            // Setup score datagrid
            dgvScore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScore.AllowUserToAddRows = false;
            dgvScore.AllowUserToDeleteRows = false;
            dgvScore.MultiSelect = false;
            //dgvScore.ReadOnly = true;
            dgvScore.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvScore.ColumnCount = 14;
            dgvScore.Columns[0].HeaderText = "ลำดับ";
            dgvScore.Columns[0].Width = 40;
            dgvScore.Columns[0].ReadOnly = true;
            dgvScore.Columns[1].HeaderText = "รหัสนิสิต";
            dgvScore.Columns[1].Name = "StdID";
            dgvScore.Columns[1].Width = 80;
            dgvScore.Columns[1].ReadOnly = true;
            dgvScore.Columns[1].Frozen = true;
            dgvScore.Columns[2].HeaderText = "ชื่อนิสิต";
            dgvScore.Columns[2].Width = 160;
            dgvScore.Columns[2].ReadOnly = true;
            dgvScore.Columns[2].Frozen = true;
            dgvScore.Columns[3].HeaderText = "เกรด";
            dgvScore.Columns[3].Width = 50;
            dgvScore.Columns[3].ReadOnly = true;
            dgvScore.Columns[3].Frozen = true;
            dgvScore.Columns[4].HeaderText = "รวม";
            dgvScore.Columns[4].Width = 50;
            dgvScore.Columns[4].ReadOnly = true;
            dgvScore.Columns[4].Frozen = true;
            dgvScore.Columns[5].HeaderText = "กลางภาค";
            dgvScore.Columns[5].Width = 50;
            dgvScore.Columns[6].HeaderText = "ปลายภาค";
            dgvScore.Columns[6].Width = 50;
            dgvScore.Columns[7].HeaderText = "เข้าเรียน";
            dgvScore.Columns[7].Width = 50;
            dgvScore.Columns[7].ReadOnly = true;
            dgvScore.Columns[8].HeaderText = "เก็บ 1";
            dgvScore.Columns[8].Width = 50;
            dgvScore.Columns[9].HeaderText = "เก็บ 2";
            dgvScore.Columns[9].Width = 50;
            dgvScore.Columns[10].HeaderText = "เก็บ 3";
            dgvScore.Columns[10].Width = 50;
            dgvScore.Columns[11].HeaderText = "เก็บ 4";
            dgvScore.Columns[11].Width = 50;
            dgvScore.Columns[12].HeaderText = "เก็บ 5";
            dgvScore.Columns[12].Width = 50;
            dgvScore.Columns[13].HeaderText = "รหัสลงทะเบียน";
            dgvScore.Columns[13].Width = 50;
            dgvScore.Columns[13].Name = "RegID";

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
            dgvStudent.ColumnCount = 5;
            dgvStudent.Columns[0].HeaderText = "ลำดับ";
            dgvStudent.Columns[0].Width = 50;
            dgvStudent.Columns[0].Frozen = true;
            dgvStudent.Columns[1].HeaderText = "รหัสนิสิต";
            dgvStudent.Columns[1].Width = 100;
            dgvStudent.Columns[1].Frozen = true;
            dgvStudent.Columns[2].HeaderText = "ชื่อนิสิต";
            dgvStudent.Columns[2].Width = 200;
            dgvStudent.Columns[2].Frozen = true;
            dgvStudent.Columns[3].HeaderText = "สถานะ";
            dgvStudent.Columns[3].Name = "Status";
            dgvStudent.Columns[3].Frozen = true;
            dgvStudent.Columns[3].Visible = false;
            dgvStudent.Columns[4].HeaderText = "รหัสลงทะเบียน";
            dgvStudent.Columns[4].Name = "RegID";
            dgvStudent.Columns[4].Visible = false;
            dgvStudent.Columns[4].Frozen = true;
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "ลายนิ้วมือ";
            imgCol.Width = 60;
            imgCol.Frozen = true;
            dgvStudent.Columns.Add(imgCol);
        }

        void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = dgvStudent.Columns.Count - 2;
            if (e.ColumnIndex > 5) // More than order, std_id, std_name, status, reg_id, finger
            {
                int regID = (int)dgvStudent.CurrentRow.Cells["RegID"].Value;
                string date = dgvStudent.Columns[e.ColumnIndex].HeaderText;
                string status = dgvStudent.CurrentRow.Cells[e.ColumnIndex + 1].Value as string;

                // Update state columns
                if (status == "normal")
                {
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex].Value = LoadImage("absence.png");
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex + 1].Value = "absence";
                    status = "absence";
                }
                else if (status == "absence")
                {
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex].Value = LoadImage("late.png");
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex + 1].Value = "late";
                    status = "late";
                }
                else if (status == "late")
                {
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex].Value = LoadImage("uncheck.png");
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex + 1].Value = "uncheck";
                    status = "uncheck";
                }
                else if (status == "uncheck")
                {
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex].Value = LoadImage("normal.png");
                    dgvStudent.CurrentRow.Cells[e.ColumnIndex + 1].Value = "normal";
                    status = "normal";
                }

                // Get the existing record
                _db.SQLCommand = "SELECT * FROM checkin WHERE reg_id='" + regID + "' AND date='" + date + "'";
                _db.Query();

                // If the record has been presented
                if (_db.Result.HasRows == true)
                {
                    if (status == "uncheck")
                    {
                        // Delete the record
                        _db.SQLCommand = "DELETE FROM checkin WHERE reg_id='" + regID + "' AND date='" + date + "'";
                        _db.Query();
                    }
                    else
                    {
                        // Update the record
                        _db.Result.Read();
                        _db.SQLCommand = "UPDATE checkin SET status='" + status + "' WHERE id='" + _db.Result["id"].ToString() + "'";
                        _db.Query();
                    }
                }
                // If the record has not been presented yet
                else
                {
                    if (status != "uncheck")
                    {
                        _db.SQLCommand = "INSERT INTO checkin (reg_id, date, status) VALUES ('" + regID + "', '" + date + "', '" + status + "')";
                        _db.Query();
                    }
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

            //MenuItem givePoint = new MenuItem("ให้คะแนนนิสิตคนนี้");
            //givePoint.Click += new EventHandler(givePoint_Click);
            //_contextMenu.MenuItems.Add(givePoint);

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

        //void givePoint_Click(object sender, EventArgs e)
        //{
        //    if (dgvStudent.CurrentRow == null)
        //    {
        //        return;
        //    }

        //    ScoreFrm frm = new ScoreFrm();
        //    frm.Parent = this;
        //    frm.RegisID = Convert.ToString(dgvStudent.CurrentRow.Cells[3].Value);
        //    frm.StdID = (string)dgvStudent.CurrentRow.Cells[0].Value;
        //    frm.StdName = (string)dgvStudent.CurrentRow.Cells[1].Value;
        //    frm.ShowDialog();
        //}

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
                    _db.Result["term"],
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
            
            // Load all registered student
            _db.SQLCommand = "SELECT s.std_id, s.std_name, r.reg_id FROM registration r JOIN student s ON r.std_id=s.std_id WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND r.term='" + dgvSubject.CurrentRow.Cells["SubTerm"].Value + "'";
            _db.Query();

            // No rows to show
            if (_db.Result.HasRows == false)
            {
                return;
            }

            // Store all students that registered this subject into a list
            List<Record> lstStudent = new List<Record>();
            while (_db.Result.Read())
            {
                lstStudent.Add(new Record { StdID = _db.Result["std_id"] as string, StdName = _db.Result["std_name"] as string, RegID = (int)_db.Result["reg_id"] });
            }

            // Clear DGV
            dgvScore.Rows.Clear();

            // Retrieve student's score
            int order = 0;
            _lstPoint.Clear();
            foreach (Record item in lstStudent)
            {
                int totalScore = 0;
                order++;
                // Retrieve the student's score
                _db.SQLCommand = "SELECT * FROM score WHERE reg_id='" + item.RegID + "'";
                _db.Query();
                // If the student has not yet a score, just fill zero
                if (_db.Result.Read() == false)
                {
                    dgvScore.Rows.Add(order, item.StdID, item.StdName, "-", 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    _lstPoint.Add(0);
                    continue;
                }

                int midScore = (int)_db.Result["mid"];
                int finalScore = (int)_db.Result["final"];
                int score1 = (int)_db.Result["score1"];
                int score2 = (int)_db.Result["score2"];
                int score3 = (int)_db.Result["score3"];
                int score4 = (int)_db.Result["score4"];
                int score5 = (int)_db.Result["score5"];

                // Calculate checkin's score, the fomular is (15/10) = (20/x)
                int checkinScore = 0;   // This will calculate later.
                checkinScore = GetCheckinScore(Convert.ToString(dgvSubject.CurrentRow.Cells["TechID"].Value), Convert.ToString(item.RegID));

                //// Get a number of checkin's dates
                //int countChkDate = 0;
                //_db.SQLCommand = "SELECT COUNT(date) FROM checkin_date WHERE tech_id='" + dgvSubject.CurrentRow.Cells["TechID"].Value + "'";
                //_db.Query();
                //if (_db.Result.Read())
                //{
                //    countChkDate = Convert.ToInt16(_db.Result.GetValue(0));
                //}
                //else
                //{
                //    countChkDate = 0;
                //}

                //// Get setting checkin score
                //int settingChkinScore = 0;
                //_db.SQLCommand = "SELECT checkin FROM score_rating WHERE tech_id='" + dgvSubject.CurrentRow.Cells["TechID"].Value + "'";
                //_db.Query();
                //if (_db.Result.Read())
                //{
                //    settingChkinScore = Convert.ToInt16(_db.Result["checkin"]);
                //}
                //else
                //{
                //    settingChkinScore = 0;
                //}

                //// Get a number of checkin
                //int countChk = 0;
                //_db.SQLCommand = "SELECT COUNT(reg_id) FROM checkin WHERE reg_id='" + item.RegID + "'";
                //_db.Query();
                //if (_db.Result.Read())
                //{
                //    countChk = Convert.ToInt16(_db.Result.GetValue(0));
                //}
                //else
                //{
                //    countChk = 0;
                //}

                //// Then calculate the score
                //checkinScore = (settingChkinScore * countChk) / countChkDate;

                // Total score is
                totalScore = midScore + finalScore + checkinScore + score1 + score2 + score3 + score4 + score5;

                // Convert raw score to A - F grade
                string grade = "";
                grade = GetGradeFromScore(totalScore);
                //_db.SQLCommand = "SELECT a, bp, b, cp, c, dp, d FROM score_rating WHERE tech_id='" + dgvSubject.CurrentRow.Cells["TechID"].Value + "'";
                //_db.Query();
                //if (_db.Result.Read())
                //{
                //    if (totalScore >= Convert.ToInt16(_db.Result["a"]))
                //    {
                //        grade = "A";
                //    }
                //    else if (totalScore >= Convert.ToInt16(_db.Result["bp"]))
                //    {
                //        grade = "B+";
                //    }
                //    else if (totalScore >= Convert.ToInt16(_db.Result["b"]))
                //    {
                //        grade = "B";
                //    }
                //    else if (totalScore >= Convert.ToInt16(_db.Result["cp"]))
                //    {
                //        grade = "C+";
                //    }
                //    else if (totalScore >= Convert.ToInt16(_db.Result["c"]))
                //    {
                //        grade = "C";
                //    }
                //    else if (totalScore >= Convert.ToInt16(_db.Result["dp"]))
                //    {
                //        grade = "D+";
                //    }
                //    else if (totalScore >= Convert.ToInt16(_db.Result["d"]))
                //    {
                //        grade = "D";
                //    }
                //    else
                //    {
                //        grade = "F";
                //    }
                //}
                //else
                //{
                    
                //}

                // Insert into DGV Score
                dgvScore.Rows.Add(order, item.StdID, item.StdName, grade, totalScore, midScore, finalScore, checkinScore, score1, score2, score3, score4, score5, item.RegID);
                _lstPoint.Add(totalScore);
            }
        }

        private string GetGradeFromScore(int score)
        {
            MySQLDatabase db = new MySQLDatabase();
            db.DBServer = _db.DBServer;
            db.DBUser = _db.DBUser;
            db.DBPassword = _db.DBPassword;
            db.DBName = _db.DBName;
            db.Connect();

            string grade = "";
            _db.SQLCommand = "SELECT a, bp, b, cp, c, dp, d FROM score_rating WHERE tech_id='" + dgvSubject.CurrentRow.Cells["TechID"].Value + "'";
            _db.Query();
            if (_db.Result.Read())
            {
                if (score >= Convert.ToInt16(_db.Result["a"]))
                {
                    grade = "A";
                }
                else if (score >= Convert.ToInt16(_db.Result["bp"]))
                {
                    grade = "B+";
                }
                else if (score >= Convert.ToInt16(_db.Result["b"]))
                {
                    grade = "B";
                }
                else if (score >= Convert.ToInt16(_db.Result["cp"]))
                {
                    grade = "C+";
                }
                else if (score >= Convert.ToInt16(_db.Result["c"]))
                {
                    grade = "C";
                }
                else if (score >= Convert.ToInt16(_db.Result["dp"]))
                {
                    grade = "D+";
                }
                else if (score >= Convert.ToInt16(_db.Result["d"]))
                {
                    grade = "D";
                }
                else
                {
                    grade = "F";
                }
            }
            else
            {
                grade = "F";
            }
            db.Close();
            return grade;
        }

        private int GetCheckinScore(string tech_id, string reg_id)
        {
            MySQLDatabase db = new MySQLDatabase();
            db.DBServer = _db.DBServer;
            db.DBUser = _db.DBUser;
            db.DBPassword = _db.DBPassword;
            db.DBName = _db.DBName;
            db.Connect();

            // Calculate checkin's score, the fomular is (15/10) = (20/x)
            int checkinScore = 0;   // This will calculate later.

            // Get a number of checkin's dates
            int countChkDate = 0;
            db.SQLCommand = "SELECT COUNT(date) FROM checkin_date WHERE tech_id='" + tech_id + "'";
            db.Query();
            if (db.Result.Read())
            {
                countChkDate = Convert.ToInt16(db.Result.GetValue(0));
            }
            else
            {
                countChkDate = 0;
            }

            // Get setting checkin score
            int settingChkinScore = 0;
            db.SQLCommand = "SELECT checkin FROM score_rating WHERE tech_id='" + tech_id + "'";
            db.Query();
            if (db.Result.Read())
            {
                settingChkinScore = Convert.ToInt16(db.Result["checkin"]);
            }
            else
            {
                settingChkinScore = 0;
            }

            // Get a number of checkin
            int countChk = 0;
            db.SQLCommand = "SELECT COUNT(reg_id) FROM checkin WHERE reg_id='" + reg_id + "'";
            db.Query();
            if (db.Result.Read())
            {
                countChk = Convert.ToInt16(db.Result.GetValue(0));
            }
            else
            {
                countChk = 0;
            }

            db.Close();

            // Then calculate the score
            checkinScore = (settingChkinScore * countChk) / countChkDate;
            return checkinScore;
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
            int order = 0;
            while (_db.Result.Read())
            {
                order++;
                if ((string)_db.Result.GetValue(2) != "")
                {
                    dgvStudent.Rows.Add(
                        order.ToString(),
                        _db.Result["std_id"],
                        _db.Result["std_name"],
                        "scaned",
                        _db.Result["reg_id"],
                        LoadImage("finger2.png")
                        );
                }
                else
                {
                    dgvStudent.Rows.Add(
                        order.ToString(),
                        _db.Result["std_id"],
                        _db.Result["std_name"],
                        "noscan",
                        _db.Result["reg_id"],
                        LoadImage("nofinger2.png")
                        );
                }
            }

            int tech_id = (int)dgvSubject.CurrentRow.Cells["TechID"].Value;

            // Load others groups
            _db.SQLCommand = "SELECT * FROM checkin_date WHERE tech_id='" + tech_id + "' ORDER BY date";
            _db.Query();
            if (_db.Result.HasRows == true)
            {
                while (_db.Result.Read() == true)
                {
                    // Image column
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.HeaderText = _db.Result["date"] as string;
                    imgCol.Width = 70;
                    int idx = dgvStudent.Columns.Add(imgCol);

                    // Status column
                    DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn();
                    statusCol.HeaderText = _db.Result["date"] as string;
                    statusCol.Width = 70;
                    statusCol.Visible = false;
                    int idxStatus = dgvStudent.Columns.Add(statusCol);

                    MySQLDatabase localDB = new MySQLDatabase();
                    localDB.DBUser = _db.DBUser;
                    localDB.DBPassword = _db.DBPassword;
                    localDB.DBServer = _db.DBServer;
                    localDB.DBName = _db.DBName;
                    localDB.Connect();

                    foreach (DataGridViewRow item in dgvStudent.Rows)
                    {
                        string regID = Convert.ToString(item.Cells[4].Value); // TechID
                        string hisDate = imgCol.HeaderText;

                        // Must use a new db connection.
                        localDB.SQLCommand = "SELECT * FROM checkin WHERE date='" + hisDate + "' AND reg_id='" + regID + "'";
                        localDB.Query();

                        if (localDB.Result.HasRows == true)
                        {
                            localDB.Result.Read();
                            if (localDB.Result["status"] as string == "normal")
                            {
                                item.Cells[idx].Value = LoadImage("normal.png");
                                item.Cells[idxStatus].Value = "normal";
                            }
                            else if (localDB.Result["status"] as string == "absence")
                            {
                                item.Cells[idx].Value = LoadImage("absence.png");
                                item.Cells[idxStatus].Value = "absence";
                            }
                            else
                            {
                                item.Cells[idx].Value = LoadImage("late.png");
                                item.Cells[idxStatus].Value = "late";
                            }
                        }
                        else
                        {
                            item.Cells[idx].Value = LoadImage("uncheck.png");
                            item.Cells[idxStatus].Value = "uncheck";
                        }
                    }
                    localDB.Close();
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
                string sql = _sqlShowAllRegister + " WHERE r.sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND r.year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND r.term='" + dgvSubject.CurrentRow.Cells["SubTerm"].Value + "'";
                LoadRegisterToDGV(sql);
                LoadScoreToDGV();
                btnSave_Click(null, null);
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
                frm.Term = (string)dgvSubject.CurrentRow.Cells["SubTerm"].Value;
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
                _db.SQLCommand = "SELECT * FROM registration WHERE sub_id='" + dgvSubject.CurrentRow.Cells["ID"].Value + "' AND std_id='" + item.Cells["StdID"].Value + "' AND year='" + dgvSubject.CurrentRow.Cells["SubYear"].Value + "' AND term='" + dgvSubject.CurrentRow.Cells["SubTerm"].Value + "'";
                _db.Query();
                // If the student already registered
                if (_db.Result.Read() == true)
                {
                    int reg_id = (int)_db.Result["reg_id"];
                    _db.SQLCommand = "SELECT * FROM score WHERE reg_id='" + reg_id.ToString() + "'";
                    _db.Query();
                    if (_db.Result.Read() == true)
                    {
                        // Update record
                        _db.SQLCommand = "UPDATE score SET ";
                        _db.SQLCommand += "mid='" + item.Cells[5].Value + "', ";
                        _db.SQLCommand += "final='" + item.Cells[6].Value + "', ";
                        _db.SQLCommand += "score1='" + item.Cells[8].Value + "', ";
                        _db.SQLCommand += "score2='" + item.Cells[9].Value + "', ";
                        _db.SQLCommand += "score3='" + item.Cells[10].Value + "', ";
                        _db.SQLCommand += "score4='" + item.Cells[11].Value + "', ";
                        _db.SQLCommand += "score5='" + item.Cells[12].Value + "' ";
                        _db.SQLCommand += "WHERE reg_id='" + reg_id.ToString() + "'";
                        _db.Query();
                    }
                    else
                    {
                        // New record
                        _db.SQLCommand = "INSERT INTO score (reg_id, mid, final, score1, score2, score3, score4, score5) VALUES ('" + reg_id + "', '" + item.Cells[5].Value + "', '" + item.Cells[6].Value + "', '" + item.Cells[8].Value + "', '" + item.Cells[9].Value + "', '" + item.Cells[10].Value + "', '" + item.Cells[11].Value + "', '" + item.Cells[12].Value + "')";
                        _db.Query();
                    }
                }
            }
            //MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnChkinDate_Click(object sender, EventArgs e)
        {
            CheckinDateFrm frm = new CheckinDateFrm();
            frm.Parent = this.MdiParent;
            frm.TechID = Convert.ToInt16(dgvSubject.CurrentRow.Cells["TechID"].Value);
            frm.ShowDialog();
            dgvSubject_SelectionChanged(null, null);
        }

        private void dgvScore_SelectionChanged(object sender, EventArgs e)
        {
            //return;
        }

        private void dgvScore_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check each score must not over the setting value in score_rating
            int value = Convert.ToInt16(dgvScore.CurrentCell.Value);
            _db.SQLCommand = "SELECT * FROM score_rating";
            _db.Query();
            if (_db.Result.Read() == true)
            {
                int scoreSetting = 0;
                if (e.ColumnIndex == 5) // Mid
                {
                    scoreSetting = (int)_db.Result["mid"];
                    if (value > scoreSetting)
                    {
                        MessageBox.Show("ไม่สามารถใส่คะแนนเกิน " + scoreSetting.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScore.CurrentCell.Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == 6) // final
                {
                    scoreSetting = (int)_db.Result["final"];
                    if (value > scoreSetting)
                    {
                        MessageBox.Show("ไม่สามารถใส่คะแนนเกิน " + scoreSetting.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScore.CurrentCell.Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == 8) // score1
                {
                    scoreSetting = (int)_db.Result["score1"];
                    if (value > scoreSetting)
                    {
                        MessageBox.Show("ไม่สามารถใส่คะแนนเกิน " + scoreSetting.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScore.CurrentCell.Value = 0;
                        dgvScore.CurrentCell.Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == 9) // score2
                {
                    scoreSetting = (int)_db.Result["score2"];
                    if (value > scoreSetting)
                    {
                        MessageBox.Show("ไม่สามารถใส่คะแนนเกิน " + scoreSetting.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScore.CurrentCell.Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == 10) // score3
                {
                    scoreSetting = (int)_db.Result["score3"];
                    if (value > scoreSetting)
                    {
                        MessageBox.Show("ไม่สามารถใส่คะแนนเกิน " + scoreSetting.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScore.CurrentCell.Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == 11) // score4
                {
                    scoreSetting = (int)_db.Result["score4"];
                    if (value > scoreSetting)
                    {
                        MessageBox.Show("ไม่สามารถใส่คะแนนเกิน " + scoreSetting.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScore.CurrentCell.Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == 12) // score5
                {
                    scoreSetting = (int)_db.Result["score5"];
                    if (value > scoreSetting)
                    {
                        MessageBox.Show("ไม่สามารถใส่คะแนนเกิน " + scoreSetting.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvScore.CurrentCell.Value = 0;
                        return;
                    }
                }
            }
        }

        private void btnPrintCheckin_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DocumentName = "ใบเช็คชื่อวิชา " + (string)dgvSubject.CurrentRow.Cells["SubTitle"].Value;
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            PrintDialog dialog = new PrintDialog();
            dialog.Document = doc;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                doc.Print();
            }
        }

        private int idxRow = 0;
        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = 20, y = 10;
            Font fontTitle = new Font("Arial", 18);
            Font font = new Font("Arial", 14);

            // Title
            e.Graphics.DrawString("ใบเช็คชื่อวิชา " + (string)dgvSubject.CurrentRow.Cells["SubTitle"].Value, fontTitle, Brushes.Black, x, y);
            y = y + 40;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + 1120, y);

            // Header
            y = y + 5;
            e.Graphics.DrawString("ลำดับ", font, Brushes.Black, x, y);
            e.Graphics.DrawString("รหัส", font, Brushes.Black, x + 50, y);
            e.Graphics.DrawString("ชื่อ-นามสกุล", font, Brushes.Black, x + 180, y);
            // Print date header
            List<string> lstChkDate = new List<string>();
            _db.SQLCommand = "SELECT * FROM checkin_date WHERE tech_id='" + dgvSubject.CurrentRow.Cells["TechID"].Value.ToString() + "' ORDER BY date";
            _db.Query();
            int xx = 50;
            while (_db.Result.Read() == true)
            {
                e.Graphics.DrawString(_db.Result["date"].ToString().Substring(0, _db.Result["date"].ToString().Length - 5), font, Brushes.Black, x + 350 + xx, y);
                lstChkDate.Add((string)_db.Result["date"]);
                xx = xx + 70;
            }

            y = y + 25;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + 1120, y);

            y = y + 15;
            //foreach (DataGridViewRow item in dgvStudent.Rows)
            while (idxRow < dgvStudent.Rows.Count)
            {
                // Print order
                e.Graphics.DrawString(dgvStudent.Rows[idxRow].Cells[0].Value.ToString(), font, Brushes.Black, x, y);

                // Print student's id
                e.Graphics.DrawString(dgvStudent.Rows[idxRow].Cells[1].Value.ToString(), font, Brushes.Black, x + 50, y);

                // Print student's name
                e.Graphics.DrawString(dgvStudent.Rows[idxRow].Cells[2].Value.ToString(), font, Brushes.Black, x + 180, y);

                // Print date
                xx = 50;
                foreach (string item in lstChkDate)
                {
                    string imgName = "";
                    _db.SQLCommand = "SELECT * FROM checkin WHERE reg_id='" + dgvStudent.Rows[idxRow].Cells["RegID"].Value.ToString() + "' AND date='" + item + "'";
                    _db.Query();
                    if (_db.Result.Read() == true)
                    {
                        if ((string)_db.Result["status"] == "normal")
                        {
                            imgName = "normal.png";
                        }
                        else if ((string)_db.Result["status"] == "late")
                        {
                            imgName = "late.png";
                        }
                        else if ((string)_db.Result["status"] == "absence")
                        {
                            imgName = "absence.png";
                        }
                        //e.Graphics.DrawImage(LoadImage(imgName), x + 360 + xx, y);
                    }
                    else
                    {
                        imgName = "uncheck2.png";
                    }
                    e.Graphics.DrawImage(LoadImage(imgName), x + 360 + xx, y);
                    xx = xx + 70;
                }

                idxRow++;
                y = y + 25;
                if (y > 780)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            idxRow = 0;
            e.HasMorePages = false;
        }

        private void btnPrintScore_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DocumentName = "ใบเช็คชื่อวิชา " + (string)dgvSubject.CurrentRow.Cells["SubTitle"].Value;
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage +=new PrintPageEventHandler(doc_PrintPage2);

            PrintDialog dialog = new PrintDialog();
            dialog.Document = doc;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                doc.Print();
            }
        }

        void doc_PrintPage2(object sender, PrintPageEventArgs e)
        {
            int x = 20, y = 10;
            Font fontTitle = new Font("Arial", 18);
            Font font = new Font("Arial", 14);

            // Title
            e.Graphics.DrawString("คะแนนวิชา " + (string)dgvSubject.CurrentRow.Cells["SubTitle"].Value, fontTitle, Brushes.Black, x, y);
            y = y + 40;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + 1120, y);

            // Header
            y = y + 5;
            e.Graphics.DrawString("ลำดับ", font, Brushes.Black, x, y);
            e.Graphics.DrawString("รหัส", font, Brushes.Black, x + 50, y);
            e.Graphics.DrawString("ชื่อ-นามสกุล", font, Brushes.Black, x + 180, y);
            e.Graphics.DrawString("กลาง", font, Brushes.Black, x + 350, y);
            e.Graphics.DrawString("ปลาย", font, Brushes.Black, x + 430, y);
            e.Graphics.DrawString("เช็คชื่อ", font, Brushes.Black, x + 510, y);
            e.Graphics.DrawString("เก็บ 1", font, Brushes.Black, x + 580, y);
            e.Graphics.DrawString("เก็บ 2", font, Brushes.Black, x + 660, y);
            e.Graphics.DrawString("เก็บ 3", font, Brushes.Black, x + 740, y);
            e.Graphics.DrawString("เก้บ 4", font, Brushes.Black, x + 820, y);
            e.Graphics.DrawString("เก้บ 5", font, Brushes.Black, x + 900, y);
            e.Graphics.DrawString("รวม", font, Brushes.Black, x + 980, y);
            e.Graphics.DrawString("เกรด", font, Brushes.Black, x + 1050, y);

            y = y + 25;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + 1120, y);

            y = y + 15;
            while (idxRow < dgvScore.Rows.Count)
            {
                int xx = 20;

                // Print order
                e.Graphics.DrawString(dgvStudent.Rows[idxRow].Cells[0].Value.ToString(), font, Brushes.Black, x, y);

                // Print student's id
                e.Graphics.DrawString(dgvStudent.Rows[idxRow].Cells[1].Value.ToString(), font, Brushes.Black, x + 50, y);

                // Print student's name
                e.Graphics.DrawString(dgvStudent.Rows[idxRow].Cells[2].Value.ToString(), font, Brushes.Black, x + 180, y);

                string reg_id = dgvScore.Rows[idxRow].Cells["RegID"].Value.ToString();
                _db.SQLCommand = "SELECT * FROM score WHERE reg_id='" + reg_id + "'";
                _db.Query();
                if (_db.Result.Read() == true)
                {
                    e.Graphics.DrawString(_db.Result["mid"].ToString(), font, Brushes.Black, x + 350 + xx, y);
                    xx = xx + 80;
                    e.Graphics.DrawString(_db.Result["final"].ToString(), font, Brushes.Black, x + 350 + xx, y);
                    int checkinScore = GetCheckinScore(Convert.ToString(dgvSubject.CurrentRow.Cells["TechID"].Value), reg_id);
                    xx = xx + 80;
                    e.Graphics.DrawString(checkinScore.ToString(), font, Brushes.Black, x + 350 + xx, y);
                    xx = xx + 80;
                    e.Graphics.DrawString(_db.Result["score1"].ToString(), font, Brushes.Black, x + 350 + xx, y);
                    xx = xx + 80;
                    e.Graphics.DrawString(_db.Result["score2"].ToString(), font, Brushes.Black, x + 350 + xx, y);
                    xx = xx + 80;
                    e.Graphics.DrawString(_db.Result["score3"].ToString(), font, Brushes.Black, x + 350 + xx, y);
                    xx = xx + 80;
                    e.Graphics.DrawString(_db.Result["score4"].ToString(), font, Brushes.Black, x + 350 + xx, y);
                    xx = xx + 80;
                    e.Graphics.DrawString(_db.Result["score5"].ToString(), font, Brushes.Black, x + 350 + xx, y);
                    int sum = 0;
                    sum = sum + (int)_db.Result["mid"];
                    sum = sum + (int)_db.Result["final"];
                    sum = sum + (int)_db.Result["score1"];
                    sum = sum + (int)_db.Result["score2"];
                    sum = sum + (int)_db.Result["score3"];
                    sum = sum + (int)_db.Result["score4"];
                    sum = sum + (int)_db.Result["score5"];
                    sum = sum + checkinScore;
                    xx = xx + 60;
                    e.Graphics.DrawString(sum.ToString(), font, Brushes.Black, x + 350 + xx, y);
                    string grade = "";
                    grade = GetGradeFromScore(sum);
                    xx = xx + 70;
                    e.Graphics.DrawString(grade, font, Brushes.Black, x + 350 + xx, y);
                }

                idxRow++;
                y = y + 25;
                if (y > 780)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            idxRow = 0;
            e.HasMorePages = false;
        }
    }
}
