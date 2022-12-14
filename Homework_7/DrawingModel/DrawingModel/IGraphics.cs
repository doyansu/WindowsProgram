using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        // 清除全部
        void ClearAll();
        // 繪製線
        void DrawLine(double x1, double y1, double x2, double y2);
        // 繪製矩形
        void DrawRectangle(double x1, double y1, double x2, double y2);
        // 繪製三角形
        void DrawTriangle(double x1, double y1, double x2, double y2);
        // 繪製選取虛線方框
        void DrawSelectedRectangle(double x1, double y1, double x2, double y2);
    }

}
