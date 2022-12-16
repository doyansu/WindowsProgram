using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class IPoint
    {
        double _x = 0;
        double _y = 0;

        const int TWO = 2;

        public IPoint()
        {

        }

        public IPoint(double pointX, double pointY)
        {
            _x = pointX;
            _y = pointY;
        }

        // 取得複製 IPoint 物件
        public IPoint Copy()
        {
            IPoint copyPoint = new IPoint(this.X, this.Y);
            return copyPoint;
        }

        // 取得 2 點中心
        public double GetCenterX(IPoint point)
        {
            return (this.X + point.X) / TWO;
        }

        // 取得 2 點中心
        public double GetCenterY(IPoint point)
        {
            return (this.Y + point.Y) / TWO;
        }

        // 取得中心點
        public IPoint GetCenter(IPoint point)
        {
            return new IPoint(this.GetCenterX(point), this.GetCenterY(point));
        }

        public double X 
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public double Y 
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
    }
}
