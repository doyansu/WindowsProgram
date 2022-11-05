using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class InventoryListRow : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private BookInformation _bookInformation;
        #endregion

        #region Constructor
        public InventoryListRow(BookInformation bookInformation)
        {
            this._bookInformation = bookInformation;
        }
        #endregion

        #region Property
        public string BookName
        {
            get
            {
                return this._bookInformation.BookName;
            }
        }

        public string BookCategory 
        {
            get
            {
                return this._bookInformation.BookCategory;
            }
        }

        public int BookQuantity 
        {
            get
            {
                return this._bookInformation.BookQuantity;
            }
        }

        public string BookFormatInformation 
        {
            get
            {
                return this._bookInformation._bookFormatInformation;
            }
        }
        #endregion

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
