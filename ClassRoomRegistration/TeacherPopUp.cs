﻿using System;
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
        private string _sqlShowAll = "SELECT t.tech_id, t.tech_name, t2.tech_brch_name FROM teacher t JOIN teacher_branch t2 ON t.tech_branch=t2.tech_brch_id";
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
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "ชื่อ-นามสกุล";
            dgv.Columns[1].Width = 125;
            dgv.Columns[2].HeaderText = "คณะ";
            dgv.Columns[2].Width = 200;

            // Load data
            _db.SQLCommand = _sqlShowAll;
            _db.Query();
            while (_db.Result.Read())
            {
                if (_db.Result["tech_name"].ToString() == "admin")
                {
                    continue;
                }
                dgv.Rows.Add(_db.Result["tech_id"], _db.Result["tech_name"], _db.Result["tech_brch_name"]);
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
