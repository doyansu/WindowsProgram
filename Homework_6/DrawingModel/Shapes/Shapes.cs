using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Shapes
    {
        List<Shape> _shapes = new List<Shape>();

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

        // 創建圖形
        public Shape CreateShape(ShapeFactory.ShapeType shapeType)
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            return shapeFactory.CreateShape(shapeType);
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
        }
    }
}
