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

namespace ClassRoomRegistration
{
    public partial class ImportDataFrm : Form
    {
        private MySQLDatabase _db = null;
        private List<Student> _lstStd = new List<Student>();
        private ImportDataFile _file = null;
        private int _techID;

        public ImportDataFrm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Filter = "csv files (*.csv)|*.csv";
            frm.Title = "Select data .csv file to be imported";
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dgv.Rows.Clear();
                txtCSVFile.Text = frm.FileName;
                _file = new ImportDataFile(txtCSVFile.Text);
                txtSubjectID.Text = _file.SubjectID;
                txtSubjectName.Text = _file.SubjectName;
                txtLecID.Text = _file.LectureID;
                txtLabID.Text = _file.LabID;
                txtYear.Text = _file.Year;
                txtTerm.Text = _file.Term;
                _lstStd = _file.Students;
                txtTechName.Text = "";
                // Load DataGrid
                int i = 1;
                foreach (Student item in _lstStd)
                {
                    // order, student_id, student_name, student_major
                    dgv.Rows.Add(i++, item.ID, item.Name, item.Major);
                }
            }
        }

        private void ImportDataFrm_Load(object sender, EventArgs e)
        {
            // Setup database
            _db = ((MainFrm)this.MdiParent)._db;
            // Setup DGV
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 4;
            dgv.Columns[0].HeaderText = "ลำดับ";
            dgv.Columns[0].Width = 30;
            dgv.Columns[1].HeaderText = "รหัสนิสิต";
            dgv.Columns[2].HeaderText = "ชื่อ-นามสกุล";
            dgv.Columns[2].Width = 460;
            dgv.Columns[3].HeaderText = "สาขา";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            _db.SQLCommand = "SELECT * FROM subject s JOIN teaching t ON s.id = t.sub_id WHERE s.sub_id = '" + txtSubjectID.Text + "' AND s.sub_lec='" + txtLecID.Text + "' AND s.sub_lab='" + txtLabID.Text + "' AND t.year='" + txtYear.Text + "' AND t.term='" + txtTerm.Text + "'";
            _db.Query();
            if (_db.Result.HasRows)
            {
                MessageBox.Show("ข้อมูลรายวิชานี้มีในฐานข้อมูลอยู่แล้ว");
                return;
            }

            // Subject
            // Check the record is already exist.
            _db.SQLCommand = "SELECT * FROM subject WHERE sub_id='" + txtSubjectID.Text + "' AND sub_lec='" + txtLecID.Text + "' AND sub_lab='" + txtLabID.Text + "'";
            _db.Query();
            if (_db.Result.HasRows)
            {
                // Update
                //_db.SQLCommand = "UPDATE subject SET ";
                //_db.SQLCommand += "sub_title='" + txtSubjectName.Text + "', ";
                //_db.SQLCommand += "sub_lec='" + txtLecID.Text + "', ";
                //_db.SQLCommand += "sub_lab='" + txtLabID.Text + "' ";
                //_db.SQLCommand += "WHERE sub_id='" + txtSubjectID.Text + "'";
            }
            else
            {
                // Insert
                _db.SQLCommand = "INSERT INTO subject (sub_id, sub_title, sub_lec, sub_lab) VALUES ('" + txtSubjectID.Text + "', '" + txtSubjectName.Text + "', '" + txtLecID.Text + "', '" + txtLabID.Text + "')";
                _db.Query();
            }

            //if (_db.Query() == false)
            //{
            //    MessageBox.Show("ไม่สามารถนำเข้าข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            // Get subject id
            _db.SQLCommand = "SELECT id FROM subject WHERE sub_id='" + txtSubjectID.Text + "' AND sub_lec='" + txtLecID.Text + "' AND sub_lab='" + txtLabID.Text + "'";
            _db.Query();
            _db.Result.Read();
            int id = (int)_db.Result["id"];
            string subCode = id.ToString();

            // Student
            foreach (Student item in _lstStd)
            {
                _db.SQLCommand = "SELECT * FROM student WHERE std_id='" + item.ID + "'";
                _db.Query();
                if (_db.Result.HasRows)
                {
                    // Update
                    _db.SQLCommand = "UPDATE student SET ";
                    _db.SQLCommand += "std_name='" + item.Name + "', ";
                    _db.SQLCommand += "std_major='" + item.Major + "' ";
                    _db.SQLCommand += "WHERE std_id='" + item.ID + "'";
                }
                else
                {
                    // Insert
                    _db.SQLCommand = "INSERT INTO student (std_id, std_name, std_major, std_fp_key) VALUES ('" + item.ID + "', '" + item.Name + "', '" + item.Major + "', '')";
                }

                _db.Query();

                // Registration
                _db.SQLCommand = "SELECT * FROM registration WHERE std_id='" + item.ID + "' AND sub_id='" + subCode + "' AND year='" + txtYear.Text + "' AND term='" + txtTerm.Text + "'";
                _db.Query();
                if (_db.Result.HasRows == false)
                {
                    // Insert
                    _db.SQLCommand = "INSERT INTO registration (sub_id, std_id, year, term) VALUES ('" + subCode + "', '" + item.ID + "', '" + txtYear.Text + "', '" + txtTerm.Text + "')";
                    _db.Query();
                }
            }

            // Manage teaching data
            _db.SQLCommand = "SELECT * FROM teaching WHERE tech_id='" + _techID + "' AND sub_id='" + subCode + "' AND year='" + txtYear.Text + "' AND term='" + txtTerm.Text + "'";
            _db.Query();
            if (_db.Result.HasRows == false)
            {
                // Insert
                _db.SQLCommand = "INSERT INTO teaching (tech_id, sub_id, year, term) VALUES ('" + _techID + "', '" + subCode + "', '" + txtYear.Text + "', '" + txtTerm.Text + "')";
            }

            if (_db.Query() == false)
            {
                MessageBox.Show("ไม่สามารถนำเข้าข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("นำเข้าข้อมูลเสร็จเรียบร้อย", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            TeacherPopUp frm = new TeacherPopUp();
            frm.Parent = this.MdiParent;
            frm.ShowDialog();
            _techID = frm.TechID;
            txtTechName.Text = frm.TechName;
            frm.Close();
        }
    }
}
