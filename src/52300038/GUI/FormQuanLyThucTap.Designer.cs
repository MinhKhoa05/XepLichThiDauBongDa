namespace GUI
{
    partial class FormQuanLyThucTap
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
            this.grpThongTinTT = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXemIn = new System.Windows.Forms.Button();
            this.dgvKetQuaThucTap = new System.Windows.Forms.DataGridView();
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.cboQuequan = new System.Windows.Forms.ComboBox();
            this.grpThongTinTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaThucTap)).BeginInit();
            this.groupbox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTinTT
            // 
            this.grpThongTinTT.BackColor = System.Drawing.SystemColors.Control;
            this.grpThongTinTT.Controls.Add(this.btnXemIn);
            this.grpThongTinTT.Controls.Add(this.cboQuequan);
            this.grpThongTinTT.Controls.Add(this.label1);
            this.grpThongTinTT.Controls.Add(this.btnThem);
            this.grpThongTinTT.Location = new System.Drawing.Point(12, 12);
            this.grpThongTinTT.Name = "grpThongTinTT";
            this.grpThongTinTT.Size = new System.Drawing.Size(776, 111);
            this.grpThongTinTT.TabIndex = 26;
            this.grpThongTinTT.TabStop = false;
            this.grpThongTinTT.Text = "Tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Quê quán";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(486, 16);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Tất cả";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXemIn
            // 
            this.btnXemIn.Location = new System.Drawing.Point(591, 16);
            this.btnXemIn.Name = "btnXemIn";
            this.btnXemIn.Size = new System.Drawing.Size(77, 32);
            this.btnXemIn.TabIndex = 5;
            this.btnXemIn.Text = "Xem in";
            this.btnXemIn.UseVisualStyleBackColor = true;
            // 
            // dgvKetQuaThucTap
            // 
            this.dgvKetQuaThucTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQuaThucTap.Location = new System.Drawing.Point(10, 21);
            this.dgvKetQuaThucTap.Name = "dgvKetQuaThucTap";
            this.dgvKetQuaThucTap.RowHeadersWidth = 51;
            this.dgvKetQuaThucTap.RowTemplate.Height = 24;
            this.dgvKetQuaThucTap.Size = new System.Drawing.Size(750, 213);
            this.dgvKetQuaThucTap.TabIndex = 23;
            this.dgvKetQuaThucTap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQuaThucTap_CellClick);
            this.dgvKetQuaThucTap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQuaThucTap_CellContentClick);
            // 
            // groupbox3
            // 
            this.groupbox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupbox3.Controls.Add(this.dgvKetQuaThucTap);
            this.groupbox3.Location = new System.Drawing.Point(12, 129);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(776, 240);
            this.groupbox3.TabIndex = 28;
            this.groupbox3.TabStop = false;
            this.groupbox3.Text = "Kết quả thực tập";
            this.groupbox3.Enter += new System.EventHandler(this.groupbox3_Enter);
            // 
            // cboQuequan
            // 
            this.cboQuequan.FormattingEnabled = true;
            this.cboQuequan.Location = new System.Drawing.Point(78, 21);
            this.cboQuequan.Name = "cboQuequan";
            this.cboQuequan.Size = new System.Drawing.Size(378, 24);
            this.cboQuequan.TabIndex = 27;
            this.cboQuequan.SelectedIndexChanged += new System.EventHandler(this.cboQuequan_SelectedIndexChanged);
            // 
            // FormQuanLyThucTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 446);
            this.Controls.Add(this.grpThongTinTT);
            this.Controls.Add(this.groupbox3);
            this.Name = "FormQuanLyThucTap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm sinh viên theo quê quán";
            this.Load += new System.EventHandler(this.FormQuanLyThucTap_Load);
            this.grpThongTinTT.ResumeLayout(false);
            this.grpThongTinTT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaThucTap)).EndInit();
            this.groupbox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTinTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXemIn;
        private System.Windows.Forms.DataGridView dgvKetQuaThucTap;
        private System.Windows.Forms.GroupBox groupbox3;
        private System.Windows.Forms.ComboBox cboQuequan;
    }
}