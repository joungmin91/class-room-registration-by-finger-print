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
    public partial class MainFrm : Form
    {
        public MySQLDatabase _db = new MySQLDatabase();
        private XMLConfig _config = new XMLConfig();
        private List<Form> _lstFrm = new List<Form>();
        private string _username = null;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            InitApp();
            InitDatabase();
            //ShowLogin();
        }

        private void InitApp()
        {
            this.KeyPreview = true;
        }

        private void InitDatabase()
        {
            // Load config.
            _config.Load("app-config.xml");
            _db.DBServer = _config.Query("//db-server");
            _db.DBUser = _config.Query("//db-username");
            _db.DBPassword = _config.Query("//db-password");
            _db.DBName = _config.Query("//db-dbname");

            try
            {
                // Connect to MySQL Server
                if (_db.Connect() == false)
                {
                    MessageBox.Show("Cannot connect to database server.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableMenu();
            }
        }

        private void DisableMenu()
        {
            mainMenu.Enabled = false;
            mainToolbar.Enabled = false;
        }

        private void EnableMenu()
        {
            mainMenu.Enabled = true;
            mainToolbar.Enabled = true;
        }

        public void AlreadyLogin(string username)
        {
            _username = username;
            this.Text = this.Text + " [User: " + _username + "]";
            EnableMenu();
        }

        private void Logout()
        {
            foreach (Form item in _lstFrm)
            {
                item.Close();
            }
            this.Text = "KU Class Room Registration";
            ShowLogin();
        }

        private void ShowLogin()
        {
            DisableMenu();
            LoginFrm login = new LoginFrm();
            login.MdiParent = this;
            login.WindowState = FormWindowState.Normal;
            login.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowTeacherFrm()
        {
            TeacherFrm frm = new TeacherFrm();
            frm.MdiParent = this;
            frm.Show();
            _lstFrm.Add(frm);
        }

        private void toolStripButtonTeacher_Click(object sender, EventArgs e)
        {
            ShowTeacherFrm();
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _db.Close();
        }

        private void MainFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.T)
            {
                ShowTeacherFrm();
            }
            else if (e.Control == true && e.KeyCode == Keys.I)
            {
                ShowImportFrm();
            }
            else if (e.Control == true && e.KeyCode == Keys.S)
            {
                ShowStudentFrm();
            }
            else if (e.Control == true && e.KeyCode == Keys.J)
            {
                ShowSubjectFrm();
            }
        }

        private void ShowImportFrm()
        {
            ImportDataFrm frm = new ImportDataFrm();
            frm.MdiParent = this;
            frm.Show();
            _lstFrm.Add(frm);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ShowImportFrm();
        }

        private void ShowSubjectFrm()
        {
            SubjectFrm frm = new SubjectFrm();
            frm.MdiParent = this;
            frm.Show();
            _lstFrm.Add(frm);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowSubjectFrm();
        }

        private void ShowStudentFrm()
        {
            StudentFrm frm = new StudentFrm();
            frm.MdiParent = this;
            frm.Show();
            _lstFrm.Add(frm);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowStudentFrm();
        }
    }
}
