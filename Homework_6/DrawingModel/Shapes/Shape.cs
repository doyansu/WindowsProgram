using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    interface Shape
    {
        // 繪製圖形
        void Draw(IGraphics graphics);
    }
}
