using System.Collections.Generic;

namespace GUI.CustomUI.Buttons
{
    /// <summary>
    /// Lớp MenuStrip, kế thừa từ HighlightButton, quản lý các Sub Menu items con.
    /// </summary>
    public class HBMenuStrip : HighlightButton
    {
        #region Fields

        private readonly List<HBMenuItem> _menuItems = new List<HBMenuItem>(); // Danh sách item của MenuStrip

        #endregion

        #region Methods

        /// <summary>
        /// Thêm một item vào MenuStrip.
        /// </summary>
        public void AddItem(HBMenuItem item)
        {
            if (item == null) return;
            _menuItems.Insert(0, item); // Thêm vào đầu danh sách
            item.Click += (sender, _) => DeactivateOtherItems(sender as HBMenuItem); // Vô hiệu hóa item khác khi click
        }

        /// <summary>
        /// Thêm nhiều item vào MenuStrip.
        /// </summary>
        public void AddItems(IEnumerable<HBMenuItem> items)
        {
            if (items == null) return;
            foreach (var item in items) AddItem(item); // Thêm từng item
        }

        /// <summary>
        /// Vô hiệu hóa các item không được click và ẩn chúng khi MenuStrip không active.
        /// </summary>
        private void DeactivateOtherItems(HBMenuItem clickedItem = null)
        {
            foreach (var item in _menuItems)
            {
                item.Active = clickedItem != item && !Active; // Vô hiệu hóa nếu không phải item click hoặc MenuStrip không active
                item.Visible = Active; // Ẩn nếu MenuStrip không active
            }
        }

        /// <summary>
        /// Cập nhật trạng thái các item khi MenuStrip thay đổi trạng thái.
        /// </summary>
        protected override void UpdateState()
        {
            base.UpdateState();
            DeactivateOtherItems(); // Cập nhật trạng thái của item
        }

        #endregion
    }
}
