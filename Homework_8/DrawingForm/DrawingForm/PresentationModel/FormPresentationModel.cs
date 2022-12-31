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
        bool _isLineButtonEnabled = true;

        public FormPresentationModel(Model model)
        {
            this._model = model;
            this._model._commandReleased += this.Reset;
        }

        // 設定按鈕啟用
        private void SetButtonEnable(bool isRectangleButtonEnabled, bool isTriangleButtonEnabled, bool isLineButtonEnabled)
        {
            this.IsRectangleButtonEnabled = isRectangleButtonEnabled;
            this.IsTriangleButtonEnabled = isTriangleButtonEnabled;
            this.IsLineButtonEnabled = isLineButtonEnabled;
        }

        // 重置狀態
        private void Reset()
        {
            SetButtonEnable(true, true, true);
            this._model.SetSelectionMode();
        }

        // 點擊矩形按鈕
        public void HandleRectangleButtonClick()
        {
            SetButtonEnable(false, true, true);
            this._model.SetDrawShapeMode(ShapeType.Rectangle);
        }

        // 點擊三角形按鈕
        public void HandleTriangleButtonClick()
        {
            SetButtonEnable(true, false, true);
            this._model.SetDrawShapeMode(ShapeType.Triangle);
        }

        // 點擊畫線按鈕
        public void HandleLineButtonClick()
        {
            SetButtonEnable(true, true, false);
            this._model.SetDrawLineMode();
        }

        // 點擊清除畫布按鈕
        public void HandleClearButtonClick()
        {
            _model.Clear();
        }

        // 完成畫布繪製
        public void HandleCanvasReleased(int pointX, int pointY)
        {
            _model.ReleasePointer(pointX, pointY);
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
