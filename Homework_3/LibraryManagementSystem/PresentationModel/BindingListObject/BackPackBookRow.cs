using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class BackPackBookRow : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private int _returnCount;
        private string _bookName;
        private int _borrowedCount;
        private string _borrowingDate;
        private string _returnDue;
        private string _bookNumber;
        private string _bookAuthor;
        private string _bookPublicationItem;

        #region Const Attributes
        private readonly string _notifyReturnCount = "ReturnCount";
        private readonly string _returnButtonValue = "";
        #endregion
        #endregion

        #region Constructor
        public BackPackBookRow(List<string> data)
        {
            int dataMappingIndex = 0;
            this._returnCount = 1;
            this._bookName = data[dataMappingIndex++];
            this._borrowedCount = int.Parse(data[dataMappingIndex++]);
            this._borrowingDate = data[dataMappingIndex++];
            this._returnDue = data[dataMappingIndex++];
            this._bookNumber = data[dataMappingIndex++];
            this._bookAuthor = data[dataMappingIndex++];
            this._bookPublicationItem = data[dataMappingIndex++];
        }
        #endregion

        #region Member Function
        #endregion

        #region Property
        public string ReturnButton
        {
            get
            {
                return _returnButtonValue;
            }
        }

        public int ReturnCount 
        {
            get
            {
                return _returnCount;
            }
            set
            {
                _returnCount = value;
                NotifyPropertyChanged(_notifyReturnCount);
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
