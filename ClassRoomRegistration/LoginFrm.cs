using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Database;
using Config;

namespace ClassRoomRegistration
{
    public partial class LoginFrm : Form
    {
        public bool LoginOK { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
        public MySQLDatabase _db = null;

        public LoginFrm()
        {
            InitializeComponent();
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            _db = ((MainFrm)this.MdiParent)._db;
            LoginOK = false;
        }

        private void LoginFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check empty textbox
            if (txtUsername.Text == "" || txtPassword.Text =="")
            {
                MessageBox.Show("ไม่ได้ใส่ข้อมูลชื่อผู้ใช้หรือรหัสผ่าน", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check login.
            string cmd = "SELECT tech_username, tech_password, tech_type, tech_id FROM teacher WHERE tech_username='" + txtUsername.Text + "' AND tech_password='" + txtPassword.Text + "'";
            _db.SQLCommand = cmd;
            _db.Query();

            // If no any rows return back, so login is failed.
            if (_db.Result.HasRows == false)
            {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
                return;
            }

            _db.Result.Read();

            LoginOK = true;
            Username = txtUsername.Text;
            Type = (string)_db.Result.GetValue(2);

            // If everything is OK, close this login form.
            ((MainFrm)this.MdiParent).AlreadyLogin(_db.Result.GetValue(3).ToString(), Username, Type);
            this.Close();
        }

        private void txtForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("ต้องใส่ชื่อผู้ใช้งานเพื่อถามคำถาม", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ForgetPasswordFrm frm = new ForgetPasswordFrm();
            frm.Parent = this;
            frm.Username = txtUsername.Text;
            frm.ShowDialog();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidateInput.CheckAllowKeyCharNumber((int)e.KeyChar) == false)
            {
                MessageBox.Show("ใส่ได้เฉพาะตัวเลขและตัวอักษรเท่านั้น");
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidateInput.CheckAllowKeyCharNumber((int)e.KeyChar) == false)
            {
                MessageBox.Show("ใส่ได้เฉพาะตัวเลขและตัวอักษรเท่านั้น");
                e.Handled = true;
            }
        }
    }
}
