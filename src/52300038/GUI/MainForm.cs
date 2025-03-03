using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuanLySV quanLySV = new FormQuanLySV();
            quanLySV.FormClosed += (s, args) => this.Show();
            quanLySV.ShowDialog();
        }

        private void btnDeTai_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuanLyDeTai quanLyDT = new FormQuanLyDeTai();
            quanLyDT.FormClosed += (s, args) => this.Show();
            quanLyDT.ShowDialog();
        }

        private void btnThucTap_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuanLyThucTap quanLyTT = new FormQuanLyThucTap();
            quanLyTT.FormClosed += (s, args) => this.Show();
            quanLyTT.ShowDialog();
        }
    }
}
