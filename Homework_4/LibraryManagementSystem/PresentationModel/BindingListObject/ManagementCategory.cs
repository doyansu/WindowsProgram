using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class ManagementCategory : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private string _category;

        private const string NOTIFY_CATEGORY = "Category";

        public ManagementCategory(string category)
        {
            this._category = category;
        }

        public string Category 
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
                NotifyPropertyChanged(NOTIFY_CATEGORY);
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
