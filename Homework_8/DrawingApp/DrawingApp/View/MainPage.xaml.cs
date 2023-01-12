using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

        const string PRIMARY_TEXT = "確定";
        const string CLOSE_TEXT = "取消";
        const string STRING_EMPTY = "";

        public MainPage()
        {
            const string APPLICATION_NAME = "DrawingApp";
            const string CLIENT_SECRET_FILE_NAME = @"./Model/GoogleDrive/clientSecret.json";
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _model.FileService = new DrawingModel.GoogleDrive.GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
            _model._modelChanged += HandleModelChanged;
            _presentationModel = new PresentationModel.AppPresentationModel(_model, new PresentationModel.AppGraphicsAdaptor(_canvas));
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
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

        // 點擊儲存按鈕
        private async void HandleSaveButtonClick(object sender, RoutedEventArgs e)
        {
            const string MESSAGE_BOX_TITLE = "Save Shapes";
            const string MESSAGE_BOX_CONTENT = "是否要儲存?";
            const string MESSAGE_BOX_FINISH = "儲存完成";
            ContentDialogResult result = await ShowDialogAsync(MESSAGE_BOX_CONTENT, MESSAGE_BOX_TITLE, CLOSE_TEXT, PRIMARY_TEXT);
            if (result == ContentDialogResult.Primary)
            {
                await Task.Run(this._model.SaveShapes);
                await ShowDialogAsync(MESSAGE_BOX_FINISH, MESSAGE_BOX_TITLE);
            }
        }

        

        // 點擊下載按鈕
        private async void HandleLoadButtonClick(object sender, RoutedEventArgs e)
        {
            const string MESSAGE_BOX_TITLE = "Load Shapes";
            const string MESSAGE_BOX_CONTENT = "是否要重新載入?";
            const string MESSAGE_BOX_FINISH = "下載完成";
            const string EXCEPTION_MESSAGE = "找不到儲存檔案";
            const string EXCEPTION_TITLE = "Load Error";
            ContentDialogResult result = await ShowDialogAsync(MESSAGE_BOX_CONTENT, MESSAGE_BOX_TITLE, CLOSE_TEXT, PRIMARY_TEXT);
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    this._model.LoadShapesCommand();
                    await ShowDialogAsync(MESSAGE_BOX_FINISH, MESSAGE_BOX_TITLE);
                }
                catch
                {
                    await ShowDialogAsync(EXCEPTION_MESSAGE, EXCEPTION_TITLE);
                }
            }
        }

        // ShowDialog
        private async Task<ContentDialogResult> ShowDialogAsync(string content, string title = STRING_EMPTY, string closeButtonText = PRIMARY_TEXT, string primaryButtonText = null)
        {
            ContentDialog locationPromptDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = closeButtonText
            };
            if (primaryButtonText != null)
                locationPromptDialog.PrimaryButtonText = primaryButtonText;
            ContentDialogResult result = await locationPromptDialog.ShowAsync();
            return result;
        }
    }
}
