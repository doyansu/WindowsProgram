using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {

        }

        public Rectangle(IPoint topLeft, IPoint bottomRight) : base(topLeft, bottomRight)
        {

        }

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            this.StartX = x1;
            this.StartY = y1;
            this.EndX = x2;
            this.EndY = y2;
        }

        // 繪製線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(this.Left, this.Top, this.Right, this.Bottom);
        }

        // 圖形資訊
        public override string ShapeInformation()
        {
            const string SHAPE_NAME = "Rectangle";
            return FormatShapeInformation(SHAPE_NAME);
        }
    }
}
