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
    public partial class TeacherPopUp : Form
    {
        public Form Parent { get; set; }
        private MySQLDatabase _db = null;
        private string _sqlShowAll = "SELECT tech_id, tech_name FROM teacher";
        public int TechID { get; set; }
        public string TechName { get; set; }

        public TeacherPopUp()
        {
            InitializeComponent();
        }

        private void TeacherPopUp_Load(object sender, EventArgs e)
        {
            // Init database
            _db = ((MainFrm)Parent)._db;

            // Setup datagrid columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 3;
            dgv.Columns[0].HeaderText = "รหัส";
            dgv.Columns[1].HeaderText = "ชื่อ-นามสกุล";

            // Load data
            _db.SQLCommand = _sqlShowAll;
            _db.Query();
            while (_db.Result.Read())
            {
                dgv.Rows.Add(_db.Result["tech_id"], _db.Result["tech_name"]);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                TechID = (int)dgv.CurrentRow.Cells[0].Value;
                TechName = (string)dgv.CurrentRow.Cells[1].Value;
                this.Hide();
            }
        }
    }
}
