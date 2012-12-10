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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeachingViewFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSubject = new System.Windows.Forms.DataGridView();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFinger = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.tabCtrlRegis = new System.Windows.Forms.TabControl();
            this.tabPageCheckin = new System.Windows.Forms.TabPage();
            this.tabPageScore = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.tabCtrlRegis.SuspendLayout();
            this.tabPageCheckin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "รายวิชาที่สอน";
            // 
            // dgvSubject
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubject.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubject.Location = new System.Drawing.Point(15, 27);
            this.dgvSubject.Name = "dgvSubject";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubject.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubject.Size = new System.Drawing.Size(757, 93);
            this.dgvSubject.TabIndex = 1;
            this.dgvSubject.SelectionChanged += new System.EventHandler(this.dgvSubject_SelectionChanged);
            // 
            // dgvStudent
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudent.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStudent.Location = new System.Drawing.Point(6, 6);
            this.dgvStudent.Name = "dgvStudent";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudent.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStudent.Size = new System.Drawing.Size(737, 263);
            this.dgvStudent.TabIndex = 3;
            this.dgvStudent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvStudent_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 134);
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
            this.btnFinger.Location = new System.Drawing.Point(613, 275);
            this.btnFinger.Name = "btnFinger";
            this.btnFinger.Size = new System.Drawing.Size(130, 23);
            this.btnFinger.TabIndex = 4;
            this.btnFinger.Text = "เก็บลายนิ้วมือทั้งหมด";
            this.btnFinger.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinger.UseVisualStyleBackColor = true;
            this.btnFinger.Click += new System.EventHandler(this.btnFinger_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckAll.Image")));
            this.btnCheckAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckAll.Location = new System.Drawing.Point(508, 275);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(99, 23);
            this.btnCheckAll.TabIndex = 5;
            this.btnCheckAll.Text = "เช็กชื่อทั้งหมด";
            this.btnCheckAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // tabCtrlRegis
            // 
            this.tabCtrlRegis.Controls.Add(this.tabPageCheckin);
            this.tabCtrlRegis.Controls.Add(this.tabPageScore);
            this.tabCtrlRegis.Location = new System.Drawing.Point(15, 150);
            this.tabCtrlRegis.Name = "tabCtrlRegis";
            this.tabCtrlRegis.SelectedIndex = 0;
            this.tabCtrlRegis.Size = new System.Drawing.Size(757, 330);
            this.tabCtrlRegis.TabIndex = 6;
            // 
            // tabPageCheckin
            // 
            this.tabPageCheckin.Controls.Add(this.dgvStudent);
            this.tabPageCheckin.Controls.Add(this.btnCheckAll);
            this.tabPageCheckin.Controls.Add(this.btnFinger);
            this.tabPageCheckin.Location = new System.Drawing.Point(4, 22);
            this.tabPageCheckin.Name = "tabPageCheckin";
            this.tabPageCheckin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheckin.Size = new System.Drawing.Size(749, 304);
            this.tabPageCheckin.TabIndex = 0;
            this.tabPageCheckin.Text = "เช็กชื่อนิสิต";
            this.tabPageCheckin.UseVisualStyleBackColor = true;
            // 
            // tabPageScore
            // 
            this.tabPageScore.Location = new System.Drawing.Point(4, 22);
            this.tabPageScore.Name = "tabPageScore";
            this.tabPageScore.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScore.Size = new System.Drawing.Size(749, 290);
            this.tabPageScore.TabIndex = 1;
            this.tabPageScore.Text = "คะแนน";
            this.tabPageScore.UseVisualStyleBackColor = true;
            // 
            // TeachingViewFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 492);
            this.Controls.Add(this.tabCtrlRegis);
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
            this.tabCtrlRegis.ResumeLayout(false);
            this.tabPageCheckin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSubject;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFinger;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.TabControl tabCtrlRegis;
        private System.Windows.Forms.TabPage tabPageCheckin;
        private System.Windows.Forms.TabPage tabPageScore;
    }
}