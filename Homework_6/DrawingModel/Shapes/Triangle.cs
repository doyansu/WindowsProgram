using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Triangle : Shape
    {
        private IPoint _topLeft = new IPoint();
        private IPoint _bottomRight = new IPoint();
        public Triangle()
        {

        }

        public Triangle(IPoint topLeft, IPoint bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        public Triangle(double x1, double y1, double x2, double y2)
        {
            _topLeft.X = x1;
            _topLeft.Y = y1;
            _bottomRight.X = x2;
            _bottomRight.Y = y2;
        }

        // 繪製線
        public void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(X1, Y1, X2, Y2);
        }

        public double X1
        {
            get
            {
                return _topLeft.X;
            }
            set
            {
                _topLeft.X = value;
            }
        }
        public double Y1
        {
            get
            {
                return _topLeft.Y;
            }
            set
            {
                _topLeft.Y = value;
            }
        }
        public double X2
        {
            get
            {
                return _bottomRight.X;
            }
            set
            {
                _bottomRight.X = value;
            }
        }
        public double Y2
        {
            get
            {
                return _bottomRight.Y;
            }
            set
            {
                _bottomRight.Y = value;
            }
        }
    }
}
