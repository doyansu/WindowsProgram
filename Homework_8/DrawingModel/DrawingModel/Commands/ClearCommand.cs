using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Commands
{
    public class ClearCommand : ICommand
    {
        Shapes _shapes;
        List<Shape> _shapeList;

        public ClearCommand(Shapes shapes)
        {
            _shapes = shapes;
            _shapeList = new List<Shape>();
        }

        // 執行命令
        public void Execute()
        {
            _shapeList = _shapes.Clear().ToList();
        }

        // 取消命令
        public void CancelExecute()
        {
            foreach (Shape shape in _shapeList)
                _shapes.Add(shape);
            _shapeList.Clear();
        }
    }
}
