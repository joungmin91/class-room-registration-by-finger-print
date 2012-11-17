using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassRoomRegistration
{
    public partial class TeacherScreenFrm : Form
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string DBName { get; set; }

        public TeacherScreenFrm()
        {
            InitializeComponent();
        }

        private void TeacherScreenFrm_Load(object sender, EventArgs e)
        {
            txtServer.Text = Server;
            txtUsername.Text = Username;
            txtDBName.Text = DBName;
        }

        private void TeacherScreenFrm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}
