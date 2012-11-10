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

        public TeacherFrm()
        {
            InitializeComponent();
        }

        private void TeacherFrm_Load(object sender, EventArgs e)
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
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "First Name";
            dgv.Columns[2].HeaderText = "Last Name";
            dgv.Columns[3].HeaderText = "Address";
            dgv.Columns[4].HeaderText = "Phone";
            dgv.Columns[5].HeaderText = "Username";
            dgv.Columns[6].HeaderText = "Password";
            dgv.Columns[7].HeaderText = "Type";

            LoadTeachersToDGV("SELECT * FROM teacher");
        }

        private void LoadTeachersToDGV(string sqlCmd)
        {
            // Clear DGV
            dgv.Rows.Clear();
            // Query all teacher.
            _db.SQLCommand = sqlCmd;
            _db.Query();

            if (_db.Result.HasRows == false)
            {
                MessageBox.Show("No records return from database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
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
                    _db.Result.GetValue(8)
                    );
            }
        }

        private void ShowAddFrm()
        {
            AddEditTeacherFrm frm = new AddEditTeacherFrm();
            frm.Parent = this.MdiParent;
            frm.ShowDialog();
            LoadTeachersToDGV("SELECT * FROM teacher");
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

            _db.SQLCommand = "DELETE FROM teacher WHERE tech_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadTeachersToDGV("SELECT * FROM teacher");
            }
            else
            {
                MessageBox.Show("Record cannot be deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadTeachersToDGV("SELECT * FROM teacher");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditFrm();
        }

        private void TeacherFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                ShowAddFrm();
            }
            else if (e.Control == true && e.KeyCode == Keys.E)
            {
                ShowEditFrm();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                ShowDeleteFrm();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqlCmd = "SELECT * FROM teacher WHERE ";
            if (cmbType.Text == "First Name")
            {
                sqlCmd += "tech_fname like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "Last Name")
            {
                sqlCmd += "tech_lname like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "Address")
            {
                sqlCmd += "tech_addr like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "Phone")
            {
                sqlCmd += "tech_phone like '%" + txtSearch.Text + "%'";
            }
            else if (cmbType.Text == "Username")
            {
                sqlCmd += "tech_username='" + txtSearch.Text + "'";
            }
            LoadTeachersToDGV(sqlCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadTeachersToDGV("SELECT * FROM teacher");
        }
    }
}
