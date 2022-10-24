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
        private string _bookName;
        private int _borrowingCount;
        private string _bookNumber;
        private string _bookAuthor;
        private string _bookPublicationItem;

        #region Const Attributes
        private const string NOTIFY_BORROWING_COUNT = "BorrowingCount";
        #endregion
        #endregion

        #region Constructor
        public BorrowingListRow(List<string> data)
        {
            int dataMappingIndex = 0;
            this._bookName = data[dataMappingIndex++];
            this._borrowingCount = 1;
            this._bookNumber = data[dataMappingIndex++];
            this._bookAuthor = data[dataMappingIndex++];
            this._bookPublicationItem = data[dataMappingIndex++];
        }
        #endregion

        #region Property
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

        public int BorrowingCount
        {
            get
            {
                return _borrowingCount;
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
