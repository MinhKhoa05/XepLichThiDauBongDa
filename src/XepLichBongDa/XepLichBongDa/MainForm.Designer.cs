namespace XepLichBongDa
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
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnQuanLyGiaiDau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.SystemColors.Control;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDangXuat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnDangXuat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDangXuat.Location = new System.Drawing.Point(232, 23);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(120, 40);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnQuanLyGiaiDau
            // 
            this.btnQuanLyGiaiDau.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuanLyGiaiDau.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnQuanLyGiaiDau.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnQuanLyGiaiDau.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQuanLyGiaiDau.Location = new System.Drawing.Point(22, 23);
            this.btnQuanLyGiaiDau.Name = "btnQuanLyGiaiDau";
            this.btnQuanLyGiaiDau.Size = new System.Drawing.Size(178, 40);
            this.btnQuanLyGiaiDau.TabIndex = 1;
            this.btnQuanLyGiaiDau.Text = "Quản lý Giải đấu";
            this.btnQuanLyGiaiDau.UseVisualStyleBackColor = false;
            this.btnQuanLyGiaiDau.Click += new System.EventHandler(this.btnQuanLyGiaiDau_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 241);
            this.Controls.Add(this.btnQuanLyGiaiDau);
            this.Controls.Add(this.btnDangXuat);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Ứng dụng xếp lịch thi đấu giải bóng đá";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnQuanLyGiaiDau;
    }
}