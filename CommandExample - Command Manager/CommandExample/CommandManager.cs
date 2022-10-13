using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandExample
{
    class CommandManager
    {
        Stack<ICommand> undo = new Stack<ICommand>();
        Stack<ICommand> redo = new Stack<ICommand>();

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            undo.Push(cmd);    // push command 進 undo stack
            redo.Clear();      // 清除redo stack
        }

        public void Undo()
        {
            if (undo.Count <= 0)
                throw new Exception("Cannot Undo exception\n");
            ICommand cmd = undo.Pop();
            redo.Push(cmd);
            cmd.UnExecute();
        }

        public void Redo()
        {
            if (redo.Count <= 0)
                throw new Exception("Cannot Redo exception\n");
            ICommand cmd = redo.Pop();
            undo.Push(cmd);
            cmd.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return undo.Count != 0;
            }
        }
    }
}
