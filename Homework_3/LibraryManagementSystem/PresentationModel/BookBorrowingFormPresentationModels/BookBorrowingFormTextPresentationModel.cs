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
        private Library _model;
        private readonly string[] _notifyList = { 
            "SelectedBookInformation",
            "SelectedBookQuantityString", };
        #endregion

        public BookBorrowingFormTextPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.NotifyPropertyChanged;
        }

        #region Property
        public string SelectedBookInformation
        {
            get
            {
                return _model.GetSelectedBookItemInformation();
            }
        }

        public string SelectedBookQuantityString
        {
            get
            {
                const string QUANTITY_TEXT = "剩餘數量 : ";
                return QUANTITY_TEXT + this._model.GetSelectedBookItemQuantityString();
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
