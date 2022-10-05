using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BookBorrowingFormPresentationModel
    {
        private Library _model;
        private bool _isAddBookButtonEnabled = false;
        private bool _isConfirmBorrowingButtonEnabled = false;

        #region Constructor
        public BookBorrowingFormPresentationModel(Library model)
        {
            this._model = model;
        }
        #endregion

        #region View Process
        // 點擊書籍按鈕
        public void ClickTabPageButton(string category, object tag)
        {
            this._model.SelectBookItem(category, int.Parse(tag.ToString()));
            this.UpdateAddBookButtonEnabled();
        }

        // 點擊加入借書單
        public void ClickAddBookButton()
        {
            this._model.JoinSelectedBookItemToBorrowingList();
            this.UpdateConfirmBorrowingButtonEnabled();
            this.UpdateAddBookButtonEnabled();
        }

        // 切換 Tabpage
        public void BookCategoryTabControlSelectedIndexChanged()
        {
            this._model.UnselectedBookItem();
            this.UpdateAddBookButtonEnabled();
        }

        // 點擊確認借書
        public void ClickConfirmBorrowingButton()
        {
            this._model.BorrowBooks();
            this.UpdateConfirmBorrowingButtonEnabled();
            this.UpdateAddBookButtonEnabled();
        }
        #endregion

        #region Private Function
        // 更新 AddBookButtonEnabled
        private void UpdateAddBookButtonEnabled()
        {
            this._isAddBookButtonEnabled = this._model.GetSelectedBookQuantity() > 0;
        }

        // 更新 ConfirmBorrowingButtonEnabled
        private void UpdateConfirmBorrowingButtonEnabled()
        {
            this._isConfirmBorrowingButtonEnabled = this._model.GetBorrowedListCount() > 0;
        }
        #endregion

        #region Output
        // 取得每類書籍對映的數量鍵值對 (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetCategoryQuantityPair()
        {
            return this._model.GetCategoryQuantityPair();
        }

        // 取得所選書籍的書籍資訊
        public string GetSelectedBookInformation()
        {
            return this._model.GetSelectedBookInformation();
        }

        // 取得所選書籍的剩餘數量字串
        public string GetSelectedBookQuantityString()
        {
            const string QUANTITY_TEXT = "剩餘數量 : ";
            return QUANTITY_TEXT + this._model.GetSelectedBookQuantityString();
        }

        // 取得借書數量字串
        public string GetBorrowingListQuantityString()
        {
            const string TITLE = "借書數量 : ";
            return TITLE + this._model.GetBorrowingListQuantity();
        }

        // 取得借書單的資料陣列
        public List<string[]> GetBorrowingListInformationList()
        {
            return this._model.GetBorrowingListInformationList();
        }

        // get selectedBookItem state
        public bool IsAddBookButtonEnabled()
        {
            return this._isAddBookButtonEnabled;
        }

        // get ConfirmBorrowingButton state
        public bool IsConfirmBorrowingButtonEnabled()
        {
            return this._isConfirmBorrowingButtonEnabled;
        }
        #endregion
    }
}
