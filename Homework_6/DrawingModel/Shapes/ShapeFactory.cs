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
            Triangle
        }
        public ShapeFactory()
        {
            
        }

        // 創建圖形
        public Shape CreateShape(ShapeType shapeType, IPoint topLeft, IPoint bottomRight)
        {
            Shape shape = null;
            switch (shapeType)
            {
                case ShapeType.Line:
                    shape = new Line(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
                    break;
                case ShapeType.Rectangle:
                    shape = new Rectangle(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
                    break;
                case ShapeType.Triangle:
                    shape = new Triangle(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
                    break;
                case ShapeType.Null:
                default:
                    break;
            }
            return shape;
        }
    }
}
