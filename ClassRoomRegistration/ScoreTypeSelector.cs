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
    public partial class ScoreTypeSelector : Form
    {
        public Form Parent { get; set; }
        private MySQLDatabase _db = null;
        public string TypeSelected { get; set; }
        public int Score { get; set; }
        public bool OK { get; set; }

        public ScoreTypeSelector()
        {
            InitializeComponent();
        }

        private void ScoreTypeSelector_Load(object sender, EventArgs e)
        {
            // Init database
            _db = ((TeachingViewFrm)Parent)._db;

            OK = false;

            // Load current score setting
            _db.SQLCommand = "SELECT * FROM score_rating";
            _db.Query();

            if (_db.Result.Read())
            {
                cmbType.Items.Add("กลางภาค");
                cmbType.Items.Add("ปลายภาค");
                
                if (_db.Result["score1_title"].ToString() != "")
                {
                    cmbType.Items.Add(_db.Result["score1_title"].ToString());
                }
                else
                {
                    cmbType.Items.Add("เก็บ 1");
                }

                if (_db.Result["score2_title"].ToString() != "")
                {
                    cmbType.Items.Add(_db.Result["score2_title"].ToString());
                }
                else
                {
                    cmbType.Items.Add("เก็บ 2");
                }

                if (_db.Result["score3_title"].ToString() != "")
                {
                    cmbType.Items.Add(_db.Result["score3_title"].ToString());
                }
                else
                {
                    cmbType.Items.Add("เก็บ 3");
                }

                if (_db.Result["score4_title"].ToString() != "")
                {
                    cmbType.Items.Add(_db.Result["score4_title"].ToString());
                }
                else
                {
                    cmbType.Items.Add("เก็บ 4");
                }

                if (_db.Result["score5_title"].ToString() != "")
                {
                    cmbType.Items.Add(_db.Result["score5_title"].ToString());
                }
                else
                {
                    cmbType.Items.Add("เก็บ 5");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtScore.Text == "")
            {
                MessageBox.Show("ไม่ได้ใส่คะแนน");
                return;
            }

            OK = true;
            TypeSelected = cmbType.Text;
            Score = Convert.ToInt16(txtScore.Text);
            this.Hide();
        }

        private void txtScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidateInput.CheckAllowKeyNumber((int)e.KeyChar) == false)
            {
                MessageBox.Show("ใส่ได้แต่ตัวเลขเท่านั่น");
                e.Handled = true;
            }
        }
    }
}
