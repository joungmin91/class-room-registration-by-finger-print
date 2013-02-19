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
    public partial class CheckinStdFrm : Form
    {
        public Form Parent { get; set; }
        public TimeSpan TimeLate { get; set; }
        public int SubID { get; set; }
        public string Year { get; set; }
        public string Term { get; set; }
        public bool StopAutoCheckin { get; set; }
        private MySQLDatabase _db = null;
        private AxZKFPEngX _fpEngine = null;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public CheckinStdFrm()
        {
            InitializeComponent();
        }

        private void CheckinStdFrm_Load(object sender, EventArgs e)
        {
            // Init Database
            _db = ((TeachingViewFrm)Parent)._db;

            // Init FP engine
            _fpEngine = new AxZKFPEngX();
            _fpEngine.BeginInit();
            _fpEngine.OnEnroll += new IZKFPEngXEvents_OnEnrollEventHandler(_fpEngine_OnEnroll);
            _fpEngine.OnImageReceived += new IZKFPEngXEvents_OnImageReceivedEventHandler(_fpEngine_OnImageReceived);
            this.Controls.Add(_fpEngine);

            // Check it here
            _fpEngine.EnrollCount = 1;

            if (_fpEngine.InitEngine() != 0)
            {
                MessageBox.Show("ไม่สามารถติดต่อเครื่องสแกนลายนิ้วมือได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _fpEngine.EndInit();
                _fpEngine.EndEngine();
                this.Hide();
            }

            _fpEngine.BeginEnroll();

            _timer.Enabled = false;
            _timer.Interval = 3000;
            _timer.Tick += new EventHandler(_timer_Tick);

            txtDate.Text = DateTime.Now.ToShortDateString();
            txtError.Visible = false;
        }

        void _fpEngine_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            _fpEngine.PrintImageAt((int)picFP.CreateGraphics().GetHdc().ToInt64(), 0, 0, 100, 100);
        }

        void _fpEngine_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            // Get finger print key
            string key = _fpEngine.GetTemplateAsString();

            // Check the key with all students in the class
            _db.SQLCommand = "SELECT std.std_id, std.std_name, std.std_fp_key, reg.reg_id FROM registration reg JOIN student std ON reg.std_id = std.std_id WHERE reg.sub_id = '" + SubID + "' AND reg.year = '" + Year + "' AND reg.term='" + Term + "'";
            _db.Query();

            // Store all students that register this class into a list
            List<StdItem> lstStd = new List<StdItem>();
            while (_db.Result.Read())
            {
                lstStd.Add(new StdItem
                        {
                            StdID = (string)_db.Result["std_id"],
                            StdName = (string)_db.Result["std_name"],
                            StdKey = (string)_db.Result["std_fp_key"],
                            RegID = (int)_db.Result["reg_id"]
                        }
                    );
            }

            // Search a student that has a finger key matchs with key from finger print device 
            foreach (StdItem item in lstStd)
            {
                bool bRegChanged = false;       // Not use but we need to have it
                bool bMatched = false;          // Return value from verify 2 keys   
                string regKey = item.StdKey;    // Student's finger print key
                bMatched = _fpEngine.VerFingerFromStr(ref regKey, key, false, ref bRegChanged);
                // If key from device matched with the student's key
                if (bMatched == true)
                {
                    // Check the record is in database, if not yet, insert the record
                    _db.SQLCommand = "SELECT * FROM checkin WHERE reg_id='" + item.RegID + "' AND date='" + txtDate.Text + "'";
                    _db.Query();
                    if (_db.Result.HasRows == false)
                    {
                        string chkinStatus = "normal";
                        // If the time checkin more than setting time 15 minutes then the status will be 'late'
                        if (DateTime.Now.Hour > TimeLate.Hours || DateTime.Now.Minute > (TimeLate.Minutes + 15))
                        {
                            chkinStatus = "late";
                        }
                        _db.SQLCommand = "INSERT INTO checkin (reg_id, date, status) VALUES ('" + item.RegID + "', '" + txtDate.Text + "', '" + chkinStatus + "')";
                        _db.Query();
                    }

                    // Update result
                    txtStdID.Text = item.StdID;
                    txtStdName.Text = item.StdName;

                    // Start timer
                    _timer.Enabled = true;
                    _timer.Start();

                    return;
                }
            }

            txtError.Visible = true;
            // Start timer
            _timer.Enabled = true;
            _timer.Start();
        }

        public void GetStopAutoCheckin(ref bool bValue)
        {
            bValue = StopAutoCheckin;
        }
        
        void _timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckinStdFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _fpEngine.EndInit();
            _fpEngine.EndEngine();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAutoCheckin = true;
            _fpEngine.EndInit();
            _fpEngine.EndEngine();
            this.Close();
        }
    }

    public class StdItem
    {
        public string StdID { get; set; }
        public string StdName { get; set; }
        public string StdKey { get; set; }
        public int RegID { get; set; }
    }
}
