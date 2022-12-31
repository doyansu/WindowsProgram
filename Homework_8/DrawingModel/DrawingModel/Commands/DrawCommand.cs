using System;
using System.Drawing;

namespace DrawingModel.Commands
{
    public class DrawCommand : ICommand
    {
        Model _model;
        Shape _shape;

        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        // 執行命令
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        // 取消命令
        public void CancelExecute()
        {
            _model.RemoveShape(_shape);
        }
    }
}
