using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private double _firstPointX = 0;
        private double _firstPointY = 0;
        private bool _isPressed = false;
        private Shapes _shapes;
        private Shape _hint = null;
        private ShapeType _drawingShapeType = ShapeType.Null;
        private CommandManager _commandManager = new CommandManager();

        public Model()
        {
            _shapes = new Shapes(new ShapeFactory());
        }

        // 開始繪製
        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                _isPressed = true;
            }
        }

        // 繪製移動
        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                if ((_hint = _shapes.CreateShape(DrawingShapeType)) != null)
                {
                    _hint.X1 = _firstPointX;
                    _hint.Y1 = _firstPointY;
                    _hint.X2 = pointX;
                    _hint.Y2 = pointY;
                }
                NotifyModelChanged();
            }
        }

        // 完成圖形繪製
        public void ReleasePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (_hint != null)
                {
                    _commandManager.Execute(new DrawCommand(this, _hint));
                    _hint = null;
                }
                NotifyModelChanged();
            }
        }

        // 清除所有圖形
        public void Clear()
        {
            _isPressed = false;
            _hint = null;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            if (_isPressed && _hint != null) 
                _hint.Draw(graphics);
        }

        // 加入繪製圖形
        public void DrawShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // 移除最後一個圖形
        public void DeleteShape()
        {
            _shapes.RemoveAt(-1);
        }

        public ShapeType DrawingShapeType 
        {
            get
            {
                return _drawingShapeType;
            }
            set
            {
                _drawingShapeType = value;
            }
        }

        // 通知 model 改變
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
