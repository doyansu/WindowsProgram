using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingWindowsStoreApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const int CANVAS_SIZE = 400;
        private const int BALL_SIZE = 50;
        private const double STROKE_THICKNESS = 5;
        private SolidColorBrush _whiteColor = new SolidColorBrush(Colors.White);
        private SolidColorBrush _blueColor = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush _blackColor = new SolidColorBrush(Colors.Black);
        private SolidColorBrush _yellowColor = new SolidColorBrush(Colors.Yellow);
        private SolidColorBrush _greenYellowColor = new SolidColorBrush(Colors.GreenYellow);
        private SolidColorBrush _purpleColor = new SolidColorBrush(Colors.Purple);
        public MainPage()
        {
            this.InitializeComponent();
            _canvas.Width = CANVAS_SIZE;
            _canvas.Height = CANVAS_SIZE;
            _canvas.Background = _whiteColor;

            // Three blue blocks
            Rectangle rectangle = new Rectangle();
            InitializeShape(rectangle, 0, 0, 150, 100, _blueColor);
            _canvas.Children.Add(rectangle);
            rectangle = new Rectangle();
            InitializeShape(rectangle, 0, 250, 150, 150, _blueColor);
            _canvas.Children.Add(rectangle);
            rectangle = new Rectangle();
            InitializeShape(rectangle, 300, 0, 100, 275, _blueColor);
            _canvas.Children.Add(rectangle);
            // Five balls
            Ellipse ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 25, BALL_SIZE, BALL_SIZE,
            _greenYellowColor);
            _canvas.Children.Add(ellipse);
            ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 125, BALL_SIZE, BALL_SIZE,
            _greenYellowColor);
            _canvas.Children.Add(ellipse);
            ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 225, BALL_SIZE, BALL_SIZE,
            _greenYellowColor);
            _canvas.Children.Add(ellipse);

            ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 325, BALL_SIZE, BALL_SIZE,
            _greenYellowColor);
            _canvas.Children.Add(ellipse);
            ellipse = new Ellipse();
            InitializeShape(ellipse, 300, 325, BALL_SIZE, BALL_SIZE,
            _greenYellowColor); _canvas.Children.Add(ellipse);

            _textBlock.Text = "Where is the mouse?";
            _canvas.PointerPressed += PressOnCanvas;
            _canvas.PointerMoved += MoveOnCanvas;

        }

        private Shape InitializeShape(Shape shape, int left, int top, int right, int bottom, SolidColorBrush fillColorBrush)
        {
            shape.Margin = new Thickness(left, top, right, bottom);
            shape.Width = right;
            shape.Height = bottom;
            shape.Fill = fillColorBrush;
            shape.Stroke = _purpleColor;
            shape.StrokeThickness = STROKE_THICKNESS;
            return shape;
        }

        //滑鼠點擊
        private void PressOnCanvas(object sender, PointerRoutedEventArgs e)
        {
            double pressX = Math.Round(e.GetCurrentPoint(_canvas).Position.X, 2);
            double pressY = Math.Round(e.GetCurrentPoint(_canvas).Position.Y, 2);
            _textBlock.Text = "You pressed on (" + pressX + ", " + pressY + ")";
        }

        //滑鼠移動
        private void MoveOnCanvas(object sender, PointerRoutedEventArgs e)
        {
            double moveX = Math.Round(e.GetCurrentPoint(_canvas).Position.X, 2);
            double moveY = Math.Round(e.GetCurrentPoint(_canvas).Position.Y, 2);
            _textBlock.Text = "You moved on (" + moveX + ", " + moveY + ")";
        }

    }
}
