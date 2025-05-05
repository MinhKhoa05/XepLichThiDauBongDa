using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace GUI.CustomUI.Buttons
{
    /// <summary>
    /// Lớp HighlightButton kế thừa từ IconButton, bổ sung hiệu ứng và các tính năng tùy chỉnh.
    /// </summary>
    public class HighlightButton : IconButton
    {
        #region Fields

        private bool _active;
        private Color _activeColor = Color.DodgerBlue;
        private Color _originalColor;
        private int _leftBorderWidth = 5;

        #endregion

        #region Properties

        /// <summary>
        /// Trạng thái active của button
        /// </summary>
        public bool Active
        {
            get => _active;
            set
            {
                if (_active != value)
                {
                    _active = value;
                    UpdateState(); // Cập nhật lại style khi trạng thái thay đổi
                    Invalidate();  // Yêu cầu vẽ lại control
                }
            }
        }

        /// <summary>
        /// Màu sắc của button khi active
        /// </summary>
        public Color ActiveColor
        {
            get => _activeColor;
            set
            {
                if (_activeColor != value)
                {
                    _activeColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Độ rộng viền trái khi button active
        /// </summary>
        public int LeftBorderWidth
        {
            get => _leftBorderWidth;
            set
            {
                if (_leftBorderWidth != value)
                {
                    _leftBorderWidth = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Màu sắc chữ khi button không active
        /// </summary>
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                if (!_active)
                    _originalColor = value;
            }
        }

        #endregion

        #region Constructor

        public HighlightButton()
        {
            Cursor = Cursors.Hand; // Thiết lập con trỏ khi di chuột vào button
        }

        #endregion

        #region Style Handling

        /// <summary>
        /// Cập nhật lại style của button khi trạng thái active thay đổi
        /// </summary>
        protected virtual void UpdateState()
        {
            var color = _active ? _activeColor : _originalColor;
            ForeColor = IconColor = color;

            TextImageRelation = _active
                ? TextImageRelation.TextBeforeImage
                : TextImageRelation.ImageBeforeText;

            ImageAlign = _active
                ? ContentAlignment.MiddleRight
                : ContentAlignment.MiddleLeft;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Đổi trạng thái active khi click vào button
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Active = !Active; // Đảo trạng thái active khi click
        }

        /// <summary>
        /// Vẽ viền bên trái của button khi active
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_active)
            {
                using (var brush = new SolidBrush(_activeColor))
                {
                    e.Graphics.FillRectangle(
                        brush,
                        new Rectangle(0, 0, _leftBorderWidth, Height) // Vẽ viền trái
                    );
                }
            }
        }

        #endregion
    }
}
