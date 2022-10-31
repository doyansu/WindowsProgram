using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    class BookBorrowingFormTextPresentationModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private BookBorrowingFormPresentationModel _presentationModel;
        private readonly string[] _notifyList = { 
            "SelectedBookInformation",
            "SelectedBookQuantityString", };
        #endregion

        public BookBorrowingFormTextPresentationModel(BookBorrowingFormPresentationModel presentationModel)
        {
            this._presentationModel = presentationModel;
            this._presentationModel._selectedBookNameChanged += this.NotifyPropertyChanged;
        }

        #region Property
        public string SelectedBookInformation
        {
            get
            {
                return this._presentationModel.GetSelectedBookInformation();
            }
        }

        public string SelectedBookQuantityString
        {
            get
            {
                return "剩餘數量 : " + this._presentationModel.GetSelectedBookQuantityString();
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
