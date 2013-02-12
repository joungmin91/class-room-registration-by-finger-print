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
        public List<double> _lstPoint = new List<double>();
        private bool _reallyCalcuate = false;
        public bool LabMode = true;

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
                txtScore1Title.Text = _db.Result["score1_title"].ToString();
                txtScore2Title.Text = _db.Result["score2_title"].ToString();
                txtScore3Title.Text = _db.Result["score3_title"].ToString();
                txtScore4Title.Text = _db.Result["score4_title"].ToString();
                txtScore5Title.Text = _db.Result["score5_title"].ToString();
                txtScoreLab.Text = _db.Result["score_lab"].ToString();

                if ((int)_db.Result["force_f_checkin"] == 0)
                {
                    chkForce.Checked = false;
                }
                else
                {
                    chkForce.Checked = true;
                }

                if (LabMode == true)
                {
                    txtScoreLab.Text = _db.Result["score_lab"].ToString();
                }

                if (_db.Result["score_type"].ToString() == "grade")
                {
                    cmbType.SelectedIndex = 1;
                }
                else
                {
                    cmbType.SelectedIndex = 0;
                }

                _reallyCalcuate = false;
                btnCalc_Click(null, null);
            }
            else
            {
                cmbType.SelectedIndex = 1;
            }

            if (LabMode == true)
            {
                txtScoreLab.Visible = false;
                labScoreLab.Visible = false;
            }

            _ready = true;  // To prevent crash we this flag.
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtMid.Text == "" ||
                txtFinal.Text == "" ||
                txtCheckin.Text == ""
                )
            {
                if (LabMode == false)
                {
                    if (txtScoreLab.Text == "")
                    {
                        MessageBox.Show("ใส่คะแนนด้วย");
                        return;
                    }
                }

                MessageBox.Show("ใส่คะแนนด้วย");
                return;
            }

            // Checkk a sum of ll scores must not over 100 points
            int sum = 0;
            
            if (txtMid.Text != "")
	        {
                sum += Convert.ToInt16(txtMid.Text);
	        }

            if (txtFinal.Text != "")
            {
                sum += Convert.ToInt16(txtFinal.Text);
            }

            if (txtCheckin.Text != "")
            {
                sum += Convert.ToInt16(txtCheckin.Text);
            }

            if (txtScore1.Text != "")
            {
                sum += Convert.ToInt16(txtScore1.Text);
            }

            if (txtScore2.Text != "")
            {
                sum += Convert.ToInt16(txtScore2.Text);
            }

            if (txtScore3.Text != "")
            {
                sum += Convert.ToInt16(txtScore3.Text);
            }

            if (txtScore4.Text != "")
            {
                sum += Convert.ToInt16(txtScore4.Text);
            }

            if (txtScore5.Text != "")
            {
                sum += Convert.ToInt16(txtScore5.Text);
            }
                      
            if (LabMode == false)
            {
                if (txtScoreLab.Text != "")
                {
                    sum += Convert.ToInt16(txtScoreLab.Text);   
                }
            }

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
                _db.SQLCommand += "score5='" + txtScore5.Text + "', ";
                _db.SQLCommand += "score1_title='" + txtScore1Title.Text + "', ";
                _db.SQLCommand += "score2_title='" + txtScore2Title.Text + "', ";
                _db.SQLCommand += "score3_title='" + txtScore3Title.Text + "', ";
                _db.SQLCommand += "score4_title='" + txtScore4Title.Text + "', ";
                _db.SQLCommand += "score5_title='" + txtScore5Title.Text + "', ";
                _db.SQLCommand += "score_lab='" + txtScoreLab.Text + "', ";

                if (chkForce.Checked == true)
                {
                    _db.SQLCommand += "force_f_checkin='1', ";
                }
                else
                {
                    _db.SQLCommand += "force_f_checkin='0', ";
                }

                if (cmbType.Text == "อิงกลุ่ม")
                {
                    _db.SQLCommand += "score_type='group' ";    
                }
                else
                {
                    _db.SQLCommand += "score_type='grade' ";    
                }
                
                _db.SQLCommand += "WHERE tech_id='" + TeachingID + "'";
                _db.Query();
            }
            else
            {
                string type = "";
                if (cmbType.Text == "อิงกลุ่ม")
                {
                    type = "group";
                }
                else
                {
                    type = "grade";
                }

                string forceF = "0";
                if (chkForce.Checked == true)
                {
                    forceF = "1";
                }

                _db.SQLCommand = "INSERT INTO score_rating (tech_id, a, bp, b, cp, c, dp, d, f, mid, final, checkin, score1, score2, score3, score4, score5, score1_title, score2_title, score3_title, score4_title, score5_title, score_type, score_lab, force_f_checkin) VALUES ('" + TeachingID.ToString() + "', '" + txtA.Text + "', '" + txtBP.Text + "', '" + txtB.Text + "', '" + txtCP.Text + "', '" + txtC.Text + "', '" + txtDP.Text + "', '" + txtD.Text + "', '" + txtF.Text + "', '" + txtMid.Text + "', '" + txtFinal.Text + "', '" + txtCheckin.Text + "', '" + txtScore1.Text + "', '" + txtScore2.Text + "', '" + txtScore3.Text + "', '" + txtScore4 + "', '" + txtScore5.Text + "', '" + txtScore1Title.Text + "', '" + txtScore2Title.Text + "', '" + txtScore3Title.Text + "', '" + txtScore4Title.Text + "', '" + txtScore5Title.Text + "', '" +type + "', '" + txtScoreLab.Text + "', '" + forceF + "')";
                _db.Query();
            }
            this.Close();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int a = 0, bp = 0, b = 0, cp = 0, c = 0, dp = 0, d = 0, f = 0;

            //// There are 2 type of calculating.
            //// Level reference
            //// Group reference
            //if (cmbType.Text == "อิงกลุ่ม")
            //{
            //    // Find max
            //    int max = 0;
            //    foreach (int item in _lstPoint)
            //    {
            //        if (item > max)
            //        {
            //            max = item;
            //        }
            //    }
            //    // Find min
            //    int min = 100;
            //    foreach (int item in _lstPoint)
            //    {
            //        if (item < min)
            //        {
            //            min = item;
            //        }
            //    }
            //    // Find douglas
            //    int dou = (max - min) / 8;

            //    txtA.Text = (min + dou + dou + dou + dou + dou + dou + dou).ToString();
            //    txtBP.Text = (min + dou + dou + dou + dou + dou + dou).ToString();
            //    txtB.Text = (min + dou + dou + dou + dou + dou).ToString();
            //    txtCP.Text = (min + dou + dou + dou + dou).ToString();
            //    txtC.Text = (min + dou + dou + dou).ToString();
            //    txtDP.Text = (min + dou + dou).ToString();
            //    txtD.Text = (min + dou).ToString();
            //    //txtF.Text = min.ToString();
            //}
            //else
            //{
            //    //if (txtA.Text == "")
            //    {
            //        txtA.Text = "80";
            //    }

            //    //if (txtBP.Text == "")
            //    {
            //        txtBP.Text = "75";
            //    }

            //    //if (txtB.Text == "")
            //    {
            //        txtB.Text = "70";
            //    }

            //    //if (txtCP.Text == "")
            //    {
            //        txtCP.Text = "65";
            //    }

            //    //if (txtC.Text == "")
            //    {
            //        txtC.Text = "60";
            //    }

            //    //if (txtDP.Text == "")
            //    {
            //        txtDP.Text = "55";
            //    }

            //    //if (txtD.Text == "")
            //    {
            //        txtD.Text = "50";
            //    }

            //    //if (txtF.Text == "")
            //    //{
            //    //    txtF.Text = "0";
            //    //}
            //}

            // Calculate how many people for each grade?
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
                else if (item < Convert.ToInt16(txtDP.Text) && item >= Convert.ToInt16(txtD.Text))
                {
                    d++;
                }
                // Calculate for F
                else if (item <= Convert.ToInt16(txtF.Text))
                {
                    f++;
                }
            }    

            // Display result.
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
                if (cmbType.Text == "อิงกลุ่ม")
                {
                    if (txtA.Text == "" || txtF.Text == "")
                    {
                        MessageBox.Show("ต้องใส่คะแนนของ A กับ F ก่อน");
                        return;
                    }

                    // Find max
                    int max = Convert.ToInt16(txtA.Text);
                    int min = Convert.ToInt16(txtF.Text);
                    int dou = (max - min) / 6;

                    txtBP.Text = (min + dou + dou + dou + dou + dou + dou).ToString();
                    txtB.Text = (min + dou + dou + dou + dou + dou).ToString();
                    txtCP.Text = (min + dou + dou + dou + dou).ToString();
                    txtC.Text = (min + dou + dou + dou).ToString();
                    txtDP.Text = (min + dou + dou).ToString();
                    txtD.Text = (min + dou).ToString();
                }
                else
                {
                    txtA.Text = "80";
                    txtBP.Text = "75";
                    txtB.Text = "70";
                    txtCP.Text = "65";
                    txtC.Text = "60";
                    txtDP.Text = "55";
                    txtD.Text = "50";
                    txtF.Text = "0";
                }
            }
        }

        private void btnCalc_Click_1(object sender, EventArgs e)
        {
            _reallyCalcuate = true;
            btnCalc_Click(null, null);
        }
    }
}
