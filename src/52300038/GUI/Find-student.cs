using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI
{
    public partial class Find_student: Form
    {
        public Find_student()
        {
            InitializeComponent();
        }

        private void LoadProvinces()
        {
            ComboBox1.Items.AddRange(new string[] { "Sài Gòn", "Thanh Hóa", "Nghệ An", "Long An", "Quảng Ngãi", "Nam Định", "Ninh Thuận", "Nha Trang" });
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
