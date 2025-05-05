using System;
using System.Windows.Forms;

namespace GUI.Commands
{
    /// <summary>
    /// Lớp cơ sở cho các thao tác thêm, sửa, xóa (CRUD), có thể hoàn tác thao tác cuối cùng, Load và Export.
    /// </summary>
    public abstract class CurdCommandBase<TEntity> : ICurdCommand where TEntity : class
    {
        #region Biến và thuộc tính

        protected readonly DataGridView _dataGridView;
        private CommandState<TEntity> _lastAction;

        // Xác định điều kiện cho phép thực hiện các thao tác
        public virtual bool CanUpdate => _dataGridView?.CurrentRow != null;
        public virtual bool CanDelete => _dataGridView?.CurrentRow != null;

        #endregion

        #region Khởi tạo

        public CurdCommandBase(DataGridView dgv)
        {
            _dataGridView = dgv;
        }

        #endregion

        #region Thao tác CRUD

        /// <summary>
        /// Thêm một đối tượng mới.
        /// </summary>
        public void Insert()
        {
            var entity = ShowFormForEntity();
            if (entity != null)
            {
                ExecuteInsert(entity);
                _lastAction = new CommandState<TEntity>(ActionType.Insert, entity);
                Load();
            }
        }

        /// <summary>
        /// Cập nhật đối tượng đang chọn.
        /// </summary>
        public void Update()
        {
            if (!CanUpdate) return;

            var original = GetSelectedEntity();
            if (original != null)
            {
                var updated = ShowFormForEntity(original);
                if (updated != null)
                {
                    _lastAction = new CommandState<TEntity>(ActionType.Update, original);
                    ExecuteUpdate(updated);
                    Load();
                }
            }
        }

        /// <summary>
        /// Xóa (mềm) đối tượng đang chọn.
        /// </summary>
        public void Delete()
        {
            if (!CanDelete) return;

            var entity = GetSelectedEntity();
            if (entity != null)
            {
                _lastAction = new CommandState<TEntity>(ActionType.Delete, entity);
                ExecuteSoftDelete(entity); // Sử dụng soft delete thay vì xóa vĩnh viễn
                Load();
            }
        }

        /// <summary>
        /// Hoàn tác thao tác thêm, sửa hoặc xóa cuối cùng.
        /// </summary>
        public void Undo()
        {
            if (_lastAction == null)
            {
                MessageBox.Show("Không có thao tác nào để hoàn tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (_lastAction.Action)
            {
                case ActionType.Insert:
                    ExecuteSoftDelete(_lastAction.Entity); // Nếu vừa thêm => ẩn đi
                    break;
                case ActionType.Update:
                    ExecuteUpdate(_lastAction.Entity);     // Nếu vừa sửa => phục hồi bản gốc
                    break;
                case ActionType.Delete:
                    ExecuteRestore(_lastAction.Entity);    // Nếu vừa xóa => khôi phục lại
                    break;
            }

            _lastAction = null;
            Load();
        }

        #endregion

        #region Hàm hỗ trợ

        /// <summary>
        /// Hiển thị form thêm/sửa và trả về kết quả.
        /// </summary>
        private TEntity ShowFormForEntity(TEntity entity = null)
        {
            using (var form = CreateForm(entity))
            {
                if (form.ShowDialog() == DialogResult.OK && form.Tag is TEntity resultEntity)
                    return resultEntity;
            }
            return null;
        }

        /// <summary>
        /// Lấy đối tượng đang được chọn trong DataGridView.
        /// </summary>
        private TEntity GetSelectedEntity()
        {
            var row = _dataGridView?.CurrentRow;
            if (row == null)
                throw new InvalidOperationException("Không có dòng nào được chọn.");

            var id = row.Cells[0]?.Value?.ToString();
            return id != null ? GetEntityById(id) : null;
        }

        #endregion

        #region Các phương thức cần override

        protected abstract TEntity GetEntityById(string id);
        protected abstract void ExecuteInsert(TEntity entity);
        protected abstract void ExecuteUpdate(TEntity entity);
        protected abstract void ExecuteDelete(TEntity entity);
        protected abstract void ExecuteSoftDelete(TEntity entity);
        protected abstract void ExecuteRestore(TEntity entity);

        /// <summary>
        /// Tạo form nhập liệu cho thêm/sửa.
        /// </summary>
        protected abstract Form CreateForm(TEntity entity = null);

        public abstract void Load();
        public abstract void Export();
        

        #endregion

        #region Undo - lưu lại thao tác gần nhất

        private enum ActionType
        {
            Insert,
            Update,
            Delete
        }

        /// <summary>
        /// Thông tin thao tác gần nhất để hoàn tác.
        /// </summary>
        private class CommandState<T>
        {
            public ActionType Action { get; }
            public T Entity { get; }

            public CommandState(ActionType action, T entity)
            {
                Action = action;
                Entity = entity;
            }
        }

        #endregion
    }
}
