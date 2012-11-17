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
        private string _year = null;
        private string _subjectCode = null;
        private string _subjectName = null;
        private List<Student> _lstStd = new List<Student>();

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
                ParseCSVFile();
                txtSubjectCode.Text = _subjectCode;
                txtSubjectName.Text = _subjectName;
            }
        }

        private void ParseCSVFile()
        {
            string line;
            string[] cols;
            
            StreamReader sr = new StreamReader(txtCSVFile.Text);
            // Flush
            line = sr.ReadLine();
            // Get year
            line = sr.ReadLine();
            cols = line.Split(',');
            _year = cols[0].Substring(cols[0].IndexOf("25"), 4);
            // Get Subject code and Subject Name
            line = sr.ReadLine();
            cols = line.Split(',');
            cols[0] = cols[0].Replace("รหัสวิชา ", "");
            cols[0] = cols[0].Substring(0, cols[0].Length - cols[0].IndexOf(" จำนวน") - 6);
            _subjectCode = cols[0].Substring(0, 8);
            _subjectName = cols[0].Substring(cols[0].IndexOf(' ') + 1);
            // Get student
            line = sr.ReadLine();
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                string[] cell = line.Split(',');
                string stdID = cell[1];
                string stdName = cell[2];
                string stdMajor = cell[3];
                stdName = stdName.Replace("นาย", "");
                stdName = stdName.Replace("นางสาว", "");
                dgv.Rows.Add(stdID, stdName, stdMajor);
                _lstStd.Add(new Student { ID = stdID, Name = stdName, Major = stdMajor });
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
            dgv.ColumnCount = 3;
            dgv.Columns[0].HeaderText = "รหัสนิสิต";
            dgv.Columns[1].HeaderText = "ชื่อ-นามสกุล";
            dgv.Columns[1].Width = 460;
            dgv.Columns[2].HeaderText = "สาขา";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Subject
            // Check the record is already exist.
            _db.SQLCommand = "SELECT * FROM subject WHERE sub_id='" + _subjectCode + "'";
            _db.Query();
            if (_db.Result.HasRows)
            {
                // Update
                _db.SQLCommand = "UPDATE subject SET ";
                _db.SQLCommand += "sub_title='" + _subjectName + "' ";
                _db.SQLCommand += "WHERE sub_id='" + _subjectCode + "'";
            }
            else
            {
                // Insert
                _db.SQLCommand = "INSERT INTO subject (sub_id, sub_title) VALUES ('" + _subjectCode + "', '" + _subjectName + "')";
            }

            if (_db.Query() == false)
            {
                MessageBox.Show("ไม่สามารถนำเข้าข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                _db.SQLCommand = "SELECT * FROM registration WHERE std_id='" + item.ID + "' AND sub_id='" + _subjectCode + "'";
                _db.Query();
                if (_db.Result.HasRows)
                {
                    // Update
                    _db.SQLCommand = "UPDATE registration SET ";
                    _db.SQLCommand += "sub_id='" + _subjectCode + "', ";
                    _db.SQLCommand += "std_id='" + item.ID + "', ";
                    _db.SQLCommand += "year='" + _year + "' ";
                    _db.SQLCommand += "WHERE sub_id='" + _subjectCode + "' AND std_id='" + item.ID + "' AND year='" + _year + "'";
                }
                else
                {
                    // Insert
                    _db.SQLCommand = "INSERT INTO registration (sub_id, std_id, year) VALUES ('" + _subjectCode + "', '" + item.ID + "', '" + _year + "')";
                }

                _db.Query();
            }

            MessageBox.Show("นำเข้าข้อมูลเสร็จเรียบร้อย", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
    }
}
