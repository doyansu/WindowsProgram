using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public abstract class Shape
    {
        private IPoint _start = new IPoint();
        private IPoint _end = new IPoint();
        private bool _isSelected = false;

        protected Shape()
        {

        }

        protected Shape(IPoint start, IPoint end)
        {
            _start = start.Copy();
            _end = end.Copy();
        }

        // 繪製圖形
        abstract public void Draw(IGraphics graphics);

        // 點是否包含在圖形內
        virtual public bool IsContains(double pointX, double pointY)
        {
            return pointX >= this.Left && pointX <= this.Right && pointY >= this.Top && pointY <= this.Bottom;
        }

        // 取得中心點
        virtual public IPoint GetCenter()
        {
            return _start.GetCenter(_end);
        }

        // 取得中心 X
        virtual public double GetCenterX()
        {
            return _start.GetCenterX(_end);
        }

        // 取得中心 Y
        virtual public double GetCenterY()
        {
            return _start.GetCenterY(_end);
        }

        // 圖形資訊
        virtual public string ShapeInformation()
        {
            const string SHAPE_NAME = "Shape";
            return FormatShapeInformation(SHAPE_NAME);
        }

        // Infomation 格式
        protected string FormatShapeInformation(string shapeName)
        {
            const string STRING_FORMAT = "{0}({1}, {2}, {3}, {4})";
            return string.Format(STRING_FORMAT, shapeName, this.Left, this.Top, this.Right, this.Bottom);
        }

        public double StartX
        {
            get
            {
                return _start.X;
            }
            set
            {
                _start.X = value;
            }
        }
        public double StartY
        {
            get
            {
                return _start.Y;
            }
            set
            {
                _start.Y = value;
            }
        }
        public double EndX
        {
            get
            {
                return _end.X;
            }
            set
            {
                _end.X = value;
            }
        }
        public double EndY
        {
            get
            {
                return _end.Y;
            }
            set
            {
                _end.Y = value;
            }
        }
        public double Left
        {
            get
            {
                return _start.X < _end.X ? _start.X : _end.X;
            }
        }
        public double Top
        {
            get
            {
                return _start.Y < _end.Y ? _start.Y : _end.Y;
            }
        }
        public double Right
        {
            get
            {
                return _start.X > _end.X ? _start.X : _end.X;
            }
        }
        public double Bottom
        {
            get
            {
                return _start.Y > _end.Y ? _start.Y : _end.Y;
            }
        }

        public bool IsSelected 
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
            }
        }
    }
}
