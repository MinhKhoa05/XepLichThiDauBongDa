using System;
using System.Windows.Forms;
using BUS.Managers;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();

            // Đăng ký sự kiện KeyPress cho các trường nhập liệu
            txtServer.KeyPress += OnInput_KeyPress;
            txtUser.KeyPress += OnInput_KeyPress;
            txtPass.KeyPress += OnInput_KeyPress;
        }

        /// <summary>
        /// Xử lý sự kiện khi checkbox xác thực được thay đổi.
        /// </summary>
        private void chkWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            bool winAuth = chkWinAuth.Checked;
            txtUser.Enabled = txtPass.Enabled = !winAuth;

            // Xóa thông tin tài khoản nếu đang sử dụng Windows Authentication
            if (winAuth)
            {
                txtUser.Clear();
                txtPass.Clear();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút Lưu.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SetLoadingState(true, "Đang kiểm tra kết nối...");

            bool winAuth = chkWinAuth.Checked;
            string server = txtServer.Text.Trim();
            string db = txtDB.Text.Trim();
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            try
            {
                DbConfigManager.SetAndSave(winAuth, server, db, user, pass);
                // Thông báo thành công và đóng form
                MyMessageBox.ShowInformation("Kết nối thành công!\nVui lòng khởi động lại ứng dụng để áp dụng cài đặt mới.");
                Close();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MyMessageBox.ShowError(ex.Message);
                txtServer.Focus();
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút Hủy.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Thiết lập trạng thái tải (loading) cho giao diện.
        /// </summary>
        private void SetLoadingState(bool isLoading, string message = "")
        {
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
            lblStatus.Text = message;
            lblStatus.Visible = isLoading;
            Application.DoEvents();
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn phím Enter để lưu cấu hình.
        /// </summary>
        private void OnInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu người dùng nhấn Enter, thực hiện lưu cấu hình
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSave.PerformClick();
            }
        }
    }
}
