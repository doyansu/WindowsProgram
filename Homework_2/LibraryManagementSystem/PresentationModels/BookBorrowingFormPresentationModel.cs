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
        private bool _isAddBookButtonEnabled = true;
        private bool _isConfirmBorrowingButtonEnabled = true;

        #region Constructor
        public BookBorrowingFormPresentationModel(Library model)
        {
            this._model = model;
        }
        #endregion

        #region View Process
        // 點擊書籍按鈕
        public void ClickTabPageButton(string category, object Tag)
        {
            this._model.SelectBookItem(category, int.Parse(Tag.ToString()));
        }

        // 點擊加入借書單
        public void ClickAddBookButton()
        {
            this._model.JoinSelectedBookItemToBorrowingList();
        }

        // 切換 Tabpage
        public void BookCategoryTabControlSelectedIndexChanged()
        {
            this._model.UnselectedBookItem();
        }

        // 點擊確認借書
        public void ClickConfirmBorrowingButton()
        {
            this._model.BorrowBooks();
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
            return this._model.GetSelectedBookQuantityString();
        }

        // get borrowingList Quantity string
        public string GetBorrowingListQuantityString()
        {
            return this._model.GetBorrowingListQuantityString();
        }

        // get selectedBookItem state (this function have to move to Presentation Model)
        public bool IsAddBookButtonEnabled()
        {
            //return this._selectedBookItem != null && this._selectedBookItem.Quantity > 0;
            return this._isAddBookButtonEnabled;
        }

        // get ConfirmBorrowingButton state (this function have to move to Presentation Model)
        public bool IsConfirmBorrowingButtonEnabled()
        {
            return this._isConfirmBorrowingButtonEnabled;
            //return this._borrowingList.Count > 0;
        }
        #endregion
    }
}
