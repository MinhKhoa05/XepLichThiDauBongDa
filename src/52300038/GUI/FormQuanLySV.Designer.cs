namespace GUI
{
    partial class FormQuanLySV
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
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cboQueQuan = new System.Windows.Forms.ComboBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHocLuc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXemIn = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.grpThongTinSV = new System.Windows.Forms.GroupBox();
            this.groupbox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.grpChucNang.SuspendLayout();
            this.grpThongTinSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox3
            // 
            this.groupbox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupbox3.Controls.Add(this.dgvSinhVien);
            this.groupbox3.Location = new System.Drawing.Point(12, 194);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(776, 287);
            this.groupbox3.TabIndex = 25;
            this.groupbox3.TabStop = false;
            this.groupbox3.Text = "Danh sách sinh viên";
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(10, 21);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersWidth = 51;
            this.dgvSinhVien.RowTemplate.Height = 24;
            this.dgvSinhVien.Size = new System.Drawing.Size(750, 260);
            this.dgvSinhVien.TabIndex = 23;
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);
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
            // cboQueQuan
            // 
            this.cboQueQuan.Location = new System.Drawing.Point(139, 49);
            this.cboQueQuan.Name = "cboQueQuan";
            this.cboQueQuan.Size = new System.Drawing.Size(220, 24);
            this.cboQueQuan.TabIndex = 2;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(139, 21);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(220, 22);
            this.txtMaSV.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Ngày sinh";
            // 
            // txtHocLuc
            // 
            this.txtHocLuc.Location = new System.Drawing.Point(139, 77);
            this.txtHocLuc.Name = "txtHocLuc";
            this.txtHocLuc.Size = new System.Drawing.Size(220, 22);
            this.txtHocLuc.TabIndex = 4;
            this.txtHocLuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHocLuc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(475, 21);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(285, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Học lực";
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
            // dtNgaySinh
            // 
            this.dtNgaySinh.Location = new System.Drawing.Point(475, 49);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(285, 22);
            this.dtNgaySinh.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Quê quán";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã số sinh viên";
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
            // grpChucNang
            // 
            this.grpChucNang.BackColor = System.Drawing.SystemColors.Control;
            this.grpChucNang.Controls.Add(this.btnXemIn);
            this.grpChucNang.Controls.Add(this.btnLuu);
            this.grpChucNang.Controls.Add(this.btnHuy);
            this.grpChucNang.Controls.Add(this.btnThem);
            this.grpChucNang.Controls.Add(this.btnXoa);
            this.grpChucNang.Controls.Add(this.btnSua);
            this.grpChucNang.Location = new System.Drawing.Point(12, 129);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(776, 59);
            this.grpChucNang.TabIndex = 24;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng";
            // 
            // grpThongTinSV
            // 
            this.grpThongTinSV.BackColor = System.Drawing.SystemColors.Control;
            this.grpThongTinSV.Controls.Add(this.cboQueQuan);
            this.grpThongTinSV.Controls.Add(this.txtMaSV);
            this.grpThongTinSV.Controls.Add(this.label5);
            this.grpThongTinSV.Controls.Add(this.txtHocLuc);
            this.grpThongTinSV.Controls.Add(this.label4);
            this.grpThongTinSV.Controls.Add(this.txtHoTen);
            this.grpThongTinSV.Controls.Add(this.label3);
            this.grpThongTinSV.Controls.Add(this.dtNgaySinh);
            this.grpThongTinSV.Controls.Add(this.label2);
            this.grpThongTinSV.Controls.Add(this.label1);
            this.grpThongTinSV.Location = new System.Drawing.Point(12, 12);
            this.grpThongTinSV.Name = "grpThongTinSV";
            this.grpThongTinSV.Size = new System.Drawing.Size(776, 111);
            this.grpThongTinSV.TabIndex = 23;
            this.grpThongTinSV.TabStop = false;
            this.grpThongTinSV.Text = "Thông tin sinh viên";
            // 
            // FormQuanLySV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.groupbox3);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.grpThongTinSV);
            this.Name = "FormQuanLySV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.FormQuanLySV_Load);
            this.groupbox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.grpChucNang.ResumeLayout(false);
            this.grpThongTinSV.ResumeLayout(false);
            this.grpThongTinSV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox3;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cboQueQuan;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHocLuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXemIn;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.GroupBox grpThongTinSV;
    }
}