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
        private MySQLDatabase _db = null;

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
                MessageBox.Show("You must enter username and password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check login.
            string cmd = "SELECT * FROM teacher WHERE tech_username='" + txtUsername.Text + "' AND tech_password='" + txtPassword.Text + "'";
            _db.SQLCommand = cmd;
            _db.Query();

            // If no any rows return back, so login is failed.
            if (_db.Result.HasRows == false)
            {
                MessageBox.Show("Login failed. Maybe username or password is not correct.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                return;
            }

            LoginOK = true;
            Username = txtUsername.Text;

            // If everything is OK, close this login form.
            ((MainFrm)this.MdiParent).AlreadyLogin(Username);
            this.Close();
        }
    }
}
