namespace ClassRoomRegistration
{
    partial class ScanFingerStdFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanFingerStdFrm));
            this.txtFPNo = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFPStatus = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.picFP = new System.Windows.Forms.PictureBox();
            this.txtFinger = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtStdID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStdName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFPNo
            // 
            this.txtFPNo.AutoSize = true;
            this.txtFPNo.Location = new System.Drawing.Point(126, 104);
            this.txtFPNo.Name = "txtFPNo";
            this.txtFPNo.Size = new System.Drawing.Size(13, 13);
            this.txtFPNo.TabIndex = 49;
            this.txtFPNo.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(64, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 48;
            this.label17.Text = "จำนวนครั้ง";
            // 
            // txtFPStatus
            // 
            this.txtFPStatus.AutoSize = true;
            this.txtFPStatus.Location = new System.Drawing.Point(123, 79);
            this.txtFPStatus.Name = "txtFPStatus";
            this.txtFPStatus.Size = new System.Drawing.Size(34, 13);
            this.txtFPStatus.TabIndex = 47;
            this.txtFPStatus.Text = "พร้อม";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(64, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 46;
            this.label16.Text = "สถานะ";
            // 
            // picFP
            // 
            this.picFP.Location = new System.Drawing.Point(274, 79);
            this.picFP.Name = "picFP";
            this.picFP.Size = new System.Drawing.Size(100, 100);
            this.picFP.TabIndex = 45;
            this.picFP.TabStop = false;
            // 
            // txtFinger
            // 
            this.txtFinger.Enabled = false;
            this.txtFinger.Location = new System.Drawing.Point(63, 41);
            this.txtFinger.Name = "txtFinger";
            this.txtFinger.Size = new System.Drawing.Size(417, 20);
            this.txtFinger.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "นิ้วมือ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(380, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // txtStdID
            // 
            this.txtStdID.Enabled = false;
            this.txtStdID.Location = new System.Drawing.Point(62, 15);
            this.txtStdID.Name = "txtStdID";
            this.txtStdID.Size = new System.Drawing.Size(118, 20);
            this.txtStdID.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "รหัส";
            // 
            // txtStdName
            // 
            this.txtStdName.Enabled = false;
            this.txtStdName.Location = new System.Drawing.Point(249, 15);
            this.txtStdName.Name = "txtStdName";
            this.txtStdName.Size = new System.Drawing.Size(231, 20);
            this.txtStdName.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "ชื่อนิสิต";
            // 
            // txtResult
            // 
            this.txtResult.AutoSize = true;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtResult.ForeColor = System.Drawing.Color.Black;
            this.txtResult.Location = new System.Drawing.Point(13, 200);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(0, 13);
            this.txtResult.TabIndex = 55;
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(321, 195);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 57;
            this.btnStop.Text = "หยุด";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(405, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 56;
            this.btnCancel.Text = "ข้าม";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ScanFingerStdFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 227);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtStdName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStdID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFPNo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtFPStatus);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.picFP);
            this.Controls.Add(this.txtFinger);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScanFingerStdFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "สแกนลายนิ้วมือนิสิต";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScanFingerStdFrm_FormClosed);
            this.Load += new System.EventHandler(this.ScanFingerStdFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtFPNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label txtFPStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox picFP;
        private System.Windows.Forms.TextBox txtFinger;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtStdID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStdName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtResult;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCancel;
    }
}