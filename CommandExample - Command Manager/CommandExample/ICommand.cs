using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandExample
{
    interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}
