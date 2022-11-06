using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class TabPageButton : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BookInformation _bookInformation;
        private bool _isVisible = false;

        const string NOTIFY_BUTTON_VISIBLE = "IsVisible";

        public TabPageButton(BookInformation bookInformation)
        {
            this._bookInformation = bookInformation;
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

        public string BookName
        {
            get
            {
                return this._bookInformation.BookName;
            }
        }

        public string BookImagePath
        {
            get
            {
                return this._bookInformation.BookImagePath;
            }
        }

        public BookInformation BookInformationObject
        {
            get
            {
                return this._bookInformation;
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
