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
    public partial class TeacherFrm : Form
    {
        private MySQLDatabase _db = null;
        private ContextMenu _contextMenu = null;
        private string _sqlShowAll = "SELECT t.tech_id, t.tech_name, tb.tech_brch_name, t.tech_username, t.tech_password, t.tech_question, t.tech_answer FROM teacher t JOIN teacher_branch tb ON t.tech_branch = tb.tech_brch_id";

        public TeacherFrm()
        {
            InitializeComponent();
        }

        private void TeacherFrm_Load(object sender, EventArgs e)
        {
            // Allow MSG Event
            this.KeyPreview = true;

            // Init Database
            _db = ((MainFrm)this.MdiParent)._db;

            // Init contextual menu in DGV
            BuildContextualMenu();

            // Setup datagrid columns
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 7;
            dgv.Columns[0].HeaderText = "รหัส";
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "ชื่อ-นามสกุล";
            dgv.Columns[2].HeaderText = "คณะ";
            dgv.Columns[2].Width = 200;
            dgv.Columns[3].HeaderText = "ชื่อผู้ใช้";
            dgv.Columns[4].HeaderText = "รหัสผ่าน";
            dgv.Columns[5].HeaderText = "คำถาม";
            dgv.Columns[6].HeaderText = "คำตอบ";

            LoadTeachersToDGV(_sqlShowAll);
        }

        private void BuildContextualMenu()
        {
            // Create Contextual Menu
            _contextMenu = new ContextMenu();
            // Create MenuItem
            MenuItem assgToSubject = new MenuItem("เลือกรายวิชาที่สอน");
            assgToSubject.Click += new EventHandler(contextualMenu_Click);
            // Assign MenuItem to Contextual Menu
            _contextMenu.MenuItems.Add(assgToSubject);
        }

        void contextualMenu_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                //MessageBox.Show("ไม่มีรายการที่ต้องแสดง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            AssignTeacherToSubjectFrm frm = new AssignTeacherToSubjectFrm();
            frm.Parent = this.MdiParent;
            frm.TechID = dgv.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
        }

        private void LoadTeachersToDGV(string sqlCmd)
        {
            // Load teacher_branch


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
                    _db.Result.GetValue(0),
                    _db.Result.GetValue(1),
                    _db.Result.GetValue(2),
                    _db.Result.GetValue(3),
                    "******",
                    _db.Result.GetValue(5),
                    _db.Result.GetValue(6)
                    );
            }
        }

        private void ShowAddFrm()
        {
            AddEditTeacherFrm frm = new AddEditTeacherFrm();
            frm.Parent = this.MdiParent;
            frm.ShowDialog();
            LoadTeachersToDGV(_sqlShowAll);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddFrm();
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

            _db.SQLCommand = "DELETE FROM teacher WHERE tech_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadTeachersToDGV(_sqlShowAll);
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

        private void ShowEditFrm()
        {
            if (dgv.CurrentRow == null)
            {
                return;
            }

            AddEditTeacherFrm frm = new AddEditTeacherFrm();
            frm.Parent = this.MdiParent;
            frm.EditMode = true;
            frm.TechID = (string)dgv.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            LoadTeachersToDGV(_sqlShowAll);
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

            //string sqlCmd = "SELECT * FROM teacher WHERE ";
            string sqlCmd = "SELECT t.tech_id, t.tech_name, tb.tech_brch_name, t.tech_username, t.tech_password, t.tech_question, t.tech_answer FROM teacher t JOIN teacher_branch tb ON t.tech_branch = tb.tech_brch_id AND ";
            if (cmbType.Text == "ชื่อ-นามสกุล")
            {
                sqlCmd += "t.tech_name like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "ชื่อผู้ใช้งาน")
            {
                sqlCmd += "t.tech_username='" + txtSearch.Text + "'";
            }
            else
            {
                MessageBox.Show("เลือกรายการที่ต้องการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadTeachersToDGV(sqlCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadTeachersToDGV(_sqlShowAll);
        }

        private void dgv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _contextMenu.Show(dgv, e.Location);
            }
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
