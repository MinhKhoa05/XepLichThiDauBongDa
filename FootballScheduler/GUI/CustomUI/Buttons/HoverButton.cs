using System;
using System.Drawing;
using FontAwesome.Sharp;
using System.Windows.Forms;

namespace GUI.CustomUI.Buttons
{
    /// <summary>
    /// Lớp HoverButton kế thừa từ IconButton, thêm hiệu ứng thay đổi màu nền khi hover và focus (tab tới).
    /// </summary>
    public class HoverButton : IconButton
    {
        #region Fields

        private Color _hoverBackColor = Color.Empty; // Màu nền khi hover, mặc định là None (Color.Empty)
        private Color _originalBackColor; // Lưu trữ màu nền gốc
        private readonly float _darkeningFactor = 0.3f; // Mức độ làm đậm màu khi không có HoverBackColor

        #endregion

        #region Properties

        /// <summary>
        /// Màu nền khi hover
        /// </summary>
        public Color HoverBackColor
        {
            get => _hoverBackColor;
            set => _hoverBackColor = value;
        }

        #endregion

        #region Constructor

        public HoverButton()
        {
            Cursor = Cursors.Hand; // Thiết lập con trỏ khi di chuột vào button
        }

        #endregion

        #region Helper Methods

        /// Lấy màu đậm hơn từ màu gốc dựa trên mức độ làm đậm
        private Color GetDarkerColor(Color color)
        {
            int r = (int)(color.R * (1 - _darkeningFactor));
            int g = (int)(color.G * (1 - _darkeningFactor));
            int b = (int)(color.B * (1 - _darkeningFactor));
            return Color.FromArgb(r, g, b);
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Thay đổi màu nền khi chuột di vào button hoặc khi button nhận được focus (MouseEnter, GotFocus)
        /// </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _originalBackColor = this.BackColor; // Lưu màu nền gốc

            // Nếu có HoverBackColor, dùng màu đó. Nếu không, làm đậm màu gốc
            this.BackColor = _hoverBackColor != Color.Empty
                ? _hoverBackColor
                : GetDarkerColor(_originalBackColor);
        }

        /// <summary>
        /// Khôi phục lại màu nền ban đầu khi chuột di ra khỏi button hoặc khi mất focus (MouseLeave, LostFocus)
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = _originalBackColor; // Khôi phục màu nền gốc khi di chuột ra hoặc mất focus
        }

        #endregion
    }
}
