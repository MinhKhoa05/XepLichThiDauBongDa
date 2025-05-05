namespace GUI.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarMenu = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlInfoAndLogout = new System.Windows.Forms.Panel();
            this.btnProfile = new GUI.CustomUI.Buttons.HoverButton();
            this.btnLogout = new GUI.CustomUI.Buttons.HoverButton();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.iconCurrent = new FontAwesome.Sharp.IconPictureBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.pnlTopBar.SuspendLayout();
            this.pnlInfoAndLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.pnlSidebar.Controls.Add(this.pnlSidebarMenu);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(225, 803);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlSidebarMenu
            // 
            this.pnlSidebarMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebarMenu.Location = new System.Drawing.Point(0, 150);
            this.pnlSidebarMenu.Name = "pnlSidebarMenu";
            this.pnlSidebarMenu.Size = new System.Drawing.Size(225, 653);
            this.pnlSidebarMenu.TabIndex = 2;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.picBoxLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(225, 150);
            this.pnlLogo.TabIndex = 1;
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxLogo.Image = global::GUI.Properties.Resources.logo;
            this.picBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(225, 150);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogo.TabIndex = 1;
            this.picBoxLogo.TabStop = false;
            this.picBoxLogo.Click += new System.EventHandler(this.picBoxLogo_Click);
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.pnlTopBar.Controls.Add(this.pnlInfoAndLogout);
            this.pnlTopBar.Controls.Add(this.labelCurrent);
            this.pnlTopBar.Controls.Add(this.iconCurrent);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(225, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1107, 80);
            this.pnlTopBar.TabIndex = 2;
            // 
            // pnlInfoAndLogout
            // 
            this.pnlInfoAndLogout.Controls.Add(this.btnProfile);
            this.pnlInfoAndLogout.Controls.Add(this.btnLogout);
            this.pnlInfoAndLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInfoAndLogout.Location = new System.Drawing.Point(888, 0);
            this.pnlInfoAndLogout.Name = "pnlInfoAndLogout";
            this.pnlInfoAndLogout.Size = new System.Drawing.Size(219, 80);
            this.pnlInfoAndLogout.TabIndex = 0;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.HoverBackColor = System.Drawing.Color.Cyan;
            this.btnProfile.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btnProfile.IconColor = System.Drawing.Color.White;
            this.btnProfile.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnProfile.IconSize = 30;
            this.btnProfile.Location = new System.Drawing.Point(4, 15);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(50, 50);
            this.btnProfile.TabIndex = 8;
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverBackColor = System.Drawing.Color.Red;
            this.btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnLogout.IconColor = System.Drawing.Color.White;
            this.btnLogout.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnLogout.IconSize = 20;
            this.btnLogout.Location = new System.Drawing.Point(70, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 50);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrent.ForeColor = System.Drawing.Color.White;
            this.labelCurrent.Location = new System.Drawing.Point(72, 21);
            this.labelCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(142, 37);
            this.labelCurrent.TabIndex = 5;
            this.labelCurrent.Text = "Trang chủ";
            // 
            // iconCurrent
            // 
            this.iconCurrent.BackColor = System.Drawing.Color.Transparent;
            this.iconCurrent.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.iconCurrent.IconColor = System.Drawing.Color.White;
            this.iconCurrent.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrent.IconSize = 40;
            this.iconCurrent.Location = new System.Drawing.Point(23, 21);
            this.iconCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.iconCurrent.Name = "iconCurrent";
            this.iconCurrent.Size = new System.Drawing.Size(40, 40);
            this.iconCurrent.TabIndex = 4;
            this.iconCurrent.TabStop = false;
            // 
            // pnlControl
            // 
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControl.Location = new System.Drawing.Point(225, 80);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(1107, 723);
            this.pnlControl.TabIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1332, 803);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatchMaster - Ứng dụng xếp lịch thi đấu bóng đá";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlInfoAndLogout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label labelCurrent;
        private FontAwesome.Sharp.IconPictureBox iconCurrent;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlSidebarMenu;
        private System.Windows.Forms.Panel pnlInfoAndLogout;
        private CustomUI.Buttons.HoverButton btnProfile;
        private CustomUI.Buttons.HoverButton btnLogout;
    }
}