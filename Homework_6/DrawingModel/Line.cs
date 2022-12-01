using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line : Shape
    {
        private double _x1 = 0;
        private double _y1 = 0;
        private double _x2 = 0;
        private double _y2 = 0;

        public Line()
        {

        }

        public Line(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;
        }

        // 繪製線
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_x1, _y1, _x2, _y2);
        }
    }
}
