using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUI.CustomUI
{
    /// <summary>
    /// Lớp DataGridViewHover kế thừa từ Guna2DataGridView, thêm hiệu ứng hover.
    /// </summary>
    public class DataGridViewHover : Guna2DataGridView
    {
        #region Override Methods

        /// <summary>
        /// Xử lý sau khi dữ liệu được binding xong, dọn dẹp lựa chọn.
        /// </summary>
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            ClearSelection(); // Dọn dẹp lựa chọn
            CurrentCell = null; // Xóa lựa chọn ô hiện tại
        }

        /// <summary>
        /// Thay đổi màu nền và chữ khi chuột di vào ô.
        /// </summary>
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);

            if (IsValidRowIndex(e.RowIndex))
            {
                var row = Rows[e.RowIndex];
                SetRowHoverColor(row, true); // Đổi màu khi hover
            }
        }

        /// <summary>
        /// Khôi phục màu nền và chữ khi chuột rời khỏi ô.
        /// </summary>
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);

            if (IsValidRowIndex(e.RowIndex))
            {
                var row = Rows[e.RowIndex];
                SetRowHoverColor(row, false); // Khôi phục màu khi chuột rời
            }
        }

        #endregion

        #region Helper Methods

        /// Kiểm tra chỉ mục dòng hợp lệ.
        private bool IsValidRowIndex(int rowIndex)
        {
            return rowIndex >= 0 && rowIndex < RowCount;
        }

        /// Thiết lập màu cho dòng khi hover.
        private void SetRowHoverColor(DataGridViewRow row, bool isHover)
        {
            if (isHover)
            {
                row.DefaultCellStyle.BackColor = RowsDefaultCellStyle.SelectionBackColor;
                row.DefaultCellStyle.ForeColor = RowsDefaultCellStyle.SelectionForeColor;
            }
            else
            {
                row.DefaultCellStyle.BackColor = RowsDefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = RowsDefaultCellStyle.ForeColor;
            }
        }

        #endregion
    }
}
