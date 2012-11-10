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
    public partial class AddEditSubjectFrm : Form
    {
        public Form Parent { get; set; }
        public bool EditMode { get; set; }
        public string SubjectID { get; set; }
        private MySQLDatabase _db = null;

        public AddEditSubjectFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check required field.
            if (txtSubID.Text == "" || txtSubName.Text == "")
            {
                MessageBox.Show("You must fill all required field.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EditMode == true)
            {
                // Update the record.
                _db.SQLCommand = "UPDATE subject SET ";
                _db.SQLCommand += "sub_title='" + txtSubName.Text + "' ";
                _db.SQLCommand += "WHERE sub_id='" + SubjectID + "' ";
                if (_db.Query() == true)
                {
                    MessageBox.Show("Record has been updated into database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Record cannot be updated into database. SQL = " + _db.SQLCommand, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Insert the record.
                _db.SQLCommand = "INSERT INTO subject (sub_id, sub_title) VALUES ('" + txtSubID.Text + "', '" + txtSubName.Text + "')";
                if (_db.Query() == true)
                {
                    MessageBox.Show("Record has been inserted into database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Record cannot be inserted into database. SQL = " + _db.SQLCommand, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddEditSubjectFrm_Load(object sender, EventArgs e)
        {
            _db = ((MainFrm)Parent)._db;
            if (EditMode == true)
            {
                _db.SQLCommand = "SELECT * FROM subject WHERE sub_id='" + SubjectID + "'";
                _db.Query();
                if (_db.Result.HasRows)
                {
                    _db.Result.Read();
                    txtSubID.Text = (string)_db.Result.GetValue(0);
                    txtSubName.Text = (string)_db.Result.GetValue(1);
                }
            }
        }
    }
}
