using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LibraryManagementSystem
{
    public class BookBorrowingFormPresentationModel
    {
        #region Event
        public event Action<string> _showMessage;
        #endregion

        #region Const
        private const int BUTTONS_PER_PAGE = 3;
        #endregion

        private Library _model;
        private List<List<bool>> _buttonVisibles;
        private int _pageCount = 0;
        private int _tabPageIndex = 0;
        private bool _isAddBookButtonEnabled = false;

        #region Constructor
        public BookBorrowingFormPresentationModel(Library model)
        {
            this._model = model;
            this.InitializeButtonsVisible();
        }
        #endregion

        #region View Process
        // 點擊書籍按鈕
        public void ClickTabPageButton(string category, object tag)
        {
            this._model.SelectBookItem(category, int.Parse(tag.ToString()));
        }

        // 點擊加入借書單
        public void ClickAddBookButton()
        {
            this.ShowMessage(this._model.JoinSelectedBookItemToBorrowingList());
        }

        // 點擊借書單的刪除按鈕
        public void ClickDataGridView1CellContent(int rowIndex)
        {
            this._model.DeleteBorrowingListItem(rowIndex);
        }

        // 切換 Tabpage
        public void BookCategoryTabControlSelectedIndexChanged(int index)
        {
            this._model.UnselectedBookItem();
            this._tabPageIndex = index;
            this._pageCount = 0;
            this.UpdateButtonsVisible();
        }

        // 點擊確認借書
        public void ClickConfirmBorrowingButton()
        {
            this._model.BorrowBooks();
        }

        // 點擊下一頁按鈕
        public void ClickNextPageButton()
        {
            this._pageCount++;
            this._model.UnselectedBookItem();
            this.UpdateButtonsVisible();
        }

        // 點擊上一頁按鈕
        public void ClickLastPageButton()
        {
            this._pageCount--;
            this._model.UnselectedBookItem();
            this.UpdateButtonsVisible();
        }
        #endregion

        #region Private Function
        // 初始化 buttonVisible
        private void InitializeButtonsVisible()
        {
            this._buttonVisibles = new List<List<bool>>();
            foreach (var data in this._model.GetCategoryQuantityPair())
            {
                List<bool> boolList = new List<bool>();
                for (int i = 0; i < data.Value; i++)
                    boolList.Add(false);
                _buttonVisibles.Add(boolList);
            }
            this.UpdateButtonsVisible();
        }

        // 更新 buttonVisible
        private void UpdateButtonsVisible()
        {
            this._buttonVisibles[this._tabPageIndex] = this._buttonVisibles[this._tabPageIndex].Select(content => false).ToList();
            int start = this._pageCount * BUTTONS_PER_PAGE;
            for (int i = start; i < start + BUTTONS_PER_PAGE && i < this._buttonVisibles[this._tabPageIndex].Count; i++)
                this._buttonVisibles[this._tabPageIndex][i] = true;
        }

        // 取得當前頁面最大的 page index
        private int GetMaxTabPageIndex()
        {
            return (this._buttonVisibles[this._tabPageIndex].Count + BUTTONS_PER_PAGE - 1) / BUTTONS_PER_PAGE - 1;
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
            List<List<string>> informationList = this._model.GetBorrowingListInformationList();
            List<string[]> informationArray = new List<string[]>();
            const string BUTTON_VALUE = "";
            foreach (List<string> stringList in informationList)
            {
                stringList.Insert(0, BUTTON_VALUE);
                informationArray.Add(stringList.ToArray());
            }
            return informationArray;
        }

        // 取得當前 page 標籤文字
        public string GetPageLabelString()
        {
            const string PAGE = "Page : ";
            const string SLASH = " / ";
            return PAGE + (this._pageCount + 1) + SLASH + (this.GetMaxTabPageIndex() + 1);
        }

        // 取得 selectedBookItem Enabled
        public bool IsAddBookButtonEnabled()
        {
            return this._model.GetSelectedBookQuantity() > 0 && !this._model.IsBorrowingListContainsSelectedBook();
        }

        // 取得 ConfirmBorrowingButton Enabled
        public bool IsConfirmBorrowingButtonEnabled()
        {
            return this._model.GetBorrowedListCount() > 0;
        }

        // 取得 NextButtonButton Enabled
        public bool IsNextButtonButtonEnabled()
        {
            return this._pageCount < this.GetMaxTabPageIndex();
        }

        // 取得 LastButtonButton Enabled
        public bool IsLastButtonButtonEnabled()
        {
            return this._pageCount > 0;
        }

        #region Button Process
        // 取得 ButtonLocation
        public Point GetButtonLocation(int tabPageWidth, int buttonIndex)
        {
            return new Point((tabPageWidth / BUTTONS_PER_PAGE - BUTTONS_PER_PAGE) * (buttonIndex % BUTTONS_PER_PAGE), 0); 
        }

        // 取得 ButtonSize
        public Size GetButtonSize(Size tabPageSize)
        {
            const int BUTTON_HEIGHT_ZOOM = 5;
            return new Size(tabPageSize.Width / BUTTONS_PER_PAGE - BUTTONS_PER_PAGE, tabPageSize.Height * (BUTTON_HEIGHT_ZOOM - 1) / BUTTON_HEIGHT_ZOOM);
        }

        // 取得按鈕可見陣列
        public List<bool> GetButtonVisibleList(int tabPageIndex)
        {
            return this._buttonVisibles[tabPageIndex];
        }
        #endregion

        #endregion

        #region Event Handle Function
        // 顯示 Message
        private void ShowMessage(string message)
        {
            if (this._showMessage != null && message != null)
                this._showMessage.Invoke(message);
        }
        #endregion
    }
}
