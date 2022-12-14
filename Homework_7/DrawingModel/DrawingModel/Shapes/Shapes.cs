using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shapes
    {
        List<Shape> _shapes = new List<Shape>();
        IShapeFactory _shapeFactory;

        public Shapes(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        // Add
        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        // RemoveAt
        public void RemoveBy(int index)
        {
            if (index >= 0)
                _shapes.RemoveAt(index);
            else if (this.Count + index >= 0)
                _shapes.RemoveAt(this.Count + index);
            else
                throw new ArgumentOutOfRangeException();
        }

        // Contains
        public bool Contains(Shape shape)
        {
            return _shapes.Contains(shape);
        }

        //Clear
        public Shape[] Clear()
        {
            Shape[] shapes = _shapes.ToArray();
            _shapes.Clear();
            return shapes;
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
        }

        // 檢查是否包含在圖形內，回傳最上面的一個
        public Shape CheckPointContains(double pointX, double pointY)
        {
            Shape shape = null;
            for (int i = this.Count - 1; i >= 0; i--)
                if (_shapes[i].IsContains(pointX, pointY))
                {
                    shape = _shapes[i];
                    break;
                }
            return shape;
        }

        // 創建圖形
        public Shape CreateShape(ShapeType shapeType)
        {
            return _shapeFactory.CreateShape(shapeType);
        }

        // Get Shape
        public Shape GetBy(int index)
        {
            Shape shape = (index >= 0 && index < this.Count) ? _shapes[index] : null;
            return shape;
        }

        public int Count
        {
            get
            {
                return this._shapes.Count;
            }
        }
    }
}
