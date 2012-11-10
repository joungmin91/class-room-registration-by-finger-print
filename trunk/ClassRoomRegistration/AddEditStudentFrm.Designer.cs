namespace ClassRoomRegistration
{
    partial class AddEditStudentFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditStudentFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtStdID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStdName = new System.Windows.Forms.TextBox();
            this.txtStdMajor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFinger = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFingerEnroll = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFPNo = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFPStatus = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.picFP = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtStdID
            // 
            this.txtStdID.Location = new System.Drawing.Point(63, 10);
            this.txtStdID.Name = "txtStdID";
            this.txtStdID.Size = new System.Drawing.Size(160, 20);
            this.txtStdID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtStdName
            // 
            this.txtStdName.Location = new System.Drawing.Point(63, 35);
            this.txtStdName.Name = "txtStdName";
            this.txtStdName.Size = new System.Drawing.Size(271, 20);
            this.txtStdName.TabIndex = 3;
            // 
            // txtStdMajor
            // 
            this.txtStdMajor.Location = new System.Drawing.Point(63, 61);
            this.txtStdMajor.Name = "txtStdMajor";
            this.txtStdMajor.Size = new System.Drawing.Size(160, 20);
            this.txtStdMajor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Major";
            // 
            // txtFinger
            // 
            this.txtFinger.Enabled = false;
            this.txtFinger.Location = new System.Drawing.Point(63, 104);
            this.txtFinger.Name = "txtFinger";
            this.txtFinger.Size = new System.Drawing.Size(355, 20);
            this.txtFinger.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Finger";
            // 
            // btnFingerEnroll
            // 
            this.btnFingerEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFingerEnroll.Image = ((System.Drawing.Image)(resources.GetObject("btnFingerEnroll.Image")));
            this.btnFingerEnroll.Location = new System.Drawing.Point(318, 142);
            this.btnFingerEnroll.Name = "btnFingerEnroll";
            this.btnFingerEnroll.Size = new System.Drawing.Size(100, 100);
            this.btnFingerEnroll.TabIndex = 21;
            this.btnFingerEnroll.UseVisualStyleBackColor = true;
            this.btnFingerEnroll.Click += new System.EventHandler(this.btnFingerEnroll_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 265);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Required to fill data.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(12, 264);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 20);
            this.label14.TabIndex = 28;
            this.label14.Text = "*";
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(259, 264);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 27;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(343, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(229, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(340, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(229, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "*";
            // 
            // txtFPNo
            // 
            this.txtFPNo.AutoSize = true;
            this.txtFPNo.Location = new System.Drawing.Point(126, 167);
            this.txtFPNo.Name = "txtFPNo";
            this.txtFPNo.Size = new System.Drawing.Size(13, 13);
            this.txtFPNo.TabIndex = 37;
            this.txtFPNo.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(64, 167);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "No. stamp";
            // 
            // txtFPStatus
            // 
            this.txtFPStatus.AutoSize = true;
            this.txtFPStatus.Location = new System.Drawing.Point(123, 142);
            this.txtFPStatus.Name = "txtFPStatus";
            this.txtFPStatus.Size = new System.Drawing.Size(38, 13);
            this.txtFPStatus.TabIndex = 35;
            this.txtFPStatus.Text = "Ready";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(64, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Status";
            // 
            // picFP
            // 
            this.picFP.Location = new System.Drawing.Point(212, 142);
            this.picFP.Name = "picFP";
            this.picFP.Size = new System.Drawing.Size(100, 100);
            this.picFP.TabIndex = 33;
            this.picFP.TabStop = false;
            // 
            // AddEditStudentFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 300);
            this.Controls.Add(this.txtFPNo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtFPStatus);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.picFP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFingerEnroll);
            this.Controls.Add(this.txtFinger);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStdMajor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStdName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStdID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEditStudentFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddEditStudentFrm_FormClosed);
            this.Load += new System.EventHandler(this.AddEditStudentFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStdID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStdName;
        private System.Windows.Forms.TextBox txtStdMajor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFinger;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFingerEnroll;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtFPNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label txtFPStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox picFP;
    }
}