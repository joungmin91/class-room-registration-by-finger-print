namespace ClassRoomRegistration
{
    partial class ScoreFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreFrm));
            this.txtStdName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStdID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStdName
            // 
            this.txtStdName.Enabled = false;
            this.txtStdName.Location = new System.Drawing.Point(247, 12);
            this.txtStdName.Name = "txtStdName";
            this.txtStdName.Size = new System.Drawing.Size(231, 20);
            this.txtStdName.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "ชื่อนิสิต";
            // 
            // txtStdID
            // 
            this.txtStdID.Enabled = false;
            this.txtStdID.Location = new System.Drawing.Point(60, 12);
            this.txtStdID.Name = "txtStdID";
            this.txtStdID.Size = new System.Drawing.Size(118, 20);
            this.txtStdID.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "รหัส";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "คะแนน";
            // 
            // dgvScore
            // 
            this.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScore.Location = new System.Drawing.Point(15, 65);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.Size = new System.Drawing.Size(463, 194);
            this.dgvScore.TabIndex = 64;
            this.dgvScore.SelectionChanged += new System.EventHandler(this.dgvScore_SelectionChanged);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(403, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 66;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTotal.ForeColor = System.Drawing.Color.Green;
            this.txtTotal.Location = new System.Drawing.Point(12, 270);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(87, 16);
            this.txtTotal.TabIndex = 67;
            this.txtTotal.Text = "คะแนนทั้งหมด";
            // 
            // ScoreFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 300);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStdName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStdID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScoreFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ให้คะแนนนิสิต";
            this.Load += new System.EventHandler(this.ScoreFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStdName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStdID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvScore;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label txtTotal;
    }
}