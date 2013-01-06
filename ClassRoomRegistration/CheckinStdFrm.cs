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
                MessageBox.Show("ไม่สามารถติดต่ออุปกรณ์สแกนลายนิ้วมือได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Check the key with all student in the class
            _db.SQLCommand = "SELECT std.std_id, std.std_name, std.std_fp_key FROM registration reg JOIN student std ON reg.std_id = std.std_id WHERE reg.sub_id = '" + SubID + "' AND reg.year = '" + Year + "'";
            _db.Query();

            List<StdItem> lstStd = new List<StdItem>();
            while (_db.Result.Read())
            {
                lstStd.Add(new StdItem
                        {
                            StdID = (string)_db.Result.GetValue(0),
                            StdName = (string)_db.Result.GetValue(1),
                            StdKey = (string)_db.Result.GetValue(2)
                        }
                    );
            }

            foreach (StdItem item in lstStd)
            {
                string stdID = item.StdID;
                bool bRegChanged = false;
                bool bMatched = false;
                string regKey = item.StdKey;
                bMatched = _fpEngine.VerFingerFromStr(ref regKey, key, false, ref bRegChanged);
                if (bMatched == true)
                {
                    // If the record is not in database then insert
                    _db.SQLCommand = "SELECT * FROM checkin WHERE sub_id='" + SubID + "' AND std_id='" + stdID + "' AND chkin_year='" + Year + "' AND chkin_date='" + txtDate.Text + "'";
                    _db.Query();
                    if (_db.Result.HasRows == false)
                    {
                        string chkinStatus = "normal";
                        if (DateTime.Now.Hour > TimeLate.Hours || DateTime.Now.Minute > TimeLate.Minutes)
                        {
                            chkinStatus = "late";
                        }
                        _db.SQLCommand = "INSERT INTO checkin (sub_id, std_id, chkin_year, chkin_date, chkin_status) VALUES ('" + SubID + "', '" + stdID + "', '" + Year + "', '" + txtDate.Text + "', '" + chkinStatus + "')";
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
    }
}
