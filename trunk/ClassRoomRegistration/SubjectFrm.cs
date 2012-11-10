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
            dgv.ColumnCount = 2;
            dgv.Columns[0].HeaderText = "Subject ID";
            dgv.Columns[1].HeaderText = "Subject Name";
            dgv.Columns[1].Width = 610;
            
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
                MessageBox.Show("No records return from database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Insert rows to DGV
            while (_db.Result.Read())
            {
                dgv.Rows.Add(
                    _db.Result.GetValue(0),
                    _db.Result.GetValue(1)
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

            _db.SQLCommand = "DELETE FROM subject WHERE sub_id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'";
            if (_db.Query() == true)
            {
                LoadSubjectToDGV("SELECT * FROM subject");
            }
            else
            {
                MessageBox.Show("Record cannot be deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SubjectFrm_KeyDown(object sender, KeyEventArgs e)
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
            string sqlCmd = "SELECT * FROM subject WHERE ";
            if (cmbType.Text == "Subject ID")
            {
                sqlCmd += "sub_id='" + txtSearch.Text + "'";
            }
            else if (cmbType.Text == "Subject Name")
            {
                sqlCmd += "sub_title like '%" + txtSearch.Text + "%'";
            }
            LoadSubjectToDGV(sqlCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadSubjectToDGV("SELECT * FROM subject");
        }
    }
}
