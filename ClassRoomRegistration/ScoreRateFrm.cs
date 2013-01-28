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
    public partial class ScoreRateFrm : Form
    {
        public Form Parent { get; set; }
        public int TeachingID { get; set; }
        private MySQLDatabase _db = null;
        private bool _ready = false;
        public List<int> _lstPoint = new List<int>();

        public ScoreRateFrm()
        {
            InitializeComponent();
        }

        private void ScoreRateFrm_Load(object sender, EventArgs e)
        {
            // Init database
            _db = ((MainFrm)Parent)._db;

            // Load current score setting
            _db.SQLCommand = "SELECT * FROM score_rating WHERE tech_id='" + TeachingID + "'";
            _db.Query();
            // If the subject has been already set score rating
            if (_db.Result.Read() == true)
            {
                txtA.Text = _db.Result["a"].ToString();
                txtBP.Text = _db.Result["bp"].ToString();
                txtB.Text = _db.Result["b"].ToString();
                txtCP.Text = _db.Result["cp"].ToString();
                txtC.Text = _db.Result["c"].ToString();
                txtDP.Text = _db.Result["dp"].ToString();
                txtD.Text = _db.Result["d"].ToString();
                txtF.Text = _db.Result["f"].ToString();
                txtMid.Text = _db.Result["mid"].ToString();
                txtFinal.Text = _db.Result["final"].ToString();
                txtCheckin.Text = _db.Result["checkin"].ToString();
                txtScore1.Text = _db.Result["score1"].ToString();
                txtScore2.Text = _db.Result["score2"].ToString();
                txtScore3.Text = _db.Result["score3"].ToString();
                txtScore4.Text = _db.Result["score4"].ToString();
                txtScore5.Text = _db.Result["score5"].ToString();
                btnCalc_Click(null, null);
            }
            _ready = true;  // To prevent crash we this flag.
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Checkk a sum of ll scores must not over 100 points
            int sum = Convert.ToInt16(txtMid.Text) +
                      Convert.ToInt16(txtFinal.Text) +
                      Convert.ToInt16(txtCheckin.Text) +
                      Convert.ToInt16(txtScore1.Text) +
                      Convert.ToInt16(txtScore2.Text) +
                      Convert.ToInt16(txtScore3.Text) +
                      Convert.ToInt16(txtScore4.Text) +
                      Convert.ToInt16(txtScore5.Text);
            if (sum > 100)
            {
                MessageBox.Show("คะแนนรวมเกิน 100 คะแนน", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the record be there
            _db.SQLCommand = "SELECT * FROM score_rating WHERE tech_id='" + TeachingID + "'";
            _db.Query();
            if (_db.Result.HasRows == true)
            {
                _db.SQLCommand = "UPDATE score_rating SET ";
                _db.SQLCommand += "a='" + txtA.Text + "', ";
                _db.SQLCommand += "bp='" + txtBP.Text + "', ";
                _db.SQLCommand += "b='" + txtB.Text + "', ";
                _db.SQLCommand += "cp='" + txtCP.Text + "', ";
                _db.SQLCommand += "c='" + txtC.Text + "', ";
                _db.SQLCommand += "dp='" + txtDP.Text + "', ";
                _db.SQLCommand += "d='" + txtD.Text + "', ";
                _db.SQLCommand += "f='" + txtF.Text + "', ";
                _db.SQLCommand += "mid='" + txtMid.Text + "', ";
                _db.SQLCommand += "final='" + txtFinal.Text + "', ";
                _db.SQLCommand += "checkin='" + txtCheckin.Text + "', ";
                _db.SQLCommand += "score1='" + txtScore1.Text + "', ";
                _db.SQLCommand += "score2='" + txtScore2.Text + "', ";
                _db.SQLCommand += "score3='" + txtScore3.Text + "', ";
                _db.SQLCommand += "score4='" + txtScore4.Text + "', ";
                _db.SQLCommand += "score5='" + txtScore5.Text + "' ";
                _db.SQLCommand += "WHERE tech_id='" + TeachingID + "'";
                _db.Query();
            }
            else
            {
                _db.SQLCommand = "INSERT INTO score_rating (tech_id, a, bp, b, cp, c, dp, d, f, mid, final, checkin, score1, score2, score3, score4, score5) VALUES ('" + TeachingID.ToString() + "', '" + txtA.Text + "', '" + txtBP.Text + "', '" + txtB.Text + "', '" + txtCP.Text + "', '" + txtC.Text + "', '" + txtDP.Text + "', '" + txtD.Text + "', '" + txtF.Text + "', '" + txtMid.Text + "', '" + txtFinal.Text + "', '" + txtCheckin.Text + "', '" + txtScore1.Text + "', '" + txtScore2.Text + "', '" + txtScore3.Text + "', '" + txtScore4 + "', '" + txtScore5.Text + "')";
                _db.Query();
            }
            this.Close();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int a = 0, bp = 0, b = 0, cp = 0, c = 0, dp = 0, d = 0, f = 0;
            foreach (int item in _lstPoint)
            {
                // Calculate for A
                if (item >= Convert.ToInt16(txtA.Text))
                {
                    a++;
                }
                // Calculate for B+
                else if (item < Convert.ToInt16(txtA.Text) && item >= Convert.ToInt16(txtBP.Text))
                {
                    bp++;
                }
                // Calculate for B
                else if (item < Convert.ToInt16(txtBP.Text) && item >= Convert.ToInt16(txtB.Text))
                {
                    b++;
                }
                // Calculate for C+
                else if (item < Convert.ToInt16(txtB.Text) && item >= Convert.ToInt16(txtCP.Text))
                {
                    cp++;
                }
                // Calculate for C
                else if (item < Convert.ToInt16(txtCP.Text) && item >= Convert.ToInt16(txtC.Text))
                {
                    c++;
                }
                // Calculate for D+
                else if (item < Convert.ToInt16(txtC.Text) && item >= Convert.ToInt16(txtDP.Text))
                {
                    dp++;
                }
                // Calculate for D
                else if (item < Convert.ToInt16(txtDP.Text) && item >= Convert.ToInt16(txtF.Text))
                {
                    d++;
                }
                // Calculate for F
                else if (item <= Convert.ToInt16(txtF.Text))
                {
                    f++;
                }
            }    

            txtNOA.Text = a.ToString();
            txtNOBP.Text = bp.ToString();
            txtNOB.Text = b.ToString();
            txtNOCP.Text = cp.ToString();
            txtNOC.Text = c.ToString();
            txtNODP.Text = dp.ToString();
            txtNOD.Text = d.ToString();
            txtNOF.Text = f.ToString();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ready == true)
            {
                btnCalc_Click(null, null);   
            }
        }

        private void btnCalc_Click_1(object sender, EventArgs e)
        {
            btnCalc_Click(null, null);
        }
    }
}
