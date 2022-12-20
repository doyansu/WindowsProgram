using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrawingApp.PresentationModel
{
    public class AppPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model _model;
        IGraphics _graphics;

        private bool _isRectangleButtonEnabled = true;
        private bool _isTriangleButtonEnabled = true;
        private bool _isLineButtonEnabled = true;


        public AppPresentationModel(Model model, IGraphics graphics)
        {
            this._model = model;
            _graphics = graphics;
        }

        // 重置狀態
        private void Reset()
        {
            this.IsRectangleButtonEnabled = true;
            this.IsTriangleButtonEnabled = true;
            this.IsLineButtonEnabled = true;
            this._model.DrawingShapeMode = ShapeType.Null;
        }

        // 設定按鈕啟用
        private void SetButtonEnable(bool isRectangleButtonEnabled, bool isTriangleButtonEnabled, bool isLineButtonEnabled)
        {
            this.IsRectangleButtonEnabled = isRectangleButtonEnabled;
            this.IsTriangleButtonEnabled = isTriangleButtonEnabled;
            this.IsLineButtonEnabled = isLineButtonEnabled;
        }

        // 點擊矩形按鈕
        public void HandleRectangleButtonClick()
        {
            SetButtonEnable(false, true, true);
            this._model.DrawingShapeMode = ShapeType.Rectangle;
        }

        // 點擊三角形按鈕
        public void HandleTriangleButtonClick()
        {
            SetButtonEnable(true, false, true);
            this._model.DrawingShapeMode = ShapeType.Triangle;
        }

        // 點擊畫線按鈕
        public void HandleLineButtonClick()
        {
            SetButtonEnable(true, true, false);
            this._model.DrawingShapeMode = ShapeType.Line;
        }

        // 點擊清除畫布按鈕
        public void HandleClearButtonClick()
        {
            _model.Clear();
            this.Reset();
        }

        // 完成畫布繪製
        public void HandleCanvasReleased(double pointX, double pointY)
        {
            if (_model.ReleasePointer(pointX, pointY))
                this.Reset();
        }

        // 繪製圖形
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphics);
        }

        public bool IsRectangleButtonEnabled
        {
            get
            {
                return _isRectangleButtonEnabled;
            }
            set
            {
                if (this._isRectangleButtonEnabled != value)
                {
                    this._isRectangleButtonEnabled = value;
                    NotifyPropertyChanged("IsRectangleButtonEnabled");
                }
            }
        }
        public bool IsTriangleButtonEnabled
        {
            get
            {
                return _isTriangleButtonEnabled;
            }
            set
            {
                if (this._isTriangleButtonEnabled != value)
                {
                    this._isTriangleButtonEnabled = value;
                    NotifyPropertyChanged("IsTriangleButtonEnabled");
                }
            }
        }

        public bool IsLineButtonEnabled
        {
            get
            {
                return _isLineButtonEnabled;
            }
            set
            {
                if (this._isLineButtonEnabled != value)
                {
                    this._isLineButtonEnabled = value;
                    NotifyPropertyChanged("IsLineButtonEnabled");
                }
            }
        }

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
