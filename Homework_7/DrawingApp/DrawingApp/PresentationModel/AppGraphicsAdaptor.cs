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

        private DoubleCollection DashArray 
        {
            get
            {
                return new DoubleCollection()
                {
                    3, 1, 1, 1 };
            }
        }

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
            double width = (x2 - x1);
            double height = (y2 - y1);
            Windows.UI.Xaml.Shapes.Rectangle rectangle = CreateRectangle(x1, y1, width, height);
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
            _canvas.Children.Add(rectangle);
        }

        // 繪製選取虛線方框
        public void DrawSelectedRectangle(double x1, double y1, double x2, double y2)
        {
            double width = (x2 - x1);
            double height = (y2 - y1);
            const int LINE_WIDTH = 2;
            Windows.UI.Xaml.Shapes.Rectangle rectangle = CreateRectangle(x1, y1, width, height);
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            rectangle.StrokeThickness = LINE_WIDTH;
            rectangle.StrokeDashArray = DashArray;
            _canvas.Children.Add(rectangle);
            const double DIAMETER = 6;
            const double RADIUS = DIAMETER / 2;
            _canvas.Children.Add(CreateEllipse(x1 - RADIUS, y1 - RADIUS, DIAMETER, DIAMETER));
            _canvas.Children.Add(CreateEllipse(x1 - RADIUS, y2 - RADIUS, DIAMETER, DIAMETER));
            _canvas.Children.Add(CreateEllipse(x2 - RADIUS, y1 - RADIUS, DIAMETER, DIAMETER));
            _canvas.Children.Add(CreateEllipse(x2 - RADIUS, y2 - RADIUS, DIAMETER, DIAMETER));
        }

        // 繪製三角形
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Polygon triangle = new Polygon();
            triangle.Stroke = new SolidColorBrush(Colors.Black);
            var points = new PointCollection();
            points.Add(new Windows.Foundation.Point(x1, y2));
            points.Add(new Windows.Foundation.Point(x2, y2));
            points.Add(new Windows.Foundation.Point((x1 + x2) / 2, y1));
            triangle.Points = points;
            triangle.Fill = new SolidColorBrush(Windows.UI.Colors.Orange);
            _canvas.Children.Add(triangle);
        }

        // 創建圓形
        private Windows.UI.Xaml.Shapes.Ellipse CreateEllipse(double x1, double y1, double width, double height)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            ellipse.Width = width;
            ellipse.Height = height;
            Canvas.SetLeft(ellipse, x1);
            Canvas.SetTop(ellipse, y1);
            return ellipse;
        }

        // 創建矩形
        private Windows.UI.Xaml.Shapes.Rectangle CreateRectangle(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            Canvas.SetLeft(rectangle, x1);
            Canvas.SetTop(rectangle, y1);
            return rectangle;
        }
    }
}
