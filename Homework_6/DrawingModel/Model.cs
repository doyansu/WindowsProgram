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

        // 開始繪製
        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _isPressed = true;
            }
        }

        // 繪製移動
        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _hint = new Line(_firstPointX, _firstPointY, x, y);
                NotifyModelChanged();
            }
        }

        // 完成圖形繪製
        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
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

        // 通知 model 改變
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
