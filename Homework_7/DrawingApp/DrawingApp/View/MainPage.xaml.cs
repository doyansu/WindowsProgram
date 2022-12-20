using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        PresentationModel.AppPresentationModel _presentationModel;

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.AppPresentationModel(_model, new PresentationModel.AppGraphicsAdaptor(_canvas));
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _model._modelChanged += HandleModelChanged;
        }

        // 點擊矩形按鈕
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            this._presentationModel.HandleRectangleButtonClick();
        }

        // 點擊三角形按鈕
        private void HandleTriangleButtonClick(object sender, RoutedEventArgs e)
        {
            this._presentationModel.HandleTriangleButtonClick();
        }

        // 點擊線按鈕
        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            this._presentationModel.HandleLineButtonClick();
        }

        // 點擊清除畫布按鈕
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            this._presentationModel.HandleClearButtonClick();
        }

        // Undo 按鈕點擊
        private void HandleToolStripUndoButtonClick(object sender, RoutedEventArgs e)
        {
            this._model.Undo();
        }

        // Redo 按鈕點擊
        private void HandleToolStripRedoButtonClick(object sender, RoutedEventArgs e)
        {
            this._model.Redo();
        }

        // 畫布滑鼠點下
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 畫布滑鼠放開
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.HandleCanvasReleased(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 畫布滑鼠移動
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // HandleModelChanged
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }
    }
}
