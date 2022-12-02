using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class IPoint
    {
        double _x = 0;
        double _y = 0;

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
