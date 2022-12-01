using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;
using System.Windows.Forms;
using System.ComponentModel;

namespace DrawingForm.PresentationModel
{
    class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model _model;

        bool _isRectangleButtonEnabled = true;
        bool _isTriangleButtonEnabled = true;
        public PresentationModel(Model model)
        {
            this._model = model;
        }

        // 點擊矩形按鈕
        public void HandleRectangleButtonClick()
        {
            this.IsRectangleButtonEnabled = false;
            this.IsTriangleButtonEnabled = true;
        }

        // 點擊三角形按鈕
        public void HandleTriangleButtonClick()
        {
            this.IsRectangleButtonEnabled = true;
            this.IsTriangleButtonEnabled = false;
        }

        public bool IsRectangleButtonEnabled
        {
            get
            {
                return _isRectangleButtonEnabled;
            }
            set
            {
                this._isRectangleButtonEnabled = value;
                NotifyPropertyChanged("IsRectangleButtonEnabled");
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
                this._isTriangleButtonEnabled = value;
                NotifyPropertyChanged("IsTriangleButtonEnabled");
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
