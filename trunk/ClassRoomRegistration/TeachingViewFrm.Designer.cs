namespace ClassRoomRegistration
{
    partial class TeachingViewFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeachingViewFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSubject = new System.Windows.Forms.DataGridView();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFinger = new System.Windows.Forms.Button();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "รายวิชาที่สอน";
            // 
            // dgvSubject
            // 
            this.dgvSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubject.Location = new System.Drawing.Point(15, 41);
            this.dgvSubject.Name = "dgvSubject";
            this.dgvSubject.Size = new System.Drawing.Size(757, 93);
            this.dgvSubject.TabIndex = 1;
            this.dgvSubject.SelectionChanged += new System.EventHandler(this.dgvSubject_SelectionChanged);
            // 
            // dgvStudent
            // 
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Location = new System.Drawing.Point(15, 164);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.Size = new System.Drawing.Size(757, 316);
            this.dgvStudent.TabIndex = 3;
            this.dgvStudent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvStudent_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "นิสิตที่ลงทะเบียน";
            // 
            // btnFinger
            // 
            this.btnFinger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinger.Image = ((System.Drawing.Image)(resources.GetObject("btnFinger.Image")));
            this.btnFinger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinger.Location = new System.Drawing.Point(498, 12);
            this.btnFinger.Name = "btnFinger";
            this.btnFinger.Size = new System.Drawing.Size(102, 23);
            this.btnFinger.TabIndex = 4;
            this.btnFinger.Text = "เก็บลายนิ้วมือ";
            this.btnFinger.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinger.UseVisualStyleBackColor = true;
            this.btnFinger.Click += new System.EventHandler(this.btnFinger_Click);
            // 
            // btnCheckin
            // 
            this.btnCheckin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckin.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckin.Image")));
            this.btnCheckin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckin.Location = new System.Drawing.Point(702, 12);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(70, 23);
            this.btnCheckin.TabIndex = 5;
            this.btnCheckin.Text = "เช็คชื่อ";
            this.btnCheckin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // btnScore
            // 
            this.btnScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScore.Image = ((System.Drawing.Image)(resources.GetObject("btnScore.Image")));
            this.btnScore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScore.Location = new System.Drawing.Point(606, 12);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(90, 23);
            this.btnScore.TabIndex = 6;
            this.btnScore.Text = "ให้คะแนน";
            this.btnScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScore.UseVisualStyleBackColor = true;
            this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
            // 
            // TeachingViewFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 492);
            this.Controls.Add(this.btnScore);
            this.Controls.Add(this.btnCheckin);
            this.Controls.Add(this.btnFinger);
            this.Controls.Add(this.dgvStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSubject);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeachingViewFrm";
            this.Text = "รายวิชาที่สอน";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TeachingViewFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSubject;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFinger;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.Button btnScore;
    }
}