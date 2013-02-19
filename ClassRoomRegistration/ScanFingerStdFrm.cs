using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Database;
using AxZKFPEngXControl;

namespace ClassRoomRegistration
{
    public partial class ScanFingerStdFrm : Form
    {
        public Form Parent { get; set; }
        public string StdID { get; set; }
        public string StdName { get; set; }
        public bool AutoScanMode { get; set; }
        public bool StopAutoScan { get; set; }
        private MySQLDatabase _db = null;
        private AxZKFPEngX _fpEngine = null;
        private int _cntFPEnroll = 0;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public ScanFingerStdFrm()
        {
            InitializeComponent();
        }

        private void ScanFingerStdFrm_Load(object sender, EventArgs e)
        {
            // Init Database
            _db = ((TeachingViewFrm)Parent)._db;

            // Init FP engine
            _fpEngine = new AxZKFPEngX();
            _fpEngine.BeginInit();
            _fpEngine.OnEnroll += new IZKFPEngXEvents_OnEnrollEventHandler(_fpEngine_OnEnroll);
            _fpEngine.OnImageReceived += new IZKFPEngXEvents_OnImageReceivedEventHandler(_fpEngine_OnImageReceived);
            this.Controls.Add(_fpEngine);

            if (_fpEngine.InitEngine() != 0)
            {
                MessageBox.Show("ไม่สามารถติดต่อเครื่องสแกนลายนิ้วมือได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (AutoScanMode == false)
                {
                    this.Close();
                }
                else
                {
                    _fpEngine.EndInit();
                    _fpEngine.EndEngine();
                    StopAutoScan = true;
                    btnCancel.Enabled = false;
                }
            }

            _fpEngine.BeginEnroll();
            txtFPStatus.Text = "วางนิ้ว 3 ครั้ง";
            txtFPNo.Text = _cntFPEnroll.ToString();

            _timer.Enabled = false;
            _timer.Interval = 3000;
            _timer.Tick += new EventHandler(_timer_Tick);

            txtStdID.Text = StdID;
            txtStdName.Text = StdName;

            if (AutoScanMode == false)
            {
                btnStop.Visible = false;
                btnCancel.Visible = false;
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        void _fpEngine_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            // Print image
            _fpEngine.PrintImageAt((int)picFP.CreateGraphics().GetHdc().ToInt64(), 0, 0, 100, 100);
            txtFPNo.Text = (++_cntFPEnroll).ToString();
        }

        void _fpEngine_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            // Update state
            txtFinger.Text = _fpEngine.GetTemplateAsString();
            _cntFPEnroll = 0;
            // Save fp key into Database
            _db.SQLCommand = "UPDATE student SET ";
            _db.SQLCommand += "std_fp_key='" + txtFinger.Text + "' ";
            _db.SQLCommand += "WHERE std_id='" + txtStdID.Text + "' ";
            if (_db.Query() == true)
            {
                txtFPStatus.Text = "เรียบร้อย";
                txtResult.Text = "จัดเก็บเรียบร้อยอีก 3 วินาทีหน้าจอจะปิดเองอัตโนมัติ";
                txtResult.ForeColor = Color.Green;
            }
            else
            {
                txtFPStatus.Text = "บันทึกข้อมูลไม่ได้";
                txtResult.Text = "ไม่สามารถจัดเก็บได้อีก 3 วินาทีหน้าจอจะปิดเองอัตโนมัติ";
                txtResult.ForeColor = Color.Red;
            }

            _timer.Enabled = true;
            _timer.Start();
        }

        private void ScanFingerStdFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _fpEngine.EndInit();
            _fpEngine.EndEngine();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAutoScan = true;
            _fpEngine.EndInit();
            _fpEngine.EndEngine();
            this.Hide();
        }
    }
}
