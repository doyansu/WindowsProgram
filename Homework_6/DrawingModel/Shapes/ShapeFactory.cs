using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ShapeFactory
    {
        public enum ShapeType
        {
            Null,
            Line,
            Rectangle,
            Tritangle
        }
        public ShapeFactory()
        {
            
        }

        // 創建圖形
        public Shape CreateShape(ShapeType shapeType, double x1, double y1, double x2, double y2)
        {
            Shape shape = null;
            switch (shapeType)
            {
                case ShapeType.Line:
                    shape = new Line(x1, y1, x2, y2);
                    break;
                case ShapeType.Rectangle:
                    shape = new Rectangle(x1, y1, x2, y2);
                    break;
                case ShapeType.Tritangle:
                    shape = new Triangle(x1, y1, x2, y2);
                    break;
                case ShapeType.Null:
                default:
                    break;
            }
            return shape;
        }
    }
}
