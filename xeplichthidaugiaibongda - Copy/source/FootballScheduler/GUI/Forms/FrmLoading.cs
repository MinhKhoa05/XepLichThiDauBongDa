using System;
using System.Windows.Forms;
using BUS.Managers;

namespace GUI.Forms
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            // Cập nhật giá trị progress bar ngẫu nhiên
            progressBar.Value = Math.Min(progressBar.Value + new Random().Next(10, 20), 100);
            percent.Text = $"{progressBar.Value}%";

            if (progressBar.Value >= 100)
            {
                timerLoading.Stop();
                OpenNextForm();
            }
        }

        private void OpenNextForm()
        {
            Form nextForm = null;
            
            try
            {
                // Kiểm tra kết nối và tải cấu hình
                if (DbConfigManager.LoadAndTest())
                    nextForm = new FrmLogin();
                else
                    nextForm = new FrmConfig();
            }
            catch
            {
                // Nếu có lỗi, mở form cấu hình
                nextForm = new FrmConfig();
            }

            Hide();
            nextForm?.ShowDialog();  // Dùng toán tử null-conditional để tránh lỗi nếu nextForm null
            Close();
        }
    }
}
