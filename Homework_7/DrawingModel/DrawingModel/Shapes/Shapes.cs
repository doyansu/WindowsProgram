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

        //Clear
        public void Clear()
        {
            _shapes.Clear();
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

        // 創建圖形
        public Shape CreateShape(ShapeType shapeType)
        {
            return _shapeFactory.CreateShape(shapeType);
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
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
