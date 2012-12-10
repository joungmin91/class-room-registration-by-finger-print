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
    public partial class ScoreFrm : Form
    {
        public Form Parent { get; set; }
        public string RegisID { get; set; }
        public string StdID { get; set; }
        public string StdName { get; set; }
        private MySQLDatabase _db = null;
        private int _scoreTotal = 0;

        public ScoreFrm()
        {
            InitializeComponent();
        }

        private void ScoreFrm_Load(object sender, EventArgs e)
        {
            // Init Database
            _db = ((TeachingViewFrm)Parent)._db;

            // Setup textbox
            txtStdID.Text = StdID;
            txtStdName.Text = StdName;

            // Setup DataGridView
            dgvScore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScore.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvScore.AllowUserToAddRows = false;
            dgvScore.AllowUserToDeleteRows = false;
            dgvScore.MultiSelect = false;
            dgvScore.ColumnCount = 3;
            dgvScore.Columns[0].HeaderText = "";
            dgvScore.Columns[0].Width = 10;
            dgvScore.Columns[0].Visible = false;
            dgvScore.Columns[1].HeaderText = "ประเภทคะแนน";
            dgvScore.Columns[1].Width = 300;
            dgvScore.Columns[1].ReadOnly = true;
            dgvScore.Columns[2].HeaderText = "คะแนน";
            dgvScore.Columns[2].Width = 100;

            LoadScoreType();
        }

        private void LoadScoreType()
        {
            _db.SQLCommand = "SELECT * FROM score_type";
            _db.Query();
            while (_db.Result.Read())
            {
                dgvScore.Rows.Add(_db.Result.GetValue(0), _db.Result.GetValue(1), 0);
            }

            foreach (DataGridViewRow item in dgvScore.Rows)
            {
                _db.SQLCommand = "SELECT * FROM score WHERE reg_id='" + RegisID +"' AND score_type='" + item.Cells[0].Value + "'";
                _db.Query();
                if (_db.Result.HasRows == true)
                {
                    _db.Result.Read();
                    item.Cells[2].Value = _db.Result.GetValue(1);
                }
            }

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            int total = 0;
            foreach (DataGridViewRow item in dgvScore.Rows)
            {
                total += Convert.ToInt32(item.Cells[2].Value);
            }
            _scoreTotal = total;
            txtTotal.Text = "คะแนนรวมทั้งหมด = " + total.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_scoreTotal > 100)
            {
                MessageBox.Show("คะแนนเกิน 100 คะแนน", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow item in dgvScore.Rows)
            {
                _db.SQLCommand = "SELECT * FROM score WHERE reg_id='" + RegisID + "' AND score_type='" + item.Cells[0].Value + "'";
                _db.Query();
                if (_db.Result.HasRows == true)
                {
                    // Update
                    _db.SQLCommand = "UPDATE score SET ";
                    _db.SQLCommand += "score_point='" + item.Cells[2].Value + "' ";
                    _db.SQLCommand += "WHERE reg_id='" + RegisID + "' AND score_type='" + item.Cells[0].Value + "'";
                    _db.Query();
                }
                else
                {
                    // Insert
                    _db.SQLCommand = "INSERT INTO score (score_point, score_type, score_description, reg_id) VALUES ('" + item.Cells[2].Value + "', '" + item.Cells[0].Value + "', '', '" + RegisID + "')";
                    _db.Query();
                }
            }
            this.Close();
        }

        private void dgvScore_SelectionChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
}
