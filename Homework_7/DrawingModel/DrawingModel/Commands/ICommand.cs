using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingModel
{
    interface ICommand
    {
        // 執行命令
        void Execute();
        // 取消命令
        void UnExecute();
    }
}
