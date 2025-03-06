namespace GUI
{
    partial class FormQuanLyDeTai
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
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnXemIn = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.cboChuNhiem = new System.Windows.Forms.ComboBox();
            this.txtMaDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenDT = new System.Windows.Forms.TextBox();
            this.dgvDeTai = new System.Windows.Forms.DataGridView();
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpThongTinDT = new System.Windows.Forms.GroupBox();
            this.txtKinhPhi = new System.Windows.Forms.TextBox();
            this.grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeTai)).BeginInit();
            this.groupbox3.SuspendLayout();
            this.grpThongTinDT.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpChucNang
            // 
            this.grpChucNang.BackColor = System.Drawing.SystemColors.Control;
            this.grpChucNang.Controls.Add(this.btnXemIn);
            this.grpChucNang.Controls.Add(this.btnLuu);
            this.grpChucNang.Controls.Add(this.btnHuy);
            this.grpChucNang.Controls.Add(this.btnThem);
            this.grpChucNang.Controls.Add(this.btnXoa);
            this.grpChucNang.Controls.Add(this.btnSua);
            this.grpChucNang.Location = new System.Drawing.Point(12, 105);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(776, 59);
            this.grpChucNang.TabIndex = 27;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng";
            // 
            // btnXemIn
            // 
            this.btnXemIn.Location = new System.Drawing.Point(543, 18);
            this.btnXemIn.Name = "btnXemIn";
            this.btnXemIn.Size = new System.Drawing.Size(77, 32);
            this.btnXemIn.TabIndex = 5;
            this.btnXemIn.Text = "Xem in";
            this.btnXemIn.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(381, 18);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 32);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(462, 18);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 32);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(138, 18);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(219, 18);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(300, 18);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 32);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // cboChuNhiem
            // 
            this.cboChuNhiem.Location = new System.Drawing.Point(139, 49);
            this.cboChuNhiem.Name = "cboChuNhiem";
            this.cboChuNhiem.Size = new System.Drawing.Size(220, 24);
            this.cboChuNhiem.TabIndex = 2;
            // 
            // txtMaDT
            // 
            this.txtMaDT.Location = new System.Drawing.Point(139, 21);
            this.txtMaDT.Name = "txtMaDT";
            this.txtMaDT.Size = new System.Drawing.Size(220, 22);
            this.txtMaDT.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Kinh phí";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Tên đề tài";
            // 
            // txtTenDT
            // 
            this.txtTenDT.Location = new System.Drawing.Point(475, 21);
            this.txtTenDT.Name = "txtTenDT";
            this.txtTenDT.Size = new System.Drawing.Size(285, 22);
            this.txtTenDT.TabIndex = 1;
            // 
            // dgvDeTai
            // 
            this.dgvDeTai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeTai.Location = new System.Drawing.Point(10, 21);
            this.dgvDeTai.Name = "dgvDeTai";
            this.dgvDeTai.RowHeadersWidth = 51;
            this.dgvDeTai.RowTemplate.Height = 24;
            this.dgvDeTai.Size = new System.Drawing.Size(750, 260);
            this.dgvDeTai.TabIndex = 23;
            this.dgvDeTai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeTai_CellClick);
            // 
            // groupbox3
            // 
            this.groupbox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupbox3.Controls.Add(this.dgvDeTai);
            this.groupbox3.Location = new System.Drawing.Point(12, 170);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(776, 287);
            this.groupbox3.TabIndex = 28;
            this.groupbox3.TabStop = false;
            this.groupbox3.Text = "Danh sách đề tài";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Chủ nhiệm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã số đề tài";
            // 
            // grpThongTinDT
            // 
            this.grpThongTinDT.BackColor = System.Drawing.SystemColors.Control;
            this.grpThongTinDT.Controls.Add(this.txtKinhPhi);
            this.grpThongTinDT.Controls.Add(this.cboChuNhiem);
            this.grpThongTinDT.Controls.Add(this.txtMaDT);
            this.grpThongTinDT.Controls.Add(this.label5);
            this.grpThongTinDT.Controls.Add(this.label4);
            this.grpThongTinDT.Controls.Add(this.txtTenDT);
            this.grpThongTinDT.Controls.Add(this.label2);
            this.grpThongTinDT.Controls.Add(this.label1);
            this.grpThongTinDT.Location = new System.Drawing.Point(12, 12);
            this.grpThongTinDT.Name = "grpThongTinDT";
            this.grpThongTinDT.Size = new System.Drawing.Size(776, 87);
            this.grpThongTinDT.TabIndex = 26;
            this.grpThongTinDT.TabStop = false;
            this.grpThongTinDT.Text = "Thông tin đề tài";
            // 
            // txtKinhPhi
            // 
            this.txtKinhPhi.Location = new System.Drawing.Point(475, 49);
            this.txtKinhPhi.Name = "txtKinhPhi";
            this.txtKinhPhi.Size = new System.Drawing.Size(285, 22);
            this.txtKinhPhi.TabIndex = 31;
            this.txtKinhPhi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKinhPhi_KeyPress);
            // 
            // FormQuanLyDeTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.groupbox3);
            this.Controls.Add(this.grpThongTinDT);
            this.Name = "FormQuanLyDeTai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Đề tài";
            this.Load += new System.EventHandler(this.FormQuanLyDeTai_Load);
            this.grpChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeTai)).EndInit();
            this.groupbox3.ResumeLayout(false);
            this.grpThongTinDT.ResumeLayout(false);
            this.grpThongTinDT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnXemIn;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.ComboBox cboChuNhiem;
        private System.Windows.Forms.TextBox txtMaDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenDT;
        private System.Windows.Forms.DataGridView dgvDeTai;
        private System.Windows.Forms.GroupBox groupbox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpThongTinDT;
        private System.Windows.Forms.TextBox txtKinhPhi;
    }
}