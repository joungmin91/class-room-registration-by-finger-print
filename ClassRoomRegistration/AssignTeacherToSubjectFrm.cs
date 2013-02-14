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
    public partial class AssignTeacherToSubjectFrm : Form
    {
        public Form Parent { get; set; }
        public string TechID { get; set; }
        private MySQLDatabase _db = null;

        public AssignTeacherToSubjectFrm()
        {
            InitializeComponent();
        }

        private void AssignTeacherToSubjectFrm_Load(object sender, EventArgs e)
        {
            _db = ((MainFrm)Parent)._db;
            InitDGV();
            LoadSubjectToDGV("SELECT s.id, s.sub_id, s.sub_title, s.sub_lec, s.sub_lab, t.year, t.term FROM subject s JOIN teaching t ON s.id = t.sub_id");
        }

        private void LoadSubjectToDGV(string sqlCmd)
        {
            // Clear DGV
            dgv.Rows.Clear();
            // Query all teacher.
            _db.SQLCommand = sqlCmd;
            _db.Query();

            if (_db.Result.HasRows == false)
            {
                MessageBox.Show("ไม่มีรายการที่ต้องการแสดง", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                dgv.Rows.Add(
                    _db.Result["id"],
                    _db.Result["sub_id"],
                    _db.Result["sub_title"],
                    _db.Result["sub_lec"],
                    _db.Result["sub_lab"],
                    _db.Result["year"],
                    _db.Result["term"]
                    );
            }
        }

        private void InitDGV()
        {
            // Setup datagrid columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 7;
            dgv.Columns[0].HeaderText = "รหัส";
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "รหัสวิชา";
            dgv.Columns[2].HeaderText = "ชื่อวิชา";
            dgv.Columns[3].HeaderText = "ทฤษฏี";
            dgv.Columns[4].HeaderText = "ปฏิบัติ";
            dgv.Columns[5].HeaderText = "ปีการศึกษา";
            dgv.Columns[6].HeaderText = "ภาคการศึกษา";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (cmbYear.Text == "")
            //{
            //    MessageBox.Show("กรุณาเลือกปีการศึกษา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("ไม่มีรายการที่ต้องการ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _db.SQLCommand = "SELECT * FROM teaching WHERE tech_id='" + TechID + "' AND sub_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "' AND year='" + dgv.CurrentRow.Cells[5].Value.ToString() + "' AND term='" + dgv.CurrentRow.Cells[6].Value.ToString() + "'";
            _db.Query();
            if (_db.Result.HasRows)
            {
                // Update
                //_db.SQLCommand = "UPDATE teaching SET ";
                //_db.SQLCommand += "tech_id='" + TechID + "', ";
                //_db.SQLCommand += "sub_id='" + (int)dgv.CurrentRow.Cells[0].Value + "', ";
                //_db.SQLCommand += "year='" + cmbYear.Text + "', ";
                //_db.SQLCommand += "term='" + cmbTerm.Text + "' ";
                //_db.SQLCommand += "WHERE tech_id='" + TechID + "' AND sub_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "' AND year='" + cmbYear.Text + "'";
                MessageBox.Show("มีรายการสอนของอาจารย์ท่านนี้แล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Insert
                _db.SQLCommand = "INSERT INTO teaching (tech_id, sub_id, year, term) VALUES ('" + TechID + "', '" + dgv.CurrentRow.Cells[0].Value.ToString() + "', '" + dgv.CurrentRow.Cells[5].Value.ToString() + "', '" + dgv.CurrentRow.Cells[6].Value.ToString() + "')";
            }

            if (_db.Query() == false)
            {
                MessageBox.Show("ไม่สามารถเลือกรายวิชาให้กับอาจารย์ได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("เลือกรายวิชาเรียบร้อย", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
