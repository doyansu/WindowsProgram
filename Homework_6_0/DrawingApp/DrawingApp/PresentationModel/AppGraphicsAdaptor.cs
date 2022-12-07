using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    class AppGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        public AppGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // 清除全部
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // 繪製線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        // 繪製矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            double startX = x1 > x2 ? x2 : x1;
            double startY = y1 > y2 ? y2 : y1;
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Width = width;
            rectangle.Height = height;
            Canvas.SetLeft(rectangle, startX);
            Canvas.SetTop(rectangle, startY);
            _canvas.Children.Add(rectangle);
        }

        // 繪製三角形
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            if (x1 > x2)
                this.Swap(ref x1, ref x2);
            if (y1 > y2)
                this.Swap(ref y1, ref y2);
            Windows.UI.Xaml.Shapes.Polygon triangle = new Polygon();
            triangle.Stroke = new SolidColorBrush(Colors.Black);
            var points = new PointCollection();
            points.Add(new Windows.Foundation.Point(x1, y2));
            points.Add(new Windows.Foundation.Point(x2, y2));
            points.Add(new Windows.Foundation.Point((x1 + x2) / 2, y1));
            triangle.Points = points;
            _canvas.Children.Add(triangle);
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
