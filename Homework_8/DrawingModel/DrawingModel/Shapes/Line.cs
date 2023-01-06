using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        Shape _startShape;
        Shape _endShape;

        public Line()
        {
            this._shapeType = ShapeType.Line;
            _startShape = _endShape = null;
        }

        // 可繪製線
        public bool CanDraw
        {
            get
            {
                return _startShape != null && _endShape != null;
            }
        }

        public Shape StartShape 
        {
            get
            {
                return _startShape;
            }
            set
            {
                _startShape = value;
            }
        }

        public Shape EndShape 
        {
            get
            {
                return _endShape;
            }
            set
            {
                _endShape = value;
            }
        }

        // 繪製線
        public override void Draw(IGraphics graphics)
        {
            if (this.CanDraw)
                graphics.DrawLine(_startShape.GetCenterX(), _startShape.GetCenterY(), _endShape.GetCenterX(), _endShape.GetCenterY());
        }

        // IsContains Line always false
        public override bool IsContains(double pointX, double pointY)
        {
            return false;
        }

        // GetJsonString
        public override string GetObjectString()
        {
            var options = new JsonSerializerOptions
            { 
                WriteIndented = true };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
