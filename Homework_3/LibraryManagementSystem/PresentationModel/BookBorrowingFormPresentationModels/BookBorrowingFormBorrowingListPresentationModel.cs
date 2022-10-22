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
        const string NOTIFY_BORROWING_LIST_QUANTITY_TEXT = "BorrowingListQuantityString";
        private readonly string[] _notifyList = { 
            "IsAddBookButtonEnabled",
            "IsConfirmBorrowingButtonEnabled",
            NOTIFY_BORROWING_LIST_QUANTITY_TEXT };

        const int BORROWING_LIST_QUANTITY_LIMIT = 5;
        const int BORROWING_BOOK_QUANTITY_LIMIT = 2;
        private const string MESSAGE_OVER_LIST_LIMIT = "每次借書限借五本，您的借書單已滿";
        #region Message Title
        private const string TITLE_BORROWING_RESULT = "借書結果";
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

        // 取得借書總數
        private int GetBookQuantityCount()
        {
            int quantity = 0;
            foreach (BorrowingListRow row in this._borrowingList)
                quantity += row.BorrowingCount;
            return quantity;
        }

        #region Form Event
        // 點擊加入借書單
        public void ClickAddBookButton()
        {
            if (this.GetBookQuantityCount() < BORROWING_LIST_QUANTITY_LIMIT)
                this._model.AddSelectedBookItemToBorrowingList();
            else
                this.ShowMessage(MESSAGE_OVER_LIST_LIMIT, TITLE_BORROWING_VIOLATION);
        }

        // 點擊借書單的刪除按鈕
        public void ClickDataGridView1CellContent(int rowIndex)
        {
            this._model.ReturnBorrowingListItem(rowIndex);
        }

        // 點擊確認借書
        public void ClickConfirmBorrowingButton()
        {
            string books = "";
            foreach (BorrowingListRow row in this._borrowingList)
                books += string.Format(" 、 [{0}] {1}本", row.BookName, row.BorrowingCount);
            this.ShowMessage(string.Format("{0}\n\n已成功借出!", books).Substring(3), TITLE_BORROWING_RESULT);
            this._model.BorrowBooks();
        }

        // 數量儲存格編輯完成
        public void ChangeCellValue(int rowIndex, object changeValueObject)
        {
            int bookQuantity = this._borrowingList[rowIndex].BookQuantity;
            if ((this._borrowingList[rowIndex].BorrowingCount = int.Parse(changeValueObject.ToString())) > bookQuantity)
            {
                this.ShowMessage("該書本剩餘數量不足", TITLE_INVENTORY_STATUS);
                this._borrowingList[rowIndex].BorrowingCount = bookQuantity;
            }
            if (this._borrowingList[rowIndex].BorrowingCount > BORROWING_BOOK_QUANTITY_LIMIT)
            {
                this.ShowMessage(string.Format("同一本書一次限借{0}本", BORROWING_BOOK_QUANTITY_LIMIT), TITLE_BORROWING_VIOLATION);
                this._borrowingList[rowIndex].BorrowingCount = BORROWING_BOOK_QUANTITY_LIMIT;
            }
            if (this.GetBookQuantityCount() > BORROWING_LIST_QUANTITY_LIMIT)
            {
                this.ShowMessage(MESSAGE_OVER_LIST_LIMIT, TITLE_BORROWING_VIOLATION);
                this._borrowingList[rowIndex].BorrowingCount = 1;
            }
            this._model.ChangeBorrowingItemQuantity(rowIndex, this._borrowingList[rowIndex].BorrowingCount);
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
                return this._model.GetSelectedBookItemQuantity() > 0 && this._borrowingList.SingleOrDefault(BookRow => BookRow.BookName == bookName) == null;
            }
        }

        public bool IsConfirmBorrowingButtonEnabled
        {
            get
            {
                return this._borrowingList.Count > 0;
            }
        }

        public string BorrowingListQuantityString
        {
            get
            {
                return "借書數量 : " + this.GetBookQuantityCount();
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
