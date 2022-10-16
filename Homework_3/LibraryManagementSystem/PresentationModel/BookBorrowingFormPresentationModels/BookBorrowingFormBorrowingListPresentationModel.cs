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
        public event Action<string, string> _showMessage;
        #endregion

        private Library _model;
        private BindingList<BorrowingListRow> _borrowingList = new BindingList<BorrowingListRow>();

        #region Const
        const int BORROWING_LIMIT_QUANTITY = 2;
        const int BORROWING_LIST_LIMIT = 5;

        const string NOTIFY_BORROWING_LIST_QUANTITY_TEXT = "BorrowingListQuantityString";
        private readonly string[] _notifyList = { 
            "IsAddBookButtonEnabled",
            "IsConfirmBorrowingButtonEnabled",
            NOTIFY_BORROWING_LIST_QUANTITY_TEXT };

        #region Message Title
        private const string TITLE_BORROWING_DETAIL = "借書細節";
        private const string TITLE_BORROWING_VIOLATION = "借書違規";
        private const string TITLE_INVENTORY_STATUS = "庫存狀態";
        #endregion
        #endregion

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
            const string BORROWING_LIST_IS_FULL = "每次借書限借五本，您的借書單已滿";
            if (this._borrowingList.Count < BORROWING_LIST_LIMIT)
                this._model.AddSelectedBookItemToBorrowingList();
            else
                this.ShowMessage(BORROWING_LIST_IS_FULL, TITLE_BORROWING_VIOLATION);
        }

        // 點擊借書單的刪除按鈕
        public void ClickDataGridView1CellContent(int rowIndex)
        {
            this._model.ReturnBorrowingListItem(rowIndex);
        }

        // 點擊確認借書
        public void ClickConfirmBorrowingButton()
        {
            const string STRING_FORMAT_MESSAGE = "[{0}] {1}本{2}\n\n已成功借出!";
            const string STRING_FORMAT_BOOK = " 、 [{0}] {1}本";
            List<List<string>> informationList = this._model.GetBorrowingListInformationList();
            string books = "";
            for (int i = 1; i < informationList.Count; i++)
                books += string.Format(STRING_FORMAT_BOOK, informationList[i][0], informationList[i][1]);
            this.ShowMessage(string.Format(STRING_FORMAT_MESSAGE, informationList[0][0], informationList[0][1], books), TITLE_BORROWING_DETAIL);
            this._model.BorrowBooks();
        }

        // 數量儲存格編輯完成
        public void EditCellEnd(int rowIndex, int changeValue)
        {
            this._model.ChangeBorrowingItemQuantity(rowIndex, changeValue);
            const string EXCEED_LIMIT_QUANTITY_MESSAGE_FORMAT = "同一本書一次限借{0}本";
            const string EXCEED_BOOK_QUANTITY_MESSAGE = "該書本剩餘數量不足";
            Func<int, int> getChangeValue = (quantity) => quantity < BORROWING_LIMIT_QUANTITY ? quantity : BORROWING_LIMIT_QUANTITY;
            int bookQuantity = this._model.GetBookItemQuantity(this._borrowingList[rowIndex].BookName);
            int maxValue = getChangeValue(bookQuantity);
            if (changeValue > BORROWING_LIMIT_QUANTITY)
            {
                this.ShowMessage(string.Format(EXCEED_LIMIT_QUANTITY_MESSAGE_FORMAT, BORROWING_LIMIT_QUANTITY), TITLE_BORROWING_VIOLATION);
                changeValue = maxValue;
            }
            else if (changeValue > bookQuantity)
            {
                this.ShowMessage(EXCEED_BOOK_QUANTITY_MESSAGE, TITLE_INVENTORY_STATUS);
                changeValue = maxValue;
            }
            this._model.ChangeBorrowingItemQuantity(rowIndex, changeValue);
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

        public string BorrowingListQuantityString
        {
            get
            {
                const string TITLE = "借書數量 : ";
                int quantity = 0;
                foreach (BorrowingListRow row in this._borrowingList)
                    quantity += row.BorrowingCount;
                return TITLE + quantity;
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
        private void ShowMessage(string message, string title = "")
        {
            if (this._showMessage != null && message != null)
                this._showMessage.Invoke(message, title);
        }
        #endregion
    }
}
