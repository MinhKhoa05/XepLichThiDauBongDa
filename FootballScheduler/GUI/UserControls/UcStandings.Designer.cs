using FontAwesome.Sharp;
using System;

namespace GUI.UserControls
{
    partial class UcStandings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFunction = new System.Windows.Forms.Panel();
            this.btnExport = new GUI.CustomUI.Buttons.HoverButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLeague = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvStandings = new GUI.CustomUI.DataGridViewHover();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchesPlayed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Draws = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Losses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalsScored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalsConceded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFunction.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandings)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFunction
            // 
            this.pnlFunction.Controls.Add(this.btnExport);
            this.pnlFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFunction.Location = new System.Drawing.Point(971, 0);
            this.pnlFunction.Name = "pnlFunction";
            this.pnlFunction.Size = new System.Drawing.Size(136, 80);
            this.pnlFunction.TabIndex = 4;
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
            this.btnExport.Location = new System.Drawing.Point(12, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 44);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Xuất";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbLeague);
            this.panel2.Controls.Add(this.pnlFunction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 80);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 30);
            this.label1.TabIndex = 89;
            this.label1.Text = "Giải đấu:";
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
            this.cbLeague.Location = new System.Drawing.Point(112, 18);
            this.cbLeague.Name = "cbLeague";
            this.cbLeague.Size = new System.Drawing.Size(502, 36);
            this.cbLeague.TabIndex = 88;
            this.cbLeague.SelectedIndexChanged += new System.EventHandler(this.cbLeague_SelectedIndexChanged);
            // 
            // dgvStandings
            // 
            this.dgvStandings.AllowUserToAddRows = false;
            this.dgvStandings.AllowUserToDeleteRows = false;
            this.dgvStandings.AllowUserToResizeColumns = false;
            this.dgvStandings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvStandings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStandings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvStandings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(72)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStandings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStandings.ColumnHeadersHeight = 50;
            this.dgvStandings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rank,
            this.TeamName,
            this.MatchesPlayed,
            this.Wins,
            this.Draws,
            this.Losses,
            this.GoalsScored,
            this.GoalsConceded,
            this.GoalDiff,
            this.Points});
            this.dgvStandings.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStandings.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvStandings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStandings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.dgvStandings.Location = new System.Drawing.Point(0, 80);
            this.dgvStandings.MultiSelect = false;
            this.dgvStandings.Name = "dgvStandings";
            this.dgvStandings.ReadOnly = true;
            this.dgvStandings.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvStandings.RowHeadersVisible = false;
            this.dgvStandings.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvStandings.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvStandings.RowTemplate.Height = 40;
            this.dgvStandings.RowTemplate.ReadOnly = true;
            this.dgvStandings.Size = new System.Drawing.Size(1107, 643);
            this.dgvStandings.TabIndex = 6;
            this.dgvStandings.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStandings.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvStandings.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvStandings.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvStandings.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvStandings.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvStandings.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.dgvStandings.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvStandings.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvStandings.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStandings.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStandings.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStandings.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvStandings.ThemeStyle.ReadOnly = true;
            this.dgvStandings.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStandings.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStandings.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStandings.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dgvStandings.ThemeStyle.RowsStyle.Height = 40;
            this.dgvStandings.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStandings.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStandings.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStandings_DataBindingComplete);
            // 
            // Rank
            // 
            this.Rank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "#";
            this.Rank.MinimumWidth = 6;
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            this.Rank.Width = 49;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "TeamName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TeamName.DefaultCellStyle = dataGridViewCellStyle3;
            this.TeamName.HeaderText = "Đội bóng";
            this.TeamName.MinimumWidth = 6;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // MatchesPlayed
            // 
            this.MatchesPlayed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MatchesPlayed.DataPropertyName = "MatchesPlayed";
            this.MatchesPlayed.HeaderText = "Số trận";
            this.MatchesPlayed.MinimumWidth = 6;
            this.MatchesPlayed.Name = "MatchesPlayed";
            this.MatchesPlayed.ReadOnly = true;
            this.MatchesPlayed.Width = 94;
            // 
            // Wins
            // 
            this.Wins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Wins.DataPropertyName = "Wins";
            dataGridViewCellStyle4.NullValue = null;
            this.Wins.DefaultCellStyle = dataGridViewCellStyle4;
            this.Wins.HeaderText = "Thắng";
            this.Wins.MinimumWidth = 6;
            this.Wins.Name = "Wins";
            this.Wins.ReadOnly = true;
            this.Wins.Width = 87;
            // 
            // Draws
            // 
            this.Draws.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Draws.DataPropertyName = "Draws";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = null;
            this.Draws.DefaultCellStyle = dataGridViewCellStyle5;
            this.Draws.HeaderText = "Hòa";
            this.Draws.MinimumWidth = 6;
            this.Draws.Name = "Draws";
            this.Draws.ReadOnly = true;
            this.Draws.Width = 70;
            // 
            // Losses
            // 
            this.Losses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Losses.DataPropertyName = "Losses";
            this.Losses.HeaderText = "Thua";
            this.Losses.MinimumWidth = 6;
            this.Losses.Name = "Losses";
            this.Losses.ReadOnly = true;
            this.Losses.Width = 77;
            // 
            // GoalsScored
            // 
            this.GoalsScored.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GoalsScored.DataPropertyName = "GoalsScored";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GoalsScored.DefaultCellStyle = dataGridViewCellStyle6;
            this.GoalsScored.HeaderText = "Bàn thắng";
            this.GoalsScored.MinimumWidth = 6;
            this.GoalsScored.Name = "GoalsScored";
            this.GoalsScored.ReadOnly = true;
            this.GoalsScored.Width = 118;
            // 
            // GoalsConceded
            // 
            this.GoalsConceded.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GoalsConceded.DataPropertyName = "GoalsConceded";
            this.GoalsConceded.HeaderText = "Bàn thua";
            this.GoalsConceded.MinimumWidth = 6;
            this.GoalsConceded.Name = "GoalsConceded";
            this.GoalsConceded.ReadOnly = true;
            this.GoalsConceded.Width = 108;
            // 
            // GoalDiff
            // 
            this.GoalDiff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GoalDiff.DataPropertyName = "GoalDiff";
            this.GoalDiff.HeaderText = "Hiệu số";
            this.GoalDiff.MinimumWidth = 6;
            this.GoalDiff.Name = "GoalDiff";
            this.GoalDiff.ReadOnly = true;
            this.GoalDiff.Width = 96;
            // 
            // Points
            // 
            this.Points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Points.DataPropertyName = "Points";
            this.Points.HeaderText = "Điểm";
            this.Points.MinimumWidth = 6;
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.Width = 79;
            // 
            // UcStandings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.dgvStandings);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Name = "UcStandings";
            this.Size = new System.Drawing.Size(1107, 723);
            this.Load += new System.EventHandler(this.UcStandings_Load);
            this.pnlFunction.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFunction;
        private System.Windows.Forms.Panel panel2;
        private CustomUI.DataGridViewHover dgvStandings;
        private CustomUI.Buttons.HoverButton btnExport;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbLeague;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchesPlayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn Draws;
        private System.Windows.Forms.DataGridViewTextBoxColumn Losses;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalsScored;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalsConceded;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
    }
}