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
        private string _tech_id = null;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            InitApp();
            InitDatabase();
            ShowLogin();
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
                    MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Controls.Remove(mainToolbar);
            this.Controls.Remove(teachToolbar);
        }

        private void EnableMenu()
        {
            mainMenu.Enabled = true;
        }

        private void AdminLogin()
        {
            this.Controls.Add(mainToolbar);
            this.Controls.Remove(teachToolbar);
            this.Controls.Add(mainMenu);
        }

        private void TeacherLogin()
        {
            this.Controls.Remove(mainToolbar);
            this.Controls.Add(teachToolbar);
            this.Controls.Add(mainMenu);
        }

        public void AlreadyLogin(string tech_id, string username, string type)
        {
            _username = username;
            _tech_id = tech_id;
            this.Text = this.Text + " [User: " + _username + "]";
            if (type == "admin")
            {
                // Admin mode
                EnableMenu();
                AdminLogin();

                AdminScreenFrm frm = new AdminScreenFrm();
                frm.MdiParent = this;
                frm.Server = _db.DBServer;
                frm.Username = _db.DBUser;
                frm.DBName = _db.DBName;
                frm.Show();
                _lstFrm.Add(frm);
            }
            else
            {
                // User mode
                EnableMenu();
                TeacherLogin();

                TeacherScreenFrm frm = new TeacherScreenFrm();
                frm.MdiParent = this;
                frm.Server = _db.DBServer;
                frm.Username = _db.DBUser;
                frm.DBName = _db.DBName;
                frm.Show();
                _lstFrm.Add(frm);
            }
        }

        private void Logout()
        {
            foreach (Form item in _lstFrm)
            {
                item.Close();
            }
            this.Text = "ระบบลงทะเบียนเข้าเรียนนิสิต";
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

        private void ShowTeachingFrm()
        {
            TeachingFrm frm = new TeachingFrm();
            frm.MdiParent = this;
            frm.Show();
            _lstFrm.Add(frm);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ShowTeachingFrm();
        }

        private void toolStripButtonCheckin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("รอการพัฒนา");
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigFrm frm = new ConfigFrm();
            frm.ShowDialog();
        }

        private void toolStripButtonRegister_Click(object sender, EventArgs e)
        {
            RegistationFrm frm = new RegistationFrm();
            frm.MdiParent = this;
            frm.Show();
            _lstFrm.Add(frm);
        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            UserSettingFrm frm = new UserSettingFrm();
            frm.TechID = _tech_id;
            frm.Parent = this;
            frm.ShowDialog();
        }

        private void toolStripButtonTechSubject_Click(object sender, EventArgs e)
        {
            TeachingViewFrm frm = new TeachingViewFrm();
            frm.MdiParent = this;
            frm.TechID = _tech_id;
            frm.Show();
            _lstFrm.Add(frm);
        }
    }
}
