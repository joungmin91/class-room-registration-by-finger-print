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
            _db.SQLCommand = "SELECT * FROM score_rate_type WHERE tech_id='" + TeachingID + "'";
            _db.Query();

            if (_db.Result.HasRows == true)
            {
                _db.Result.Read();

                if (_db.Result["type"].ToString() == "grade")
                {
                    cmbType.SelectedIndex = 0;
                }
                else
                {
                    cmbType.SelectedIndex = 1;
                }

                txtA.Text = (string)_db.Result["A"];
                txtBP.Text = (string)_db.Result["BP"];
                txtB.Text = (string)_db.Result["B"];
                txtCP.Text = (string)_db.Result["CP"];
                txtC.Text = (string)_db.Result["C"];
                txtDP.Text = (string)_db.Result["DP"];
                txtD.Text = (string)_db.Result["D"];
                txtF.Text = (string)_db.Result["F"];

                btnCalc_Click(null, null);
            }
            
            _ready = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string type = "";
            if (cmbType.Text == "อิงเกณท์")
            {
                type = "grade";
            }
            else if (cmbType.Text == "อิงกลุ่ม")
            {
                type = "group";
            }
            else
            {
                MessageBox.Show("เลือกประเภทการให้คะแนน", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check if the record be there
            _db.SQLCommand = "SELECT * FROM score_rate_type WHERE tech_id='" + TeachingID + "'";
            _db.Query();
            if (_db.Result.HasRows == true)
            {
                _db.SQLCommand = "UPDATE score_rate_type SET ";
                _db.SQLCommand += "type='" + type + "', ";
                _db.SQLCommand += "A='" + txtA.Text + "', ";
                _db.SQLCommand += "BP='" + txtBP.Text + "', ";
                _db.SQLCommand += "B='" + txtB.Text + "', ";
                _db.SQLCommand += "CP='" + txtCP.Text + "', ";
                _db.SQLCommand += "C='" + txtC.Text + "', ";
                _db.SQLCommand += "DP='" + txtDP.Text + "', ";
                _db.SQLCommand += "D='" + txtD.Text + "', ";
                _db.SQLCommand += "F='" + txtF.Text + "' ";
                _db.SQLCommand += "WHERE tech_id='" + TeachingID + "'";
                _db.Query();
            }
            else
            {
                _db.SQLCommand = "INSERT INTO score_rate_type (tech_id, type, A, BP, B, CP, C, DP, D, F) VALUES ('" + TeachingID.ToString() + "', '" + type + "', '" + txtA.Text + "', '" + txtBP.Text + "', '" + txtB.Text + "', '" + txtCP.Text + "', '" + txtC.Text + "', '" + txtDP.Text + "', '" + txtD.Text + "', '" + txtF.Text + "')";
                _db.Query();
            }
            this.Close();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int a = 0, bp = 0, b = 0, cp = 0, c = 0, dp = 0, d = 0, f = 0;
            
            if (cmbType.Text == "อิงกลุ่ม")
            {
                // Find max
                int max = 0;
                foreach (int item in _lstPoint)
                {
                    if (item > max)
                    {
                        max = item;
                    }
                }
                // Find min
                int min = 100;
                foreach (int item in _lstPoint)
                {
                    if (item < min)
                    {
                        min = item;
                    }
                }
                // Find douglas
                int dou = (max - min) / 8;

                txtA.Text = (min + dou + dou + dou + dou + dou + dou + dou).ToString();
                txtBP.Text = (min + dou + dou + dou + dou + dou + dou).ToString();
                txtB.Text = (min + dou + dou + dou + dou + dou).ToString();
                txtCP.Text = (min + dou + dou + dou + dou).ToString();
                txtC.Text = (min + dou + dou + dou).ToString();
                txtDP.Text = (min + dou + dou).ToString();
                txtD.Text = (min + dou).ToString();
                txtF.Text = min.ToString();
            }
            else
            {
                if (txtA.Text == "")
                {
                    txtA.Text = "80";
                }

                if (txtBP.Text == "")
                {
                    txtBP.Text = "75";
                }

                if (txtB.Text == "")
                {
                    txtB.Text = "70";
                }

                if (txtCP.Text == "")
                {
                    txtCP.Text = "65";
                }

                if (txtC.Text == "")
                {
                    txtC.Text = "60";
                }

                if (txtDP.Text == "")
                {
                    txtDP.Text = "55";
                }

                if (txtD.Text == "")
                {
                    txtD.Text = "50";
                }

                if (txtF.Text == "")
                {
                    txtF.Text = "0";
                }
            }

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
                else if (item < Convert.ToInt16(txtD.Text))
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
    }
}
