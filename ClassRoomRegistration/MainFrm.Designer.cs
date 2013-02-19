namespace ClassRoomRegistration
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTeacher = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTeaching = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRegister = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonImport = new System.Windows.Forms.ToolStripButton();
            this.teachToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTechSubject = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSetting = new System.Windows.Forms.ToolStripButton();
            this.mainMenu.SuspendLayout();
            this.mainToolbar.SuspendLayout();
            this.teachToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 25);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "ไฟล์";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.logoutToolStripMenuItem.Text = "ล๊อกเอาท์";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "จบโปรแกรม";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
            this.setupToolStripMenuItem.Text = "ตั้งค่า";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.configToolStripMenuItem.Text = "ตั้งค่าโปรแกรม";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.helpToolStripMenuItem.Text = "ช่วยเหลือ";
            // 
            // mainToolbar
            // 
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTeacher,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButtonTeaching,
            this.toolStripButtonRegister,
            this.toolStripSeparator1,
            this.toolStripButtonImport});
            this.mainToolbar.Location = new System.Drawing.Point(0, 25);
            this.mainToolbar.Name = "mainToolbar";
            this.mainToolbar.Size = new System.Drawing.Size(784, 39);
            this.mainToolbar.TabIndex = 3;
            this.mainToolbar.Text = "toolStrip1";
            // 
            // toolStripButtonTeacher
            // 
            this.toolStripButtonTeacher.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTeacher.Image")));
            this.toolStripButtonTeacher.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTeacher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTeacher.Name = "toolStripButtonTeacher";
            this.toolStripButtonTeacher.Size = new System.Drawing.Size(78, 36);
            this.toolStripButtonTeacher.Text = "อาจารย์";
            this.toolStripButtonTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButtonTeacher.Click += new System.EventHandler(this.toolStripButtonTeacher_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(64, 36);
            this.toolStripButton1.Text = "นิสิต";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(61, 36);
            this.toolStripButton2.Text = "วิชา";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButtonTeaching
            // 
            this.toolStripButtonTeaching.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTeaching.Image")));
            this.toolStripButtonTeaching.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTeaching.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTeaching.Name = "toolStripButtonTeaching";
            this.toolStripButtonTeaching.Size = new System.Drawing.Size(81, 36);
            this.toolStripButtonTeaching.Text = "การสอน";
            this.toolStripButtonTeaching.ToolTipText = "ข้อมูลการสอน";
            this.toolStripButtonTeaching.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButtonRegister
            // 
            this.toolStripButtonRegister.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRegister.Image")));
            this.toolStripButtonRegister.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRegister.Name = "toolStripButtonRegister";
            this.toolStripButtonRegister.Size = new System.Drawing.Size(93, 36);
            this.toolStripButtonRegister.Text = "ลงทะเบียน";
            this.toolStripButtonRegister.ToolTipText = "ข้อมูลการลงทะเบียนเรียน";
            this.toolStripButtonRegister.Click += new System.EventHandler(this.toolStripButtonRegister_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonImport
            // 
            this.toolStripButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImport.Image")));
            this.toolStripButtonImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImport.Name = "toolStripButtonImport";
            this.toolStripButtonImport.Size = new System.Drawing.Size(99, 36);
            this.toolStripButtonImport.Text = "นำเข้าข้อมูล";
            this.toolStripButtonImport.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // teachToolbar
            // 
            this.teachToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTechSubject,
            this.toolStripButtonSetting});
            this.teachToolbar.Location = new System.Drawing.Point(0, 64);
            this.teachToolbar.Name = "teachToolbar";
            this.teachToolbar.Size = new System.Drawing.Size(784, 39);
            this.teachToolbar.TabIndex = 5;
            this.teachToolbar.Text = "toolStrip1";
            // 
            // toolStripButtonTechSubject
            // 
            this.toolStripButtonTechSubject.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTechSubject.Image")));
            this.toolStripButtonTechSubject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTechSubject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTechSubject.Name = "toolStripButtonTechSubject";
            this.toolStripButtonTechSubject.Size = new System.Drawing.Size(106, 36);
            this.toolStripButtonTechSubject.Text = "รายวิชาที่สอน";
            this.toolStripButtonTechSubject.Click += new System.EventHandler(this.toolStripButtonTechSubject_Click);
            // 
            // toolStripButtonSetting
            // 
            this.toolStripButtonSetting.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSetting.Image")));
            this.toolStripButtonSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetting.Name = "toolStripButtonSetting";
            this.toolStripButtonSetting.Size = new System.Drawing.Size(105, 36);
            this.toolStripButtonSetting.Text = "ตั้งค่าผู้ใช้งาน";
            this.toolStripButtonSetting.Click += new System.EventHandler(this.toolStripButtonSetting_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.teachToolbar);
            this.Controls.Add(this.mainToolbar);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ระบบตรวจสอบรายชื่อและจัดการคะแนนนิสิตด้วยการสแกนลายนิ้วมือ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFrm_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
            this.teachToolbar.ResumeLayout(false);
            this.teachToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.ToolStripButton toolStripButtonTeacher;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButtonImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonTeaching;
        private System.Windows.Forms.ToolStripButton toolStripButtonRegister;
        private System.Windows.Forms.ToolStrip teachToolbar;
        private System.Windows.Forms.ToolStripButton toolStripButtonTechSubject;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetting;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
    }
}

