using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.Helpers
{
    public static class CrudUIHelper
    {
        // Hiển thị form và lấy DTO từ thuộc tính Tag nếu OK
        public static TEntity ShowEntityForm<TEntity>(Form form) where TEntity : class
        {
            using (form)
            {
                return form.ShowDialog() == DialogResult.OK && form.Tag is TEntity entity ? entity : null;
            }
        }

        // Lấy ID từ dòng được chọn trong DataGridView
        public static string GetSelectedId(DataGridView dgv, string idColumnName)
        {
            if (dgv?.CurrentRow == null)
            {
                MyMessageBox.ShowWarning("Vui lòng chọn một dòng.");
                return null;
            }

            if (!dgv.Columns.Contains(idColumnName))
            {
                MyMessageBox.ShowError($"Không tìm thấy cột '{idColumnName}'.");
                return null;
            }

            return dgv.CurrentRow.Cells[idColumnName]?.Value?.ToString();
        }
    }
}
