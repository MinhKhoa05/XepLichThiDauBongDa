using System.Windows.Forms;
using BUS.BUSs;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmStadium : Form
    {
        public FrmStadium()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            string stadiumName = txtStadiumName.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(stadiumName))
            {
                MyMessageBox.ShowWarning("Tên sân không được để trống");
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MyMessageBox.ShowWarning("Địa chỉ không được để trống");
                return;
            }

            StadiumDTO stadium = new StadiumDTO
            {
                StadiumName = stadiumName,
                Address = address
            };

            // Gán vào Tag nếu muốn dùng ở form cha

            this.Tag = (new StadiumBUS()).Insert(stadium);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
