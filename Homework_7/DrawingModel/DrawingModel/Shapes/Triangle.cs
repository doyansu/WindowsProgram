using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Triangle : Shape
    {
        public Triangle()
        {

        }

        public Triangle(IPoint topLeft, IPoint bottomRight) : base(topLeft, bottomRight)
        {

        }

        public Triangle(double x1, double y1, double x2, double y2)
        {
            this.StartX = x1;
            this.StartY = y1;
            this.EndX = x2;
            this.EndY = y2;
        }

        // 繪製線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(this.Left, this.Top, this.Right, this.Bottom);
            if (this.IsSelected)
                graphics.DrawSelectedRectangle(this.Left, this.Top, this.Right, this.Bottom);
        }

        // IsContains
        public override bool IsContains(double pointX, double pointY)
        {
            IPoint point1 = new IPoint(this.GetCenterX(), this.Top);
            IPoint point2 = new IPoint(this.Left, this.Bottom);
            IPoint point3 = new IPoint(this.Right, this.Bottom);
            IPoint point = new IPoint(pointX, pointY);
            return GetProduct(point1, point2, point) < 0 && GetProduct(point2, point3, point) < 0 && GetProduct(point3, point1, point) < 0;
        }

        // 圖形資訊
        public override string ShapeInformation()
        {
            const string SHAPE_NAME = "Triangle";
            return FormatShapeInformation(SHAPE_NAME);
        }

        // 向量 Product
        private double GetProduct(IPoint point1, IPoint point2, IPoint point3)
        {
            double product = (point2.X - point1.X) * (point3.Y - point1.Y) - (point2.Y - point1.Y) * (point3.X - point1.X);
            return product;
        }
    }
}
