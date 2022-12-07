using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DrawingModel;

namespace DrawingForm.PresentationModel
{
    class FormGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        Pen _pen;

        public FormGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
            this._pen = Pens.Black;
        }

        // 設定 Pen
        public void SetPen(Pen pen)
        {
            this._pen = pen;
        }

        // 清除全部
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // 繪製線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(this._pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // 繪製矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            float startX = x1 > x2 ? (float)x2 : (float)x1;
            float startY = y1 > y2 ? (float)y2 : (float)y1;
            _graphics.DrawRectangle(this._pen, startX, startY, width, height);
        }

        // 繪製三角形
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            if (x1 > x2)
                this.Swap(ref x1, ref x2);
            if (y1 > y2)
                this.Swap(ref y1, ref y2);
            PointF[] points = { 
                new PointF((float)x1, (float)y2),
                new PointF((float)x2, (float)y2),
                new PointF((float)((x1 + x2) / 2), (float)y1) };
            _graphics.DrawPolygon(this._pen, points);
        }

        // 交換數值
        private void Swap(ref double value1, ref double value2)
        {
            double temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
}
