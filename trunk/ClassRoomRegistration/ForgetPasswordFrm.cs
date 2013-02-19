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
    public partial class ForgetPasswordFrm : Form
    {
        public Form Parent { get; set; }
        public string Username { get; set; }
        private string _answer = null;
        private string _password = null;
        private MySQLDatabase _db = null;

        public ForgetPasswordFrm()
        {
            InitializeComponent();
        }

        private void ForgetPasswordFrm_Load(object sender, EventArgs e)
        {
            _db = ((LoginFrm)Parent)._db;
            _db.SQLCommand = "SELECT tech_question, tech_answer, tech_password FROM teacher WHERE tech_username='" + Username + "'";
            _db.Query();
            _db.Result.Read();
            txtQuestion.Text = (string)_db.Result.GetValue(0);
            _answer = (string)_db.Result.GetValue(1);
            _password = (string)_db.Result.GetValue(2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text != _answer)
            {
                MessageBox.Show("คำตอบของคุณไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnswer.Text = "";
                return;
            }

            MessageBox.Show("รหัสผ่านของคุณคือ  ==> " + _password, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
