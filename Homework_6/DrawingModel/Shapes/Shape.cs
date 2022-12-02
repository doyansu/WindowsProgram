﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    abstract class Shape
    {
        private IPoint _topLeft;
        private IPoint _bottomRight;

        protected Shape()
        {
            _topLeft = new IPoint();
            _bottomRight = new IPoint();
        }

        protected Shape(IPoint topLeft, IPoint bottomRight)
        {
            _topLeft = topLeft.Copy();
            _bottomRight = bottomRight.Copy();
        }

        // 繪製圖形
        abstract public void Draw(IGraphics graphics);

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
