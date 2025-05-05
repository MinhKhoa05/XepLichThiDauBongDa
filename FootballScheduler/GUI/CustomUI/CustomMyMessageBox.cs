using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace GUI.CustomUI
{
    /// <summary>
    /// Hộp thoại thông báo (MessageBox) tùy chỉnh với giao diện đẹp và icon.
    /// </summary>
    public partial class CustomMyMessageBox : Form
    {
        private Color _primaryColor = Color.CornflowerBlue;

        private CustomMyMessageBox(string message, string caption, MessageBoxIcon icon)
        {
            InitializeComponent();
            SetupUI(message, caption, icon);
        }

        /// <summary>
        /// Hiển thị CustomMyMessageBox với nội dung, tiêu đề và biểu tượng.
        /// </summary>
        public static void Show(string message, string caption, MessageBoxIcon icon)
        {
            using (var messageBox = new CustomMyMessageBox(message, caption, icon))
            {
                messageBox.ShowDialog();
            }
        }

        /// <summary>
        /// Khởi tạo giao diện và dữ liệu.
        /// </summary>
        private void SetupUI(string message, string caption, MessageBoxIcon icon)
        {
            lblMessage.Text = message;
            lblCaption.Text = caption;

            ApplyIcon(icon);
            AdjustLayout();

            BackColor = _primaryColor;
        }

        /// <summary>
        /// Tính toán và sắp xếp lại kích thước, vị trí các thành phần.
        /// </summary>
        private void AdjustLayout()
        {
            lblMessage.AutoSize = true;
            picBoxIcon.SizeMode = PictureBoxSizeMode.AutoSize;

            int width = Math.Max(lblMessage.Width + picBoxIcon.Width + 40, 250);
            int height = pnlCaption.Height + lblMessage.Height + pnlButtons.Height + 50;

            ClientSize = new Size(width, height);

            CenterControl(btnOK, pnlButtons);             // Căn giữa nút OK
            CenterControl(picBoxIcon, pnlBody, false);     // Căn giữa icon theo chiều dọc
            CenterControl(lblMessage, pnlBody, false, -3); // Căn giữa nội dung theo chiều dọc (dịch nhẹ lên)
        }

        /// <summary>
        /// Áp dụng icon và màu sắc phù hợp với loại thông báo.
        /// </summary>
        private void ApplyIcon(MessageBoxIcon icon)
        {
            var icons = new Dictionary<MessageBoxIcon, (IconChar Icon, Color Color)>
            {
                [MessageBoxIcon.Error] = (IconChar.TimesCircle, Color.FromArgb(224, 79, 95)),
                [MessageBoxIcon.Information] = (IconChar.InfoCircle, Color.FromArgb(38, 191, 166)),
                [MessageBoxIcon.Exclamation] = (IconChar.ExclamationTriangle, Color.FromArgb(255, 140, 0)),
                [MessageBoxIcon.None] = (IconChar.QuestionCircle, Color.CornflowerBlue)
            };

            var setting = icons.ContainsKey(icon) ? icons[icon] : icons[MessageBoxIcon.None];

            picBoxIcon.IconChar = setting.Icon;
            _primaryColor = setting.Color;
            btnOK.BackColor = setting.Color;
        }

        /// <summary>
        /// Căn giữa control trong parent container.
        /// </summary>
        private void CenterControl(Control control, Control parent, bool centerHorizontally = true, int yOffset = 0)
        {
            int x = centerHorizontally ? (parent.Width - control.Width) / 2 : control.Left;
            int y = (parent.Height - control.Height) / 2 + yOffset;

            control.Location = new Point(x, y);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
