namespace GUI
{
    partial class MainForm
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
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.btnDeTai = new System.Windows.Forms.Button();
            this.btnThucTap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhVien.Location = new System.Drawing.Point(23, 31);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Size = new System.Drawing.Size(188, 42);
            this.btnSinhVien.TabIndex = 0;
            this.btnSinhVien.Text = "Quản lý Sinh viên";
            this.btnSinhVien.UseVisualStyleBackColor = true;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            // 
            // btnDeTai
            // 
            this.btnDeTai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeTai.Location = new System.Drawing.Point(231, 31);
            this.btnDeTai.Name = "btnDeTai";
            this.btnDeTai.Size = new System.Drawing.Size(188, 42);
            this.btnDeTai.TabIndex = 1;
            this.btnDeTai.Text = "Quản lý Đề tài";
            this.btnDeTai.UseVisualStyleBackColor = true;
            this.btnDeTai.Click += new System.EventHandler(this.btnDeTai_Click);
            // 
            // btnThucTap
            // 
            this.btnThucTap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucTap.Location = new System.Drawing.Point(438, 31);
            this.btnThucTap.Name = "btnThucTap";
            this.btnThucTap.Size = new System.Drawing.Size(188, 42);
            this.btnThucTap.TabIndex = 2;
            this.btnThucTap.Text = "Quản lý Thực tập";
            this.btnThucTap.UseVisualStyleBackColor = true;
            this.btnThucTap.Click += new System.EventHandler(this.btnThucTap_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 109);
            this.Controls.Add(this.btnThucTap);
            this.Controls.Add(this.btnDeTai);
            this.Controls.Add(this.btnSinhVien);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnDeTai;
        private System.Windows.Forms.Button btnThucTap;
    }
}