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
    public partial class CheckinDateFrm : Form
    {
        public Form Parent { get; set; }
        public int TechID { get; set; }
        private MySQLDatabase _db = null;
        private string _sqlShowAll = "SELECT * FROM checkin_date WHERE tech_id='$1' ORDER BY date";

        public CheckinDateFrm()
        {
            InitializeComponent();
        }

        private void CheckinDateFrm_Load(object sender, EventArgs e)
        {
            // Init database
            _db = ((MainFrm)Parent)._db;

            // Setup datagrid columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 1;
            dgv.Columns[0].HeaderText = "วันที่เช็คชื่อ";
            dgv.Columns[0].Width = 200;

            LoadDGV();
        }

        private void LoadDGV()
        {
            // Load data
            _db.SQLCommand = _sqlShowAll.Replace("$1", TechID.ToString());
            _db.Query();
            dgv.Rows.Clear();
            while (_db.Result.Read())
            {
                dgv.Rows.Add(_db.Result["date"]);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _db.SQLCommand = "SELECT * FROM checkin_date WHERE date='" + dateChkin.Value.ToShortDateString() + "' AND tech_id='" + TechID + "'";
            _db.Query();
            if (_db.Result.HasRows == true)
            {
                MessageBox.Show("วันที่นี้มีอยู่แล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _db.SQLCommand = "INSERT INTO checkin_date (date, tech_id) VALUES ('" + dateChkin.Value.ToShortDateString() + "', '" + TechID + "')";
            _db.Query();
            LoadDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
