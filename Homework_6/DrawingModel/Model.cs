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

        private bool _isPressed = false;
        private Shapes _shapes = new Shapes();
        private Shape _hint = null;
        private ShapeFactory.ShapeType _drawingShapeType = ShapeFactory.ShapeType.Null;

        // 開始繪製
        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                if ((_hint = _shapes.CreateShape(DrawingShapeType)) != null)
                {
                    _hint.X1 = pointX;
                    _hint.Y1 = pointY;
                    _isPressed = true;
                }
            }
        }

        // 繪製移動
        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed && _hint != null)
            {
                _hint.X2 = pointX;
                _hint.Y2 = pointY;
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
                    _shapes.Add(_hint);
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

        public ShapeFactory.ShapeType DrawingShapeType 
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
