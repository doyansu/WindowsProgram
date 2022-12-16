using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        Shape _startShape;
        Shape _endShape;

        public Line()
        {

        }

        public Line(Shape startShape, Shape endShape) : base(startShape.GetCenter(), endShape.GetCenter())
        {
            _startShape = startShape;
            _endShape = endShape;
        }

        // 繪製線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_startShape.GetCenterX(), _startShape.GetCenterY(), _endShape.GetCenterX(), _endShape.GetCenterY());
        }

        // IsContains Line always false
        public override bool IsContains(double pointX, double pointY)
        {
            return false;
        }
    }
}
