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

        public ScoreTypeSelector()
        {
            InitializeComponent();
        }

        private void ScoreTypeSelector_Load(object sender, EventArgs e)
        {
            // Init database
            _db = ((TeachingViewFrm)Parent)._db;

            // Load current score setting
            _db.SQLCommand = "SELECT * FROM score_rating";
            _db.Query();

            if (_db.Result.Read())
            {
                cmbType.Items.Add("กลางภาค");
                cmbType.Items.Add("ปลายภาค");
                cmbType.Items.Add(_db.Result["score1_title"].ToString());
                cmbType.Items.Add(_db.Result["score2_title"].ToString());
                cmbType.Items.Add(_db.Result["score3_title"].ToString());
                cmbType.Items.Add(_db.Result["score4_title"].ToString());
                cmbType.Items.Add(_db.Result["score5_title"].ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TypeSelected = cmbType.Text;
            Score = Convert.ToInt16(txtScore.Text);
            this.Hide();
        }
    }
}
