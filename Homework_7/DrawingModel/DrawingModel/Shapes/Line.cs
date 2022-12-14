using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        public Line()
        {

        }

        public Line(IPoint topLeft, IPoint bottomRight) : base(topLeft, bottomRight)
        {
            
        }

        public Line(double x1, double y1, double x2, double y2)
        {
            this.StartX = x1;
            this.StartY = y1;
            this.EndX = x2;
            this.EndY = y2;
        }

        // 繪製線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(StartX, StartY, EndX, EndY);
        }

        // IsContains Line always false
        public override bool IsContains(double pointX, double pointY)
        {
            return false;
        }
    }
}
