using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class BackPackListRow : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private BorrowedBookInformation _borrowedBookInformation;
        private int _returnCount;
        private string _bookName;
        private int _borrowedCount;
        private string _borrowingDate;
        private string _returnDue;
        private string _bookNumber;
        private string _bookAuthor;
        private string _bookPublicationItem;

        #region Const Attributes
        private const string NOTIFY_RETURN_COUNT = "ReturnCount";
        #endregion
        #endregion

        #region Constructor
        public BackPackListRow(BorrowedBookInformation borrowedBookInformation)
        {
            this._borrowedBookInformation = borrowedBookInformation;
            this._returnCount = 1;
            this._bookName = borrowedBookInformation.BookName;
            this._borrowedCount = borrowedBookInformation.BookQuantity;
            this._borrowingDate = borrowedBookInformation.BorrowingDate.ToShortDateString();
            this._returnDue = borrowedBookInformation.ReturnDue.ToShortDateString();
            this._bookNumber = borrowedBookInformation.BookNumber;
            this._bookAuthor = borrowedBookInformation.BookAuthor;
            this._bookPublicationItem = borrowedBookInformation.BookPublicationItem;
        }
        #endregion

        #region Property
        public int ReturnCount 
        {
            get
            {
                return _returnCount;
            }
            set
            {
                _returnCount = value;
                NotifyPropertyChanged(NOTIFY_RETURN_COUNT);
            }
        }

        public string BookName 
        {
            get
            {
                return _bookName;
            }
            set
            {
                _bookName = value;
            }
        }

        public int BorrowedCount 
        {
            get
            {
                return _borrowedCount;
            }
            set
            {
                _borrowedCount = value;
            }
        }

        public string BorrowingDate 
        {
            get
            {
                return _borrowingDate;
            }
            set
            {
                _borrowingDate = value;
            }
        }

        public string ReturnDue
        {
            get
            {
                return _returnDue;
            }
            set
            {
                _returnDue = value;
            }
        }

        public string BookNumber 
        {
            get
            {
                return _bookNumber;
            }
            set
            {
                _bookNumber = value;
            }
        }

        public string BookAuthor 
        {
            get
            {
                return _bookAuthor; 
            }

            set
            {
                _bookAuthor = value;
            }
        }

        public string BookPublicationItem 
        {
            get
            {
                return _bookPublicationItem;
            }
            set
            {
                _bookPublicationItem = value;
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
