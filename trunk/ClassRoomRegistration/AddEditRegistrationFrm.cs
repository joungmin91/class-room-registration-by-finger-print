using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Database;

namespace ClassRoomRegistration
{
    public partial class AddEditRegistrationFrm : Form
    {
        public Form Parent { get; set; }
        public string RegID { get; set; }
        public bool EditMode { get; set; }
        private MySQLDatabase _db = null;
        private List<Subject> _lstSubject = new List<Subject>();

        public AddEditRegistrationFrm()
        {
            InitializeComponent();
        }

        private void AddEcitRegistrationFrm_Load(object sender, EventArgs e)
        {
            // Init database
            _db = ((MainFrm)Parent)._db;

            // For branch combobox
            _db.SQLCommand = "SELECT * FROM subject";
            _db.Query();
            while (_db.Result.Read())
            {
                cmbSubName.Items.Add((string)_db.Result.GetValue(1));
                _lstSubject.Add(new Subject { SubjectID = (string)_db.Result.GetValue(0), SubjectName = (string)_db.Result.GetValue(1) });
            }

            // For Edit mode
            if (EditMode == true)
            {
                // Diable object
                txtStdID.Enabled = false;
                cmbYear.Enabled = false;

                // Retrieve data
                _db.SQLCommand = "SELECT * FROM registration WHERE reg_id='" + RegID + "'";
                _db.Query();
                if (_db.Result.HasRows)
                {
                    _db.Result.Read();
                    txtSubID.Text = (string)_db.Result.GetValue(1);
                    cmbSubName.Text = LookupSubjectName((string)_db.Result.GetValue(1));
                    txtStdID.Text = (string)_db.Result.GetValue(2);
                    cmbYear.Text = (string)_db.Result.GetValue(3);

                    // For student name
                    _db.SQLCommand = "SELECT std_name FROM student WHERE std_id='" + txtStdID.Text + "'";
                    _db.Query();
                    _db.Result.Read();
                    txtStdName.Text = (string)_db.Result.GetValue(0);
                }
            }
        }

        private string LookupSubjectName(string subID)
        {
            foreach (Subject item in _lstSubject)
            {
                if (item.SubjectID == subID)
                {
                    return item.SubjectName;
                }
            }
            return "";
        }

        private string LookupSubjectID(string subName)
        {
            foreach (Subject item in _lstSubject)
            {
                if (item.SubjectName == subName)
                {
                    return item.SubjectID;
                }
            }
            return "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check required field.
            if (txtSubID.Text == "" || cmbSubName.Text == "" || txtStdID.Text == "" || txtStdName.Text == "" || cmbYear.Text == "")
            {
                MessageBox.Show("ข้อมูลไม่ครบ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (EditMode == true)
            {
                // Update the record.
                _db.SQLCommand = "UPDATE registration SET ";
                _db.SQLCommand += "sub_id='" + txtSubID.Text + "' ";
                _db.SQLCommand += "WHERE reg_id='" + RegID + "' ";
                if (_db.Query() == true)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้, SQL = " + _db.SQLCommand, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Insert the record.
                _db.SQLCommand = "INSERT INTO registration (sub_id, std_id, year) VALUES ('" + txtSubID.Text + "', '" + txtStdID.Text + "', '" + cmbYear.Text + "')";
                if (_db.Query() == true)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้, SQL = " + _db.SQLCommand, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbSubName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubID.Text = LookupSubjectID(cmbSubName.Text);
        }

        private void txtStdID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _db.SQLCommand = "SELECT std_name FROM student WHERE std_id='" + txtStdID.Text + "'";
                _db.Query();
                _db.Result.Read();
                txtStdName.Text = (string)_db.Result.GetValue(0);
            }
        }
    }

    public class Subject
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
