using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Database;
using AxZKFPEngXControl;

namespace ClassRoomRegistration
{
    public partial class AddEditTeacherFrm : Form
    {
        public Form Parent { get; set; }
        public bool EditMode { get; set; }
        public string TechID { get; set; }
        private MySQLDatabase _db = null;
        private List<Branch> _lstBrch = new List<Branch>();

        public AddEditTeacherFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditTeacherFrm_Load(object sender, EventArgs e)
        {
            // Init database
            _db = ((MainFrm)Parent)._db;

            // For branch combobox
            _db.SQLCommand = "SELECT * FROM teacher_branch";
            _db.Query();
            while (_db.Result.Read())
            {
                cmbBrch.Items.Add((string)_db.Result.GetValue(1));
                _lstBrch.Add(new Branch { BranchID = (string)_db.Result.GetValue(0), BranchName = (string)_db.Result.GetValue(1) });
            }
            
            // For Edit mode
            if (EditMode == true)
            {
                _db.SQLCommand = "SELECT * FROM teacher WHERE tech_id='" + TechID + "'";
                _db.Query();
                if (_db.Result.HasRows)
                {
                    _db.Result.Read();
                    txtName.Text = (string)_db.Result.GetValue(1);
                    cmbBrch.Text = LookupBranchName((string)_db.Result.GetValue(2));
                    txtUsername.Text = (string)_db.Result.GetValue(3);
                    txtPassword.Text = (string)_db.Result.GetValue(4);
                    cmbQuestion.Text = (string)_db.Result.GetValue(7);
                    txtAnswer.Text = (string)_db.Result.GetValue(8);
                }
            }
        }

        private string LookupBranchName(string brchID)
        {
            foreach (Branch item in _lstBrch)
            {
                if (item.BranchID == brchID)
                {
                    return item.BranchName;
                }
            }
            return "";
        }

        private string LookupBrachID(string brchName)
        {
            foreach (Branch item in _lstBrch)
            {
                if (item.BranchName == brchName)
                {
                    return item.BranchID;
                }
            }
            return "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check required field.
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || cmbQuestion.Text == "" || txtAnswer.Text == "")
            {
                MessageBox.Show("ข้อมูลไม่ครบ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert the record.
            string mode = "user";
            if (txtName.Text == "admin")
            {
                mode = "admin";
            }

            if (EditMode == true)
            {
                // Update the record.
                _db.SQLCommand = "UPDATE teacher SET ";
                _db.SQLCommand += "tech_name='" + txtName.Text + "', ";
                _db.SQLCommand += "tech_branch='" + LookupBrachID(cmbBrch.Text) + "', ";
                _db.SQLCommand += "tech_username='" + txtUsername.Text +"', ";
                _db.SQLCommand += "tech_password='" + txtPassword.Text +"', ";
                _db.SQLCommand += "tech_type='" + mode + "', ";
                _db.SQLCommand += "tech_question='" + cmbQuestion.Text + "', ";
                _db.SQLCommand += "tech_answer='" + txtAnswer.Text + "' ";
                _db.SQLCommand += "WHERE tech_id='" + TechID + "' ";
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
                _db.SQLCommand = "INSERT INTO teacher (tech_name, tech_branch, tech_username, tech_password, tech_fp_key, tech_type, tech_question, tech_answer) VALUES ('" + txtName.Text + "', '" + LookupBrachID(cmbBrch.Text) + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "', '', '" + mode + "', '" + cmbQuestion.Text + "', '" + txtAnswer.Text + "')";
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

        private void AddEditTeacherFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void cmbBrch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

    public class Branch
    {
        public string BranchID { get; set; }
        public string BranchName { get; set; }
    }
}
