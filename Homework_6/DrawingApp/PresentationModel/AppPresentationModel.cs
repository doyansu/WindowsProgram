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
    class AppPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model _model;
        IGraphics _graphics;

        private bool _isRectangleButtonEnabled = true;
        private bool _isTriangleButtonEnabled = true;

        public AppPresentationModel(Model model, IGraphics graphics)
        {
            this._model = model;
            _graphics = graphics;
        }

        // 點擊矩形按鈕
        public void HandleRectangleButtonClick()
        {
            this.IsRectangleButtonEnabled = false;
            this.IsTriangleButtonEnabled = true;
            this._model.DrawingShapeType = ShapeFactory.ShapeType.Rectangle;
        }

        // 點擊三角形按鈕
        public void HandleTriangleButtonClick()
        {
            this.IsRectangleButtonEnabled = true;
            this.IsTriangleButtonEnabled = false;
            this._model.DrawingShapeType = ShapeFactory.ShapeType.Triangle;
        }

        // 點擊清除畫布按鈕
        public void HandleClearButtonClick()
        {
            _model.Clear();
            this.IsRectangleButtonEnabled = true;
            this.IsTriangleButtonEnabled = true;
            this._model.DrawingShapeType = ShapeFactory.ShapeType.Null;
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

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
