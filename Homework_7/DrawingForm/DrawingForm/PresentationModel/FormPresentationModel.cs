using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrawingFormSpace.PresentationModel
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model _model;

        bool _isRectangleButtonEnabled = true;
        bool _isTriangleButtonEnabled = true;
        public FormPresentationModel(Model model)
        {
            this._model = model;
        }

        // 重置狀態
        private void Reset()
        {
            this.IsRectangleButtonEnabled = true;
            this.IsTriangleButtonEnabled = true;
            this._model.DrawingShapeMode = ShapeType.Null;
        }

        // 點擊矩形按鈕
        public void HandleRectangleButtonClick()
        {
            this.IsRectangleButtonEnabled = false;
            this.IsTriangleButtonEnabled = true;
            this._model.DrawingShapeMode = ShapeType.Rectangle;
        }

        // 點擊三角形按鈕
        public void HandleTriangleButtonClick()
        {
            this.IsRectangleButtonEnabled = true;
            this.IsTriangleButtonEnabled = false;
            this._model.DrawingShapeMode = ShapeType.Triangle;
        }

        // 點擊清除畫布按鈕
        public void HandleClearButtonClick()
        {
            _model.Clear();
            this.Reset();
        }

        // 完成畫布繪製
        public void HandleCanvasReleased(int pointX, int pointY)
        {
            _model.ReleasePointer(pointX, pointY);
            this.Reset();
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
