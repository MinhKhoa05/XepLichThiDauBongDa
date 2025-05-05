using System;
using System.Windows.Forms;
using GUI.Commands;

namespace GUI.UserControls
{
    public partial class UcGridTools : UserControl
    {
        private readonly CommandInvoker _invoker = new CommandInvoker();
        private readonly ICurdCommand _command;

        public UcGridTools(string type)
        {
            InitializeComponent();
            _command = CommandFactory.CreateCommand(type, dgv);
            Load += (s, e) => _command.Load();  // Tải dữ liệu khi control được load
            dgv.CellClick += (s, e) => UpdateButtonState(); // Cập nhật nút khi chọn dòng khác
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            btnEdit.Enabled = _command.CanUpdate;
            btnDelete.Enabled = _command.CanDelete;
            btnUndo.Enabled = _invoker.CanUndo();
        }

        private void btnExport_Click(object sender, EventArgs e) => _command.Export();

        private void btnInsert_Click(object sender, EventArgs e)
        {
            _invoker.ExecuteInsert(_command);
            UpdateButtonState();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _invoker.ExecuteUpdate(_command);
            UpdateButtonState();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _invoker.ExecuteDelete(_command);
            UpdateButtonState();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            _invoker.Undo();
            UpdateButtonState();
        }
    }
}
