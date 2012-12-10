namespace ClassRoomRegistration
{
    partial class CheckinStdFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckinStdFrm));
            this.txtStdName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStdID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFinger = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picFP = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStdName
            // 
            this.txtStdName.Enabled = false;
            this.txtStdName.Location = new System.Drawing.Point(249, 12);
            this.txtStdName.Name = "txtStdName";
            this.txtStdName.Size = new System.Drawing.Size(231, 20);
            this.txtStdName.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "ชื่อนิสิต";
            // 
            // txtStdID
            // 
            this.txtStdID.Enabled = false;
            this.txtStdID.Location = new System.Drawing.Point(62, 12);
            this.txtStdID.Name = "txtStdID";
            this.txtStdID.Size = new System.Drawing.Size(118, 20);
            this.txtStdID.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "รหัส";
            // 
            // txtFinger
            // 
            this.txtFinger.Enabled = false;
            this.txtFinger.Location = new System.Drawing.Point(62, 38);
            this.txtFinger.Name = "txtFinger";
            this.txtFinger.Size = new System.Drawing.Size(417, 20);
            this.txtFinger.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "นิ้วมือ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(379, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // picFP
            // 
            this.picFP.Location = new System.Drawing.Point(273, 64);
            this.picFP.Name = "picFP";
            this.picFP.Size = new System.Drawing.Size(100, 100);
            this.picFP.TabIndex = 61;
            this.picFP.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "วันที่";
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(62, 64);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(118, 20);
            this.txtDate.TabIndex = 64;
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(404, 185);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 66;
            this.btnStop.Text = "หยุด";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtError
            // 
            this.txtError.AutoSize = true;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtError.ForeColor = System.Drawing.Color.Red;
            this.txtError.Location = new System.Drawing.Point(15, 185);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(153, 16);
            this.txtError.TabIndex = 67;
            this.txtError.Text = "ไม่มีลายนิ้วมือนี้ในฐานข้อมูล";
            // 
            // CheckinStdFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 220);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picFP);
            this.Controls.Add(this.txtFinger);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStdName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStdID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckinStdFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เช๊คชื่อนิสิต";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CheckinStdFrm_FormClosed);
            this.Load += new System.EventHandler(this.CheckinStdFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStdName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStdID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFinger;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picFP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label txtError;
    }
}