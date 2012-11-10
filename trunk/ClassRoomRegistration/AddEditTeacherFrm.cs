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
        private AxZKFPEngX _fpEngine = null;
        private int _cntFPEnroll = 0;
        private bool _enrollMode = false;


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

            // Init FP engine
            _fpEngine = new AxZKFPEngX();
            _fpEngine.BeginInit();
            _fpEngine.OnEnroll += new IZKFPEngXEvents_OnEnrollEventHandler(_fpEngine_OnEnroll);
            _fpEngine.OnImageReceived += new IZKFPEngXEvents_OnImageReceivedEventHandler(_fpEngine_OnImageReceived);
            this.Controls.Add(_fpEngine);

            if (_fpEngine.InitEngine() != 0)
            {
                MessageBox.Show("Cannot connect to finger scan device.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // For Edit mode
            if (EditMode == true)
            {
                _db.SQLCommand = "SELECT * FROM teacher WHERE tech_id='" + TechID + "'";
                _db.Query();
                if (_db.Result.HasRows)
                {
                    _db.Result.Read();
                    txtFName.Text = (string)_db.Result.GetValue(1);
                    txtLName.Text = (string)_db.Result.GetValue(2);
                    txtAddr.Text = (string)_db.Result.GetValue(3);
                    txtPhone.Text = (string)_db.Result.GetValue(4);
                    txtUsername.Text = (string)_db.Result.GetValue(5);
                    txtPassword.Text = (string)_db.Result.GetValue(6);
                    txtFinger.Text = (string)_db.Result.GetValue(7);
                    cmbType.Text = (string)_db.Result.GetValue(8);
                }
            }
        }

        void _fpEngine_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            if (_enrollMode == true)
            {
                _fpEngine.PrintImageAt((int)picFP.CreateGraphics().GetHdc().ToInt64(), 0, 0, 100, 100);
                _cntFPEnroll++;
                txtFPNo.Text = _cntFPEnroll.ToString(); 
            }
        }

        void _fpEngine_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            txtFinger.Text = _fpEngine.GetTemplateAsString();
            txtFPStatus.Text = "Completed";
            _cntFPEnroll = 0;
            _enrollMode = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check required field.
            if (txtFName.Text == "" || txtLName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || cmbType.Text == "")
            {
                MessageBox.Show("You must fill all required field.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EditMode == true)
            {
                // Update the record.
                _db.SQLCommand = "UPDATE teacher SET ";
                _db.SQLCommand += "tech_fname='" + txtFName.Text + "', ";
                _db.SQLCommand += "tech_lname='" + txtLName.Text +"', ";
                _db.SQLCommand += "tech_addr='" + txtAddr.Text +"', ";
                _db.SQLCommand += "tech_phone='" + txtPhone.Text +"', ";
                _db.SQLCommand += "tech_username='" + txtUsername.Text +"', ";
                _db.SQLCommand += "tech_password='" + txtPassword.Text +"', ";
                _db.SQLCommand += "tech_fp_key='" + txtFinger.Text +"', ";
                _db.SQLCommand += "tech_type='" + cmbType.Text +"' ";
                _db.SQLCommand += "WHERE tech_id='" + TechID + "' ";
                if (_db.Query() == true)
                {
                    MessageBox.Show("Record has been updated into database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Record cannot be updated into database. SQL = " + _db.SQLCommand, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Insert the record.
                _db.SQLCommand = "INSERT INTO teacher (tech_fname, tech_lname, tech_addr, tech_phone, tech_username, tech_password, tech_fp_key, tech_type) VALUES ('" + txtFName.Text + "', '" + txtLName.Text + "', '" + txtAddr.Text + "', '" + txtPhone.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "', '', '" + cmbType.Text + "')";
                if (_db.Query() == true)
                {
                    MessageBox.Show("Record has been inserted into database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Record cannot be inserted into database. SQL = " + _db.SQLCommand, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFingerEnroll_Click(object sender, EventArgs e)
        {
            _fpEngine.BeginEnroll();
            _enrollMode = true;
            txtFPStatus.Text = "Stamp 3 times";
            txtFPNo.Text = _cntFPEnroll.ToString();
        }

        private void AddEditTeacherFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _fpEngine.EndInit();
            _fpEngine.EndEngine();
        }
    }
}
