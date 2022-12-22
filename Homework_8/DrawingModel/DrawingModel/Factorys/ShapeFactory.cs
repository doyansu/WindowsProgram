using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ShapeFactory : IShapeFactory
    {
        public ShapeFactory()
        {
            
        }

        // 創建圖形
        public Shape CreateShape(ShapeType shapeType)
        {
            Shape shape = null;
            switch (shapeType)
            {
                case ShapeType.Line:
                    shape = new Line();
                    break;
                case ShapeType.Rectangle:
                    shape = new Rectangle();
                    break;
                case ShapeType.Triangle:
                    shape = new Triangle();
                    break;
                default:
                    break;
            }
            return shape;
        }
    }
}
