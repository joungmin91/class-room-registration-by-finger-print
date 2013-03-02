namespace ClassRoomRegistration
{
    partial class AddEditTeacherFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditTeacherFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBrch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbQuestion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อ-นามสกุล";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(351, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(75, 104);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(351, 20);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ยูสเซอร์เนม";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(351, 20);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "รหัสผ่าน";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(351, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(270, 273);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(423, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(423, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(423, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(12, 273);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 20);
            this.label14.TabIndex = 24;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 274);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "จำเป้นต้องใส่ข้อมูล";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "คณะ";
            // 
            // cmbBrch
            // 
            this.cmbBrch.FormattingEnabled = true;
            this.cmbBrch.Location = new System.Drawing.Point(75, 54);
            this.cmbBrch.Name = "cmbBrch";
            this.cmbBrch.Size = new System.Drawing.Size(351, 21);
            this.cmbBrch.TabIndex = 27;
            this.cmbBrch.SelectedIndexChanged += new System.EventHandler(this.cmbBrch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(423, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "กรณีที่ลืมรหัสผ่าน กรุณาใส่คำถาม และคำตอบ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(423, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "คำถาม";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(423, 228);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "*";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(75, 228);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(351, 20);
            this.txtAnswer.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 231);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "คำตอบ";
            // 
            // cmbQuestion
            // 
            this.cmbQuestion.FormattingEnabled = true;
            this.cmbQuestion.Items.AddRange(new object[] {
            "ชื่อเล่นชื่ออะไร",
            "ชอบสีอะไร",
            "งานอดิเรกทำอะไร",
            "ชอบกินอะไร"});
            this.cmbQuestion.Location = new System.Drawing.Point(75, 202);
            this.cmbQuestion.Name = "cmbQuestion";
            this.cmbQuestion.Size = new System.Drawing.Size(351, 21);
            this.cmbQuestion.TabIndex = 36;
            // 
            // AddEditTeacherFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 313);
            this.Controls.Add(this.cmbQuestion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbBrch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEditTeacherFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลอาจารย์";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddEditTeacherFrm_FormClosed);
            this.Load += new System.EventHandler(this.AddEditTeacherFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBrch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbQuestion;
    }
}