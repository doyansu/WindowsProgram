using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Commands
{
    public class ClearCommand : ICommand
    {
        Model _model;
        List<Shape> _shapeList;

        public ClearCommand(Model model)
        {
            _model = model;
            _shapeList = new List<Shape>();
        }

        // 執行命令
        public void Execute()
        {
            _shapeList = _model.RemoveAllShape().ToList();
        }

        // 取消命令
        public void CancelExecute()
        {
            foreach (Shape shape in _shapeList)
                _model.AddShape(shape);
            _shapeList.Clear();
        }
    }
}
