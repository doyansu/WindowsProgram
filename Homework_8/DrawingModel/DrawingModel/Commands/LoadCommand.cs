using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Commands
{
    public class LoadCommand : ICommand
    {
        Model _model;
        List<Shape> _shapeList = null;

        public LoadCommand(Model model)
        {
            _model = model;
        }

        // 執行命令
        public void Execute()
        {
            if (_shapeList == null)
            {
                _shapeList = _model.LoadShapes().ToList();
            }
            else
            {
                Switch();
            }
        }

        // 取消命令
        public void CancelExecute()
        {
            Switch();
        }

        // 交換原本內容與下載內容
        private void Switch()
        {
            var temp = _model.RemoveAllShape().ToList();
            foreach (Shape shape in _shapeList)
                _model.AddShape(shape);
            _shapeList = temp;
        }
    }
}
