using LibraryManagementSystem.PresentationModel.BindingListObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    class BookBorrowingFormBorrowingListPresentationModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<string> _showMessage;
        #endregion

        private Library _model;
        private BindingList<BorrowingListRow> _borrowingList = new BindingList<BorrowingListRow>();
        private readonly string[] _notifyList = { 
            "IsAddBookButtonEnabled",
            "IsConfirmBorrowingButtonEnabled" };

        public BookBorrowingFormBorrowingListPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.UpdateBorrowingList;
            this._model._modelChanged += this.NotifyPropertyChanged;
        }

        // 更新借書單的資料陣列
        public void UpdateBorrowingList()
        {
            List<List<string>> informationList = this._model.GetBorrowingListInformationList();
            this._borrowingList.Clear();
            foreach (List<string> stringList in informationList)
                this._borrowingList.Add(new BorrowingListRow(stringList));
        }

        #region Form Event
        // 點擊加入借書單
        public void ClickAddBookButton()
        {
            const int LIST_LIMIT = 5;
            const string BORROWING_LIST_IS_FULL = "每次借書限借五本，您的借書單已滿";
            if (this._borrowingList.Count < LIST_LIMIT)
                this._model.JoinSelectedBookItemToBorrowingList();
            else
                this.ShowMessage(BORROWING_LIST_IS_FULL);
        }

        // 點擊借書單的刪除按鈕
        public void ClickDataGridView1CellContent(int rowIndex)
        {
            this._model.ReturnBorrowingListItem(rowIndex);
        }

        // 點擊確認借書
        public void ClickConfirmBorrowingButton()
        {
            const string STRING_FORMAT_MESSAGE = "[{0}]{1}\n\n{2}本書已成功借出";
            const string STRING_FORMAT_BOOK = " 、 [{0}]";
            List<List<string>> informationList = this._model.GetBorrowingListInformationList();
            string books = "";
            for (int i = 1; i < informationList.Count; i++)
                books += string.Format(STRING_FORMAT_BOOK, informationList[i][0]);
            this.ShowMessage(string.Format(STRING_FORMAT_MESSAGE, informationList[0][0], books, informationList.Count));
            this._model.BorrowBooks();
        }
        #endregion

        #region Property
        public IBindingList BorrowingList
        {
            get
            {
                return this._borrowingList;
            }
        }

        public bool IsAddBookButtonEnabled
        {
            get
            {
                string bookName = this._model.GetSelectedBookItemName();
                return this._model.GetSelectedBookItemQuantity() > 0 && this._borrowingList.SingleOrDefault(BookItem => BookItem.BookName == bookName) == null;
            }
        }

        public bool IsConfirmBorrowingButtonEnabled
        {
            get
            {
                return this._model.GetBorrowedListCount() > 0;
            }
        }
        #endregion

        #region Event Invoke Function
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

        // 顯示 Message
        private void ShowMessage(string message)
        {
            if (this._showMessage != null && message != null)
                this._showMessage.Invoke(message);
        }
        #endregion
    }
}
