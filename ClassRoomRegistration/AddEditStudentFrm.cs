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
    public partial class AddEditStudentFrm : Form
    {
        public Form Parent { get; set; }
        public bool EditMode { get; set; }
        public string StudentID { get; set; }
        private MySQLDatabase _db = null;
        private AxZKFPEngX _fpEngine = null;
        private int _cntFPEnroll = 0;
        private bool _enrollMode = false;

        public AddEditStudentFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check required field.
            if (txtStdID.Text == "" || txtStdName.Text == "" || txtStdMajor.Text == "")
            {
                MessageBox.Show("You must fill all required field.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EditMode == true)
            {
                // Update the record.
                _db.SQLCommand = "UPDATE student SET ";
                _db.SQLCommand += "std_name='" + txtStdName.Text + "', ";
                _db.SQLCommand += "std_major='" + txtStdMajor.Text + "', ";
                _db.SQLCommand += "std_fp_key='" + txtFinger.Text + "' ";
                _db.SQLCommand += "WHERE std_id='" + StudentID + "' ";
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
                _db.SQLCommand = "INSERT INTO student (std_id, std_name, std_major, std_fp_key) VALUES ('" + txtStdID.Text + "', '" + txtStdName.Text + "', '" + txtStdMajor.Text + "', '" + txtFinger.Text + "')";
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

        private void AddEditStudentFrm_Load(object sender, EventArgs e)
        {
            // Init Database
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
                _db.SQLCommand = "SELECT * FROM student WHERE std_id='" + StudentID + "'";
                _db.Query();
                if (_db.Result.HasRows)
                {
                    _db.Result.Read();
                    txtStdID.Text = (string)_db.Result.GetValue(0);
                    txtStdName.Text = (string)_db.Result.GetValue(1);
                    txtStdMajor.Text = (string)_db.Result.GetValue(2);
                    if (_db.Result.GetValue(3) == null)
                    {
                        txtFinger.Text = "";
                    }
                    else
                    {
                        txtFinger.Text = (string)_db.Result.GetValue(3);   
                    }
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

        private void btnFingerEnroll_Click(object sender, EventArgs e)
        {
            _fpEngine.BeginEnroll();
            _enrollMode = true;
            txtFPStatus.Text = "Stamp 3 times";
            txtFPNo.Text = _cntFPEnroll.ToString();
        }

        private void AddEditStudentFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _fpEngine.EndInit();
            _fpEngine.EndEngine();
        }
    }
}
