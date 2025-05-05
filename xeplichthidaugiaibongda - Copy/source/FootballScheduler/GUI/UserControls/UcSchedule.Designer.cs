using FontAwesome.Sharp;
using System;

namespace GUI.UserControls
{
    partial class UcSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFunction = new System.Windows.Forms.Panel();
            this.btnUpdateResult = new GUI.CustomUI.Buttons.HoverButton();
            this.btnExport = new GUI.CustomUI.Buttons.HoverButton();
            this.btnEdit = new GUI.CustomUI.Buttons.HoverButton();
            this.btnInsert = new GUI.CustomUI.Buttons.HoverButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLeague = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvMatch = new GUI.CustomUI.DataGridViewHover();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeagueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoundNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stadium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFunction.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFunction
            // 
            this.pnlFunction.Controls.Add(this.btnUpdateResult);
            this.pnlFunction.Controls.Add(this.btnExport);
            this.pnlFunction.Controls.Add(this.btnEdit);
            this.pnlFunction.Controls.Add(this.btnInsert);
            this.pnlFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFunction.Location = new System.Drawing.Point(618, 0);
            this.pnlFunction.Name = "pnlFunction";
            this.pnlFunction.Size = new System.Drawing.Size(489, 80);
            this.pnlFunction.TabIndex = 4;
            // 
            // btnUpdateResult
            // 
            this.btnUpdateResult.BackColor = System.Drawing.Color.Goldenrod;
            this.btnUpdateResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateResult.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnUpdateResult.ForeColor = System.Drawing.Color.White;
            this.btnUpdateResult.HoverBackColor = System.Drawing.Color.Empty;
            this.btnUpdateResult.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.btnUpdateResult.IconColor = System.Drawing.Color.White;
            this.btnUpdateResult.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnUpdateResult.IconSize = 20;
            this.btnUpdateResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateResult.Location = new System.Drawing.Point(250, 18);
            this.btnUpdateResult.Name = "btnUpdateResult";
            this.btnUpdateResult.Size = new System.Drawing.Size(110, 44);
            this.btnUpdateResult.TabIndex = 11;
            this.btnUpdateResult.Text = "Kết quả";
            this.btnUpdateResult.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUpdateResult.UseVisualStyleBackColor = false;
            this.btnUpdateResult.Click += new System.EventHandler(this.btnUpdateResult_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverBackColor = System.Drawing.Color.Empty;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExport.IconColor = System.Drawing.Color.White;
            this.btnExport.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnExport.IconSize = 20;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(368, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 44);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Xuất";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverBackColor = System.Drawing.Color.Empty;
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.btnEdit.IconColor = System.Drawing.Color.White;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnEdit.IconSize = 20;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(134, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 44);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Lịch";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.HoverBackColor = System.Drawing.Color.Empty;
            this.btnInsert.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnInsert.IconColor = System.Drawing.Color.White;
            this.btnInsert.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnInsert.IconSize = 20;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(18, 18);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(110, 44);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Tạo lịch";
            this.btnInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbLeague);
            this.panel2.Controls.Add(this.pnlFunction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 80);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 30);
            this.label2.TabIndex = 87;
            this.label2.Text = "Giải đấu";
            // 
            // cbLeague
            // 
            this.cbLeague.BackColor = System.Drawing.Color.Transparent;
            this.cbLeague.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.cbLeague.BorderRadius = 3;
            this.cbLeague.BorderThickness = 2;
            this.cbLeague.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLeague.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLeague.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.cbLeague.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLeague.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLeague.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLeague.ForeColor = System.Drawing.Color.White;
            this.cbLeague.ItemHeight = 30;
            this.cbLeague.Location = new System.Drawing.Point(100, 18);
            this.cbLeague.Name = "cbLeague";
            this.cbLeague.Size = new System.Drawing.Size(502, 36);
            this.cbLeague.TabIndex = 86;
            // 
            // dgvMatch
            // 
            this.dgvMatch.AllowUserToAddRows = false;
            this.dgvMatch.AllowUserToDeleteRows = false;
            this.dgvMatch.AllowUserToResizeColumns = false;
            this.dgvMatch.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvMatch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvMatch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMatch.ColumnHeadersHeight = 50;
            this.dgvMatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MatchID,
            this.LeagueName,
            this.RoundNumber,
            this.MatchDate,
            this.MatchTime,
            this.HomeTeam,
            this.Result,
            this.AwayTeam,
            this.Stadium,
            this.Referee});
            this.dgvMatch.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatch.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.dgvMatch.Location = new System.Drawing.Point(0, 80);
            this.dgvMatch.MultiSelect = false;
            this.dgvMatch.Name = "dgvMatch";
            this.dgvMatch.ReadOnly = true;
            this.dgvMatch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvMatch.RowHeadersVisible = false;
            this.dgvMatch.RowHeadersWidth = 51;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMatch.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMatch.RowTemplate.Height = 40;
            this.dgvMatch.RowTemplate.ReadOnly = true;
            this.dgvMatch.Size = new System.Drawing.Size(1107, 643);
            this.dgvMatch.TabIndex = 6;
            this.dgvMatch.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMatch.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvMatch.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvMatch.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvMatch.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvMatch.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvMatch.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.dgvMatch.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvMatch.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvMatch.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMatch.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMatch.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMatch.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvMatch.ThemeStyle.ReadOnly = true;
            this.dgvMatch.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMatch.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMatch.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMatch.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvMatch.ThemeStyle.RowsStyle.Height = 40;
            this.dgvMatch.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMatch.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvMatch.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMatch_DataBindingComplete);
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 66;
            // 
            // MatchID
            // 
            this.MatchID.DataPropertyName = "MatchID";
            this.MatchID.HeaderText = "";
            this.MatchID.MinimumWidth = 6;
            this.MatchID.Name = "MatchID";
            this.MatchID.ReadOnly = true;
            this.MatchID.Visible = false;
            // 
            // LeagueName
            // 
            this.LeagueName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LeagueName.DataPropertyName = "LeagueName";
            this.LeagueName.HeaderText = "Giải đấu";
            this.LeagueName.MinimumWidth = 6;
            this.LeagueName.Name = "LeagueName";
            this.LeagueName.ReadOnly = true;
            // 
            // RoundNumber
            // 
            this.RoundNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RoundNumber.DataPropertyName = "RoundNumber";
            this.RoundNumber.HeaderText = "Vòng";
            this.RoundNumber.MinimumWidth = 6;
            this.RoundNumber.Name = "RoundNumber";
            this.RoundNumber.ReadOnly = true;
            this.RoundNumber.Width = 79;
            // 
            // MatchDate
            // 
            this.MatchDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MatchDate.DataPropertyName = "KickoffDateTime";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.MatchDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.MatchDate.HeaderText = "Ngày";
            this.MatchDate.MinimumWidth = 6;
            this.MatchDate.Name = "MatchDate";
            this.MatchDate.ReadOnly = true;
            this.MatchDate.Width = 79;
            // 
            // MatchTime
            // 
            this.MatchTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MatchTime.DataPropertyName = "KickoffDateTime";
            dataGridViewCellStyle4.Format = "t";
            dataGridViewCellStyle4.NullValue = null;
            this.MatchTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.MatchTime.HeaderText = "Giờ";
            this.MatchTime.MinimumWidth = 6;
            this.MatchTime.Name = "MatchTime";
            this.MatchTime.ReadOnly = true;
            this.MatchTime.Width = 65;
            // 
            // HomeTeam
            // 
            this.HomeTeam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HomeTeam.DataPropertyName = "HomeTeam";
            this.HomeTeam.HeaderText = "Đội nhà";
            this.HomeTeam.MinimumWidth = 6;
            this.HomeTeam.Name = "HomeTeam";
            this.HomeTeam.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Result.DataPropertyName = "Result";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Result.DefaultCellStyle = dataGridViewCellStyle5;
            this.Result.HeaderText = "-";
            this.Result.MinimumWidth = 6;
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Width = 46;
            // 
            // AwayTeam
            // 
            this.AwayTeam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AwayTeam.DataPropertyName = "AwayTeam";
            this.AwayTeam.HeaderText = "Đội khách";
            this.AwayTeam.MinimumWidth = 6;
            this.AwayTeam.Name = "AwayTeam";
            this.AwayTeam.ReadOnly = true;
            // 
            // Stadium
            // 
            this.Stadium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stadium.DataPropertyName = "StadiumName";
            this.Stadium.HeaderText = "Sân";
            this.Stadium.MinimumWidth = 6;
            this.Stadium.Name = "Stadium";
            this.Stadium.ReadOnly = true;
            // 
            // Referee
            // 
            this.Referee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Referee.DataPropertyName = "RefereeName";
            this.Referee.HeaderText = "Trọng tài";
            this.Referee.MinimumWidth = 6;
            this.Referee.Name = "Referee";
            this.Referee.ReadOnly = true;
            // 
            // UcSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.dgvMatch);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Name = "UcSchedule";
            this.Size = new System.Drawing.Size(1107, 723);
            this.Load += new System.EventHandler(this.UcSchedule_Load);
            this.pnlFunction.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFunction;
        private System.Windows.Forms.Panel panel2;
        private CustomUI.DataGridViewHover dgvMatch;
        private CustomUI.Buttons.HoverButton btnExport;
        private CustomUI.Buttons.HoverButton btnEdit;
        private CustomUI.Buttons.HoverButton btnInsert;
        private Guna.UI2.WinForms.Guna2ComboBox cbLeague;
        private System.Windows.Forms.Label label2;
        private CustomUI.Buttons.HoverButton btnUpdateResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeagueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoundNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stadium;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referee;
    }
}