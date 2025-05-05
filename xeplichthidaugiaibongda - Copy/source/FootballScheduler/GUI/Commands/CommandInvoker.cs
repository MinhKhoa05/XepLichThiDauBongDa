using System.Collections.Generic;
using GUI.Commands;

namespace GUI
{
    public class CommandInvoker
    {
        // Danh sách các lệnh đã thực thi
        private readonly Stack<ICurdCommand> _undoStack = new Stack<ICurdCommand>();

        // Thực thi thao tác Insert
        public void ExecuteInsert(ICurdCommand command)
        {
            command.Insert();
            _undoStack.Push(command);  // Lưu lại lệnh để hoàn tác sau này
        }

        // Thực thi thao tác Update
        public void ExecuteUpdate(ICurdCommand command)
        {
            command.Update();
            _undoStack.Push(command);  // Lưu lại lệnh để hoàn tác sau này
        }

        // Thực thi thao tác Delete
        public void ExecuteDelete(ICurdCommand command)
        {
            command.Delete();
            _undoStack.Push(command);  // Lưu lại lệnh để hoàn tác sau này
        }

        // Hoàn tác thao tác gần nhất
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var lastCommand = _undoStack.Pop();
                lastCommand.Undo();  // Hoàn tác thao tác cuối cùng
            }
        }

        public bool CanUndo() => _undoStack.Count > 0;
    }
}
