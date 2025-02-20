using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XepLichBongDa
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuanLyGiaiDau_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormQuanLyGiaiDau formQuanLyGiaiDau = new FormQuanLyGiaiDau();
            formQuanLyGiaiDau.FormClosed += (s, args) => this.Show();
            formQuanLyGiaiDau.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
