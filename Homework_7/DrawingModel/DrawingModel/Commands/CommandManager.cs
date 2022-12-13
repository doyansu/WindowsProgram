using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DrawingModel
{
    class CommandManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        const string PROPERTY_NAME_REDO = "IsRedoEnabled";
        const string PROPERTY_NAME_UNDO = "IsUndoEnabled";

        // 執行命令
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
            NotifyPropertyChanged();
        }

        // 回上一個命令
        public void Undo()
        {
            const string EXCEPTION_MESSAGE = "Cannot Undo exception\n";
            if (_undo.Count <= 0)
                throw new Exception(EXCEPTION_MESSAGE);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.CancelExecute();
            NotifyPropertyChanged();
        }

        // 回下一個命令
        public void Redo()
        {
            const string EXCEPTION_MESSAGE = "Cannot Redo exception\n";
            if (_redo.Count <= 0)
                throw new Exception(EXCEPTION_MESSAGE);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
            NotifyPropertyChanged();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }

        // 通知所有 databing 改變
        private void NotifyPropertyChanged()
        {
            this.NotifyPropertyChanged(PROPERTY_NAME_UNDO);
            this.NotifyPropertyChanged(PROPERTY_NAME_REDO);
        }

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
