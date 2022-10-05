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
        // get tabpage data (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetCategoryQuantityPair()
        {
            return this._model.GetCategoryQuantityPair();
        }

        // get Selected Book's infomation
        public string GetSelectedBookInformation()
        {
            return this._model.GetSelectedBookInformation();
        }

        // get orrowingList's InformationArray
        public List<string[]> GetBorrowingListInformationList()
        {
            return this._model.GetBorrowingListInformationList();
        }

        // get Selected Book's Quantity String
        public string GetSelectedBookQuantityString()
        {
            const string QUANTITY_TEXT = "剩餘數量 : ";
            return QUANTITY_TEXT + this._model.GetSelectedBookQuantityString();
        }

        // get borrowingList Quantity string
        public string GetBorrowingListQuantityString()
        {
            const string TITLE = "借書數量 : ";
            return TITLE + this._model.GetBorrowingListQuantity();
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
