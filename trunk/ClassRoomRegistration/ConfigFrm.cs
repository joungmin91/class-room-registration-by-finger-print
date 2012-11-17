using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ClassRoomRegistration
{
    public partial class ConfigFrm : Form
    {
        public ConfigFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtDBName.Text == "")
            {
                MessageBox.Show("ใส่ข้อมูลไม่ครบ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StreamWriter sw = new StreamWriter("app-config.xml");
            sw.WriteLine("<config>");
            sw.WriteLine("<db-server>" + txtServer.Text + "</db-server>");
            sw.WriteLine("<db-username>" + txtUsername.Text + "</db-username>");
            sw.WriteLine("<db-password>" + txtPassword.Text + "</db-password>");
            sw.WriteLine("<db-dbname>" + txtDBName.Text + "</db-dbname>");
            sw.WriteLine("</config>");
            sw.Close();

            MessageBox.Show("การตั้งค่าจะมีผลเมื่อเปิดโปรแกรมในครั้งต่อไป", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("app-config.xml");
            txtServer.Text = doc.SelectSingleNode("//db-server").InnerText;
            txtUsername.Text = doc.SelectSingleNode("//db-username").InnerText;
            txtPassword.Text = doc.SelectSingleNode("//db-password").InnerText;
            txtDBName.Text = doc.SelectSingleNode("//db-dbname").InnerText;
        }
    }
}
