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
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        // 繪製線
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(X1, Y1, X2, Y2);
        }

        public double X1 
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }
        public double Y1 
        {
            get
            {
                return _y1;
            }
            set
            {
                _y1 = value;
            }
        }
        public double X2 
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }
        public double Y2 
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }
    }
}
