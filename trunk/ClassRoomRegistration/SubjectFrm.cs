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
    public partial class SubjectFrm : Form
    {
        private MySQLDatabase _db = null;

        public SubjectFrm()
        {
            InitializeComponent();
        }

        private void SubjectFrm_Load(object sender, EventArgs e)
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
            dgv.Columns[0].HeaderText = "รหัสวิชา";
            dgv.Columns[1].HeaderText = "ชื่อวิชา";
            dgv.Columns[1].Width = 400;
            dgv.Columns[2].HeaderText = "ทฤษฏี";
            dgv.Columns[3].HeaderText = "ปฏิบัติ";
            
            LoadSubjectToDGV("SELECT * FROM subject");
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
                //MessageBox.Show("ไม่มีรายการที่ต้องแสดง", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                dgv.Rows.Add(
                    _db.Result["sub_id"],
                    _db.Result["sub_title"],
                    _db.Result["sub_lec"],
                    _db.Result["sub_lab"]
                    );
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ShowDeleteFrm();
        }

        private void ShowAddFrm()
        {
            AddEditSubjectFrm frm = new AddEditSubjectFrm();
            frm.Parent = this.MdiParent;
            frm.ShowDialog();
            LoadSubjectToDGV("SELECT * FROM subject");
        }

        private void ShowEditFrm()
        {
            if (dgv.CurrentRow == null)
            {
                return;
            }

            AddEditSubjectFrm frm = new AddEditSubjectFrm();
            frm.Parent = this.MdiParent;
            frm.EditMode = true;
            frm.SubjectID = (string)dgv.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            LoadSubjectToDGV("SELECT * FROM subject");
        }

        private void ShowDeleteFrm()
        {
            if (dgv.CurrentRow == null)
            {
                return;
            }

            if (MessageBox.Show("ต้องการลบข้อมูลหรือไม่", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            _db.SQLCommand = "DELETE FROM subject WHERE sub_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadSubjectToDGV("SELECT * FROM subject");
            }
            else
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddFrm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditFrm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("ใส่คำที่ต้องการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sqlCmd = "SELECT * FROM subject WHERE ";
            if (cmbType.Text == "รหัสวิชา")
            {
                sqlCmd += "sub_id='" + txtSearch.Text + "'";
            }
            else if (cmbType.Text == "ชื่อวิชา")
            {
                sqlCmd += "sub_title like '%" + txtSearch.Text + "%'";
            }
            else
            {
                MessageBox.Show("เลือกรายการที่ต้องการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadSubjectToDGV(sqlCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadSubjectToDGV("SELECT * FROM subject");
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
