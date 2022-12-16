using System;
using System.Drawing;

namespace DrawingModel.Commands
{
    class DrawCommand : ICommand
    {
        Shape _shape;
        Shapes _shapes;
        public DrawCommand(Shapes shapes, Shape shape)
        {
            _shape = shape;
            _shapes = shapes;
        }

        // 執行命令
        public void Execute()
        {
            _shapes.Add(_shape);
        }

        // 取消命令
        public void CancelExecute()
        {
            _shapes.RemoveBy(-1);
        }
    }
}
