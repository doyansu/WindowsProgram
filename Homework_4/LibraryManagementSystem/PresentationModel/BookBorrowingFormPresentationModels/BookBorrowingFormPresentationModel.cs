using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    public class BookBorrowingFormPresentationModel
    {
        #region Event
        public event Action _selectedBookNameChanged;
        #endregion

        private Library _model;

        private string _selectedBookName = null;

        public BookBorrowingFormPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.SelectedBookNameChanged;
        }

        // 取消選擇書籍
        public void UnselectBook()
        {
            this.SelectedBookName = null;
        }

        #region Form Event
        // 點擊書籍按鈕
        public void ClickTabPageButton(string category, object buttonTag)
        {
            this._model.SelectBook(category, int.Parse(buttonTag.ToString()));
            this.SelectedBookName = this._model.GetSelectedBookName();
        }
        #endregion

        #region Output
        // 取得所選書籍的書籍名稱
        public string GetSelectedBookName()
        {
            this._model.SelectBook(this._selectedBookName);
            return this._model.GetSelectedBookName();
        }

        // 取得所選書籍的書籍資訊
        public string GetSelectedBookInformation()
        {
            this._model.SelectBook(this._selectedBookName);
            return this._model.GetSelectedBookInformation();
        }

        // 取得所選書籍的剩餘數量
        public int GetSelectedBookQuantity()
        {
            this._model.SelectBook(this._selectedBookName);
            return this._model.GetSelectedBookQuantity();
        }

        // 取得所選書籍的剩餘數量字串
        public string GetSelectedBookQuantityString()
        {
            this._model.SelectBook(this._selectedBookName);
            return this._model.GetSelectedBookQuantityString();
        }
        #endregion

        public string SelectedBookName 
        {
            get
            {
                return this._selectedBookName;
            }
            set
            {
                if (this._selectedBookName != value)
                {
                    this._selectedBookName = value;
                    this.SelectedBookNameChanged();
                }
            }
        }

        #region Event Invoke Function
        // handle _modelChanged evnet
        private void SelectedBookNameChanged()
        {
            if (this._selectedBookNameChanged != null)
                this._selectedBookNameChanged.Invoke();
        }
        #endregion
    }
}
