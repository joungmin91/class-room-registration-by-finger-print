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
    public partial class TeachingFrm : Form
    {
        private MySQLDatabase _db = null;
        private string _sqlShowAll = "SELECT s.sub_id, s.sub_title, s.sub_lec, s.sub_lab, t1.tech_name, t2.year, t1.tech_id, t2.term, t2.id FROM teacher t1 JOIN teaching t2 ON t1.tech_id = t2.tech_id JOIN subject s ON t2.sub_id = s.id";

        public TeachingFrm()
        {
            InitializeComponent();
        }

        private void TeachingFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            _db = ((MainFrm)this.MdiParent)._db;

            // Setup datagrid columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 9;
            dgv.Columns[0].HeaderText = "รหัสวิชา";
            dgv.Columns[1].HeaderText = "ชื่อวิชา";
            dgv.Columns[1].Width = 250;
            dgv.Columns[2].HeaderText = "ทฤษฏี";
            dgv.Columns[2].Width = 50;
            dgv.Columns[3].HeaderText = "ปฏิบัติ";
            dgv.Columns[3].Width = 50;
            dgv.Columns[4].HeaderText = "ชื่ออาจารย์";
            dgv.Columns[4].Width = 300;
            dgv.Columns[5].HeaderText = "ปีการศึกษา";
            dgv.Columns[6].HeaderText = "รหัสอาจารย์";
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].HeaderText = "ภาค";
            dgv.Columns[8].HeaderText = "ไอดีการสอน";
            dgv.Columns[8].Visible = false;

            LoadTeachingToDGV(_sqlShowAll);
        }

        private void LoadTeachingToDGV(string sqlCmd)
        {
            // Clear DGV
            dgv.Rows.Clear();
            // Query all teacher.
            _db.SQLCommand = sqlCmd;
            _db.Query();

            if (_db.Result.HasRows == false)
            {
                //MessageBox.Show("ไม่มีรายการที่ต้องการแสดง", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                dgv.Rows.Add(
                    _db.Result.GetValue(0),
                    _db.Result.GetValue(1),
                    _db.Result.GetValue(2),
                    _db.Result.GetValue(3),
                    _db.Result.GetValue(4),
                    _db.Result.GetValue(5),
                    _db.Result.GetValue(6),
                    _db.Result.GetValue(7),
                    _db.Result.GetValue(8)
                    );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sqlCmd = _sqlShowAll + " WHERE ";
            if (cmbType.Text == "รหัสวิชา")
            {
                sqlCmd += "s.sub_id = '" + txtSearch.Text + "'";
            }
            else if (cmbType.Text == "ชื่อวิชา")
            {
                sqlCmd += "s.sub_title like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "ชื่ออาจารย์")
            {
                sqlCmd += "t1.tech_name like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "ปีการศึกษา")
            {
                sqlCmd += "t2.year = '" + txtSearch.Text + "'";
            }
            else
            {
                MessageBox.Show("เลือกรายการที่ต้องการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadTeachingToDGV(sqlCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadTeachingToDGV(_sqlShowAll);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                return;
            }

            if (MessageBox.Show("ต้องการลบข้อมูลหรือไม่", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            _db.SQLCommand = "DELETE FROM teaching WHERE id='" + dgv.CurrentRow.Cells[8].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadTeachingToDGV(_sqlShowAll);
            }
            else
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
