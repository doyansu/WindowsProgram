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
        private const string NOTIFY_NAME = "BookName";
        private const string NOTIFY_NUMBER = "BookNumber";
        private const string NOTIFY_AUTHOR = "BookAuthor";
        private const string NOTIFY_PUBLICATION_ITEM = "BookPublicationItem";

        private readonly string[] _notifyList = { 
            NOTIFY_BORROWING_COUNT,
            NOTIFY_NAME,
            NOTIFY_NUMBER,
            NOTIFY_AUTHOR,
            NOTIFY_PUBLICATION_ITEM };
        #endregion
        #endregion

        #region Constructor
        public BorrowingListRow(BookInformation bookInformation)
        {
            this._bookInformation = bookInformation;
        }
        #endregion

        // Refresh _bookInformation
        public void Refresh()
        {
            this._bookInformation.Reset();
            this.NotifyPropertyChanged();
        }

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

        // 通知所有 databing 改變
        private void NotifyPropertyChanged()
        {
            foreach (string dataBinding in this._notifyList)
                this.NotifyPropertyChanged(dataBinding);
        }

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
