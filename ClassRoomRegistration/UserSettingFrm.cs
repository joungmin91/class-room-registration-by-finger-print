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
    public partial class UserSettingFrm : Form
    {
        public string TechID { get; set; }
        public Form Parent { get; set; }
        private MySQLDatabase _db = null;

        public UserSettingFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserSettingFrm_Load(object sender, EventArgs e)
        {
            _db = ((MainFrm)Parent)._db;
            _db.SQLCommand = "SELECT * FROM teacher WHERE tech_id='" + TechID + "'";
            _db.Query();
            _db.Result.Read();

            txtName.Text = (string)_db.Result.GetValue(1);
            txtUsername.Text = (string)_db.Result.GetValue(3);
            txtPassword.Text = (string)_db.Result.GetValue(4);
            cmbQuestion.Text = (string)_db.Result.GetValue(7);
            txtAnswer.Text = (string)_db.Result.GetValue(8);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check required field.
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || cmbQuestion.Text == "" || txtAnswer.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the record.
            _db.SQLCommand = "UPDATE teacher SET ";
            _db.SQLCommand += "tech_name='" + txtName.Text + "', ";
            _db.SQLCommand += "tech_username='" + txtUsername.Text + "', ";
            _db.SQLCommand += "tech_password='" + txtPassword.Text + "', ";
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
    }
}
