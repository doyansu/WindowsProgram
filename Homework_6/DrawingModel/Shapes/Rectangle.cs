using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Rectangle : Shape
    {
        public Rectangle()
        {

        }

        public Rectangle(IPoint topLeft, IPoint bottomRight) : base(topLeft, bottomRight)
        {

        }

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        // 繪製線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }
    }
}
