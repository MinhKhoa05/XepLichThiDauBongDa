using System.Windows.Forms;

namespace GUI.Helpers
{
    /// <summary>
    /// Helper hỗ trợ hiển thị các loại hộp thoại thông báo.
    /// </summary>
    public static class MyMessageBox
    {
        /// <summary>
        /// Hiển thị hộp thoại với nội dung, tiêu đề và biểu tượng tùy chọn.
        /// </summary>
        public static void Show(string message, string caption, MessageBoxIcon icon)
        {
            GUI.CustomUI.CustomMyMessageBox.Show(message, caption, icon);
        }

        /// <summary>
        /// Hiển thị hộp thoại thông tin.
        /// </summary>
        public static void ShowInformation(string message)
        {
            Show(message, "Thông báo", MessageBoxIcon.Information);
        }

        /// <summary>
        /// Hiển thị hộp thoại cảnh báo.
        /// </summary>
        public static void ShowWarning(string message)
        {
            Show(message, "Cảnh báo", MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Hiển thị hộp thoại lỗi.
        /// </summary>
        public static void ShowError(string message)
        {
            Show(message, "Lỗi", MessageBoxIcon.Error);
        }
    }
}
