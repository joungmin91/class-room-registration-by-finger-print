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
    public partial class RegistationFrm : Form
    {
        private MySQLDatabase _db = null;
        private string _sqlShowAll = "SELECT reg.reg_id, sub.sub_id, sub.sub_title, sub.sub_lec, sub.sub_lab, std.std_id, std.std_name, reg.year FROM subject sub JOIN registration reg ON sub.id = reg.sub_id JOIN student std ON reg.std_id = std.std_id";

        public RegistationFrm()
        {
            InitializeComponent();
        }

        private void RegistationFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            _db = ((MainFrm)this.MdiParent)._db;

            // Setup datagrid columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 8;
            dgv.Columns[0].HeaderText = "รหัส";
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "รหัสวิชา";
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].HeaderText = "ชื่อวิชา";
            dgv.Columns[2].Width = 150;
            dgv.Columns[3].HeaderText = "ทฤษฏี";
            dgv.Columns[3].Width = 50;
            dgv.Columns[4].HeaderText = "ปฏิบัติ";
            dgv.Columns[4].Width = 50;
            dgv.Columns[5].HeaderText = "รหัสนิสิต";
            dgv.Columns[5].Width = 100;
            dgv.Columns[6].HeaderText = "ชื่อนิสิต";
            dgv.Columns[6].Width = 250;
            dgv.Columns[7].HeaderText = "ปีการศึกษา";
            dgv.Columns[7].Width = 100;

            LoadRegisterToDGV(_sqlShowAll);
        }

        private void LoadRegisterToDGV(string sqlCmd)
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
                    _db.Result.GetValue(7)
                    );
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

            _db.SQLCommand = "DELETE FROM registration WHERE reg_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadRegisterToDGV(_sqlShowAll);
            }
            else
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
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
                sqlCmd += "sub.sub_id = '" + txtSearch.Text + "'";
            }
            else if (cmbType.Text == "ชื่อวิชา")
            {
                sqlCmd += "sub.sub_title like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "รหัสนิสิต")
            {
                sqlCmd += "std.std_id = '" + txtSearch.Text + "'";
            }
            else if (cmbType.Text == "ชื่อนิสิต")
            {
                sqlCmd += "std.std_name like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "ปีการศึกษา")
            {
                sqlCmd += "reg.reg_year = '" + txtSearch.Text + "'";
            }
            else
            {
                MessageBox.Show("เลือกรายการที่ต้องการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadRegisterToDGV(sqlCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadRegisterToDGV(_sqlShowAll);
        }

        private void ShowEditFrm()
        {
            if (dgv.CurrentRow == null)
            {
                return;
            }

            AddEditRegistrationFrm frm = new AddEditRegistrationFrm();
            frm.Parent = this.MdiParent;
            frm.EditMode = true;
            frm.RegID = (string)dgv.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            LoadRegisterToDGV(_sqlShowAll);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditFrm();
        }

        private void ShowAddFrm()
        {
            AddEditRegistrationFrm frm = new AddEditRegistrationFrm();
            frm.Parent = this.MdiParent;
            frm.ShowDialog();
            LoadRegisterToDGV(_sqlShowAll);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddFrm();
        }
    }
}
