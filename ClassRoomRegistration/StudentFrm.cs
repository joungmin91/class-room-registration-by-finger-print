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
            dgv.ColumnCount = 3;
            dgv.Columns[0].HeaderText = "Student ID";
            dgv.Columns[1].HeaderText = "Student Name";
            dgv.Columns[1].Width = 480;
            dgv.Columns[2].HeaderText = "Student Major";

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
                MessageBox.Show("No records return from database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                dgv.Rows.Add(
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

            _db.SQLCommand = "DELETE FROM student WHERE std_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadStudentToDGV("SELECT * FROM student");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqlCmd = "SELECT * FROM student WHERE ";
            if (cmbType.Text == "Student ID")
            {
                sqlCmd += "std_id='" + txtSearch.Text + "'";
            }
            else if (cmbType.Text == "Student Name")
            {
                sqlCmd += "std_name like '%" + txtSearch.Text + "%'";
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
            frm.StudentID = (string)dgv.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            LoadStudentToDGV("SELECT * FROM student");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditFrm();
        }
    }
}
