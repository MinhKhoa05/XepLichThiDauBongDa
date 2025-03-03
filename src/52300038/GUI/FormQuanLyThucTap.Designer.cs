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
            this.cboDeTai = new System.Windows.Forms.ComboBox();
            this.txtQuangDuong = new System.Windows.Forms.TextBox();
            this.cboSinhVien = new System.Windows.Forms.ComboBox();
            this.cboNoiThucTap = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnXemIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvKetQuaThucTap = new System.Windows.Forms.DataGridView();
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.grpThongTinTT.SuspendLayout();
            this.grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaThucTap)).BeginInit();
            this.groupbox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTinTT
            // 
            this.grpThongTinTT.BackColor = System.Drawing.SystemColors.Control;
            this.grpThongTinTT.Controls.Add(this.cboDeTai);
            this.grpThongTinTT.Controls.Add(this.txtQuangDuong);
            this.grpThongTinTT.Controls.Add(this.cboSinhVien);
            this.grpThongTinTT.Controls.Add(this.cboNoiThucTap);
            this.grpThongTinTT.Controls.Add(this.label5);
            this.grpThongTinTT.Controls.Add(this.txtKetQua);
            this.grpThongTinTT.Controls.Add(this.label4);
            this.grpThongTinTT.Controls.Add(this.label3);
            this.grpThongTinTT.Controls.Add(this.label2);
            this.grpThongTinTT.Controls.Add(this.label1);
            this.grpThongTinTT.Location = new System.Drawing.Point(12, 12);
            this.grpThongTinTT.Name = "grpThongTinTT";
            this.grpThongTinTT.Size = new System.Drawing.Size(776, 111);
            this.grpThongTinTT.TabIndex = 26;
            this.grpThongTinTT.TabStop = false;
            this.grpThongTinTT.Text = "Thông tin thực tập";
            // 
            // cboDeTai
            // 
            this.cboDeTai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeTai.Location = new System.Drawing.Point(475, 21);
            this.cboDeTai.Name = "cboDeTai";
            this.cboDeTai.Size = new System.Drawing.Size(285, 24);
            this.cboDeTai.TabIndex = 33;
            // 
            // txtQuangDuong
            // 
            this.txtQuangDuong.Location = new System.Drawing.Point(475, 49);
            this.txtQuangDuong.Name = "txtQuangDuong";
            this.txtQuangDuong.Size = new System.Drawing.Size(285, 22);
            this.txtQuangDuong.TabIndex = 32;
            this.txtQuangDuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuangDuong_KeyPress);
            // 
            // cboSinhVien
            // 
            this.cboSinhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSinhVien.Location = new System.Drawing.Point(138, 21);
            this.cboSinhVien.Name = "cboSinhVien";
            this.cboSinhVien.Size = new System.Drawing.Size(220, 24);
            this.cboSinhVien.TabIndex = 31;
            // 
            // cboNoiThucTap
            // 
            this.cboNoiThucTap.Location = new System.Drawing.Point(139, 49);
            this.cboNoiThucTap.Name = "cboNoiThucTap";
            this.cboNoiThucTap.Size = new System.Drawing.Size(220, 24);
            this.cboNoiThucTap.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Quảng đường";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(139, 77);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(220, 22);
            this.txtKetQua.TabIndex = 4;
            this.txtKetQua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKetQua_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Đề tài";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Kết quả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Nơi thực tập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Sinh viên";
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
            // dgvKetQuaThucTap
            // 
            this.dgvKetQuaThucTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQuaThucTap.Location = new System.Drawing.Point(10, 21);
            this.dgvKetQuaThucTap.Name = "dgvKetQuaThucTap";
            this.dgvKetQuaThucTap.RowHeadersWidth = 51;
            this.dgvKetQuaThucTap.RowTemplate.Height = 24;
            this.dgvKetQuaThucTap.Size = new System.Drawing.Size(750, 260);
            this.dgvKetQuaThucTap.TabIndex = 23;
            this.dgvKetQuaThucTap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQuaThucTap_CellClick);
            // 
            // groupbox3
            // 
            this.groupbox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupbox3.Controls.Add(this.dgvKetQuaThucTap);
            this.groupbox3.Location = new System.Drawing.Point(12, 194);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(776, 287);
            this.groupbox3.TabIndex = 28;
            this.groupbox3.TabStop = false;
            this.groupbox3.Text = "Kết quả thực tập";
            // 
            // FormQuanLyThucTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.grpThongTinTT);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.groupbox3);
            this.Name = "FormQuanLyThucTap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kết quả thực tập";
            this.Load += new System.EventHandler(this.FormQuanLyThucTap_Load);
            this.grpThongTinTT.ResumeLayout(false);
            this.grpThongTinTT.PerformLayout();
            this.grpChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaThucTap)).EndInit();
            this.groupbox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTinTT;
        private System.Windows.Forms.ComboBox cboNoiThucTap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnXemIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvKetQuaThucTap;
        private System.Windows.Forms.GroupBox groupbox3;
        private System.Windows.Forms.ComboBox cboSinhVien;
        private System.Windows.Forms.ComboBox cboDeTai;
        private System.Windows.Forms.TextBox txtQuangDuong;
    }
}