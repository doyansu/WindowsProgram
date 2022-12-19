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
            this._shapeType = ShapeType.Triangle;
        }

        // 繪製線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(this.Left, this.Top, this.Right, this.Bottom);
        }

        // IsContains
        public override bool IsContains(double pointX, double pointY)
        {
            IPoint point1 = new IPoint(this.GetCenterX(), this.Top);
            IPoint point2 = new IPoint(this.Left, this.Bottom);
            IPoint point3 = new IPoint(this.Right, this.Bottom);
            IPoint point = new IPoint(pointX, pointY);
            return point.IsInTriangle(point1, point2, point3);
        }

        // 圖形資訊
        public override string ShapeInformation()
        {
            const string SHAPE_NAME = "Triangle";
            return FormatShapeInformation(SHAPE_NAME);
        }
    }
}
