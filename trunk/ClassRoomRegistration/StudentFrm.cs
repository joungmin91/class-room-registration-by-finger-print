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
    public partial class StudentFrm : Form
    {
        private MySQLDatabase _db = null;

        public StudentFrm()
        {
            InitializeComponent();
        }

        private void StudentFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            _db = ((MainFrm)this.MdiParent)._db;

            // Setup datagrid columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 4;
            dgv.Columns[0].HeaderText = "";
            dgv.Columns[0].Width = 20;
            dgv.Columns[1].HeaderText = "รหัสนิสิต";
            dgv.Columns[2].HeaderText = "ชื่อนิสิต";
            dgv.Columns[2].Width = 480;
            dgv.Columns[3].HeaderText = "สาขา";

            LoadStudentToDGV("SELECT * FROM student");
        }

        private void LoadStudentToDGV(string sqlCmd)
        {
            // Clear DGV
            dgv.Rows.Clear();
            // Query all teacher.
            _db.SQLCommand = sqlCmd;
            _db.Query();

            if (_db.Result.HasRows == false)
            {
                //MessageBox.Show("ไม่มีข้อมูลแสดงผล", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }

            // Insert rows to DGV
            int i = 1;
            while (_db.Result.Read())
            {
                dgv.Rows.Add(
                    i++,
                    _db.Result.GetValue(0),
                    _db.Result.GetValue(1),
                    _db.Result.GetValue(2)
                    );
            }
        }

        private void ShowDeleteFrm()
        {
            if (dgv.CurrentCell == null)
            {
                return;
            }

            if (MessageBox.Show("ต้องการลบข้อมูลหรือไม่", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            _db.SQLCommand = "DELETE FROM student WHERE std_id='" + dgv.CurrentRow.Cells[1].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadStudentToDGV("SELECT * FROM student");
            }
            else
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ShowDeleteFrm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("ใส่คำที่ต้องการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sqlCmd = "SELECT * FROM student WHERE ";
            if (cmbType.Text == "รหัสนิสิต")
            {
                sqlCmd += "std_id='" + txtSearch.Text + "'";
            }
            else if (cmbType.Text == "ชื่อนิสิต")
            {
                sqlCmd += "std_name like '%" + txtSearch.Text + "%'";
            }
            else
            {
                MessageBox.Show("เลือกประเภทการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadStudentToDGV(sqlCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadStudentToDGV("SELECT * FROM student");
        }

        private void ShowAddFrm()
        {
            AddEditStudentFrm frm = new AddEditStudentFrm();
            frm.Parent = this.MdiParent;
            frm.ShowDialog();
            LoadStudentToDGV("SELECT * FROM student");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddFrm();
        }

        private void ShowEditFrm()
        {
            if (dgv.CurrentRow == null)
            {
                return;
            }

            AddEditStudentFrm frm = new AddEditStudentFrm();
            frm.Parent = this.MdiParent;
            frm.EditMode = true;
            frm.StudentID = (string)dgv.CurrentRow.Cells[1].Value.ToString();
            frm.ShowDialog();
            LoadStudentToDGV("SELECT * FROM student");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditFrm();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
