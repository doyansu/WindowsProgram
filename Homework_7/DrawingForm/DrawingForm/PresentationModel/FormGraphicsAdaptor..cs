using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DrawingModel;

namespace DrawingFormSpace.PresentationModel
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

        // 交換數值
        private void Swap(ref double value1, ref double value2)
        {
            double temp = value1;
            value1 = value2;
            value2 = temp;
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
            float width = (float)(x2 - x1);
            float height = (float)(y2 - y1);
            float startX = (float)x1;
            float startY = (float)y1;
            System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            _graphics.FillRectangle(brush, startX, startY, width, height);
            _graphics.DrawRectangle(this._pen, startX, startY, width, height);
            brush.Dispose();
        }

        // 繪製三角形
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            const int HALF = 2;
            PointF[] points = { 
                new PointF((float)x1, (float)y2),
                new PointF((float)x2, (float)y2),
                new PointF((float)((x1 + x2) / HALF), (float)y1) };
            System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
            _graphics.FillPolygon(brush, points);
            _graphics.DrawPolygon(this._pen, points);
            brush.Dispose();
        }

        // 繪製選取虛線方框
        public void DrawSelectedRectangle(double x1, double y1, double x2, double y2)
        {
            const float DIAMETER = 6;
            const float RADIUS = DIAMETER / 2;
            const int PEN_WIDTH = 2;
            Pen pen = new Pen(Color.Red, PEN_WIDTH);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            _graphics.DrawRectangle(pen, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
            _graphics.FillEllipse(brush, (float)x1 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(this._pen, (float)x1 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.FillEllipse(brush, (float)x1 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(this._pen, (float)x1 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            _graphics.FillEllipse(brush, (float)x2 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(this._pen, (float)x2 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.FillEllipse(brush, (float)x2 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(this._pen, (float)x2 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            pen.Dispose();
            brush.Dispose();
        }
    }
}
