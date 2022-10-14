using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class TabPageButtonVisible : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isVisible = false;

        const string NOTIFY_BUTTON_VISIBLE = "IsVisible";

        public TabPageButtonVisible()
        {

        }

        public bool IsVisible 
        {
            get
            {
                return this._isVisible;
            }
            set
            {
                if (this._isVisible != value)
                {
                    this._isVisible = value;
                    this.NotifyPropertyChanged(NOTIFY_BUTTON_VISIBLE);
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
