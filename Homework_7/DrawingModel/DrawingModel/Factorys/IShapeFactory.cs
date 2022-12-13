﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public enum ShapeType
    {
        Null,
        Line,
        Rectangle,
        Triangle
    }

    public interface IShapeFactory
    {
        // 創建圖形
        Shape CreateShape(ShapeType shapeType);
    }
}
