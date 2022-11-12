using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    public class BookBorrowingFormPresentationModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action _selectedBookChanged;
        #endregion

        private Library _model;

        private BookInformation _selectedBookInformation = null;

        private readonly string[] _notifyList = { 
            "SelectedBookInformation",
            "SelectedBookQuantityString", };

        const string STRING_EMPTY_VALUE = "";

        public BookBorrowingFormPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.SelectedBookChanged;
        }

        // 取消選擇書籍
        public void UnselectBook()
        {
            this.SelectedBookInformation = null;
        }

        public BookInformation SelectedBookInformation
        {
            get
            {
                if (this._selectedBookInformation != null && this._selectedBookInformation.ContentEdited)
                    this._selectedBookInformation.Reset();
                return this._selectedBookInformation;
            }
            set
            {
                this._selectedBookInformation = value;
                SelectedBookChanged();
            }
        }

        public string SelectedBookName 
        {
            get
            {
                
                return this.SelectedBookInformation != null ? this.SelectedBookInformation.BookName : STRING_EMPTY_VALUE;
            }
        }

        public string SelectedBookFormatInformation
        {
            get
            {
                return this.SelectedBookInformation != null ? this.SelectedBookInformation.BookFormatInformation : STRING_EMPTY_VALUE;
            }
        }

        public int SelectedBookQuantity
        {
            get
            {
                const int NULL_VALUE = -1;
                return this.SelectedBookInformation != null ? this.SelectedBookInformation.BookQuantity : NULL_VALUE;
            }
        }

        public string SelectedBookQuantityString
        {
            get
            {
                return "剩餘數量 : " + (this.SelectedBookQuantity >= 0 ? this.SelectedBookQuantity.ToString() : STRING_EMPTY_VALUE);
            }
        }

        public Library Model 
        {
            get
            {
                return _model;
            }
        }

        // handle _modelChanged evnet
        private void SelectedBookChanged()
        {
            if (this._selectedBookChanged != null)
            {
                this._selectedBookChanged.Invoke();
                NotifyPropertyChanged();
            }
        }

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
