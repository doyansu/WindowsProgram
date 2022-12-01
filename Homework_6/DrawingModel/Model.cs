using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        Shape _hint = null;
        ShapeFactory.ShapeType _drawingShapeType = ShapeFactory.ShapeType.Null;

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
                ShapeFactory shapeFactory = new ShapeFactory();
                _hint = shapeFactory.CreateShape(DrawingShapeType, _firstPointX, _firstPointY, pointX, pointY);
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
                    _shapes.Add(_hint);
                _hint = null;
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
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
            if (_isPressed && _hint != null) 
                _hint.Draw(graphics);
        }

        internal ShapeFactory.ShapeType DrawingShapeType 
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
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
