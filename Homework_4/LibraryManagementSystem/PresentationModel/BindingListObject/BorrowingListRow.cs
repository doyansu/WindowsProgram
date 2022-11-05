using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class BorrowingListRow : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private BookInformation _bookInformation;
        private int _borrowingCount = 1;

        #region Const Attributes
        private const string NOTIFY_BORROWING_COUNT = "BorrowingCount";
        #endregion
        #endregion

        #region Constructor
        public BorrowingListRow(BookInformation bookInformation)
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

        public int BorrowingCount
        {
            get
            {
                return this._borrowingCount;
            }
            set
            {
                _borrowingCount = value;
                this.NotifyPropertyChanged(NOTIFY_BORROWING_COUNT);
            }
        }
        public string BookNumber
        {
            get
            {
                return this._bookInformation.BookNumber;
            }
        }

        public string BookAuthor
        {
            get
            {
                return this._bookInformation.BookAuthor;
            }
        }

        public string BookPublicationItem
        {
            get
            {
                return this._bookInformation.BookPublicationItem;
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
