﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace LibraryManagementSystem.PresentationModel
{
    public class BookBorrowingFormPresentationModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<string> _showMessage;
        #endregion

        #region Attributes
        private Library _model;
        private List<List<bool>> _buttonVisibles;
        private int _buttonPageIndex = 0;
        private int _selectedTabPageIndex = 0;
        private bool _isBackPackButtonEnabled = true;

        #region Const Attributes
        // 每頁書籍按鈕數
        private const int BUTTONS_PER_PAGE = 3;
        // 所有需要的通知 databing 屬性
        private readonly string[] _notifyList = { 
            "IsAddBookButtonEnabled",
            "IsConfirmBorrowingButtonEnabled",
            "IsNextButtonButtonEnabled",
            "IsLastButtonButtonEnabled",
            "IsBackPackButtonEnabled",
            "PageLabelString",
            "SelectedBookInformation",
            "SelectedBookQuantityString",
            "BorrowingListQuantityString" };
        #endregion
        #endregion

        #region Constructor
        public BookBorrowingFormPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.NotifyPropertyChanged;
            this.InitializeButtonsVisible();
        }
        #endregion

        #region View Process
        // 第一次載入 Form
        public void BookBorrowingFromLoad()
        {
            this.NotifyPropertyChanged();
        }

        // 點擊書籍按鈕
        public void ClickTabPageButton(string category, object buttonTag)
        {
            this._model.SelectBookItem(category, int.Parse(buttonTag.ToString()));
        }

        // 點擊加入借書單
        public void ClickAddBookButton()
        {
            this.ShowMessage(this._model.JoinSelectedBookItemToBorrowingList());
        }

        // 點擊借書單的刪除按鈕
        public void ClickDataGridView1CellContent(object rowTag)
        {
            this._model.ReturnBorrowingListItem(int.Parse(rowTag.ToString()));
        }

        // 切換 Tabpage
        public void BookCategoryTabControlSelectedIndexChanged(int index)
        {
            this._selectedTabPageIndex = index;
            this._buttonPageIndex = 0;
            this.UpdateButtonsVisible();
            this._model.UnselectedBookItem();
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

        // 點擊下一頁按鈕
        public void ClickNextPageButton()
        {
            this._buttonPageIndex++;
            this.UpdateButtonsVisible();
            this._model.UnselectedBookItem();
        }

        // 點擊上一頁按鈕
        public void ClickLastPageButton()
        {
            this._buttonPageIndex--;
            this.UpdateButtonsVisible();
            this._model.UnselectedBookItem();
        }

        // 點擊我的書包
        public void ClickBackPackButton()
        {
            this._isBackPackButtonEnabled = false;
            this.NotifyPropertyChanged();
        }

        // 關閉借書視窗
        public void BookBorrowingFromClosing()
        {
            this._buttonPageIndex = this._selectedTabPageIndex = 0;
            this.UpdateButtonsVisible();
            this._model.ReturnAllBorrowingListItem();
            this._model.UnselectedBookItem();
        }

        // 關閉我的書包視窗
        public void BackPackFormClosing()
        {
            this._isBackPackButtonEnabled = true;
            this.NotifyPropertyChanged();
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
            this._buttonVisibles[this._selectedTabPageIndex] = this._buttonVisibles[this._selectedTabPageIndex].Select(content => false).ToList();
            int start = this._buttonPageIndex * BUTTONS_PER_PAGE;
            for (int i = start; i < start + BUTTONS_PER_PAGE && i < this._buttonVisibles[this._selectedTabPageIndex].Count; i++)
                this._buttonVisibles[this._selectedTabPageIndex][i] = true;
        }

        // 取得當前頁面最大的 page index
        private int GetMaxTabPageIndex()
        {
            return (this._buttonVisibles[this._selectedTabPageIndex].Count + BUTTONS_PER_PAGE - 1) / BUTTONS_PER_PAGE - 1;
        }
        #endregion

        #region Output
        // 取得每類書籍對映的數量鍵值對 (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetCategoryQuantityPair()
        {
            return this._model.GetCategoryQuantityPair();
        }

        // 取得所選書籍的書籍資訊
        public string SelectedBookInformation
        {
            get
            {
                return _model.GetSelectedBookInformation();
            }
        }

        // 取得所選書籍的剩餘數量字串
        public string SelectedBookQuantityString
        {
            get
            {
                const string QUANTITY_TEXT = "剩餘數量 : ";
                return QUANTITY_TEXT + this._model.GetSelectedBookQuantityString();
            }
        }

        // 取得借書數量字串
        public string BorrowingListQuantityString
        {
            get
            {
                const string TITLE = "借書數量 : ";
                return TITLE + this._model.GetBorrowingListQuantity();
            }
        }

        // 取得當前 page 標籤文字
        public string PageLabelString
        {
            get
            {
                const string PAGE_LABEL_STRING_FORMAT = "Page : {0} / {1}";
                return string.Format(PAGE_LABEL_STRING_FORMAT, this._buttonPageIndex + 1, this.GetMaxTabPageIndex() + 1);
            }
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

        // 取得按鈕可見陣列
        public List<bool> GetButtonVisibleList()
        {
            return this._buttonVisibles[this._selectedTabPageIndex];
        }

        // 取得所選 TabPage 的 index
        public int GetSelectTabPageIndex()
        {
            return this._selectedTabPageIndex;
        }

        // 取得 selectedBookItem Enabled
        public bool IsAddBookButtonEnabled
        {
            get
            {
                return this._model.IsSelectedBookCanBorrowed();
            }
        }

        // 取得 ConfirmBorrowingButton Enabled
        public bool IsConfirmBorrowingButtonEnabled
        {
            get
            {
                return this._model.GetBorrowedListCount() > 0;
            }
        }

        // 取得 NextButtonButton Enabled
        public bool IsNextButtonButtonEnabled
        {
            get
            {
                return this._buttonPageIndex < this.GetMaxTabPageIndex();
            }
        }

        // 取得 LastButtonButton Enabled
        public bool IsLastButtonButtonEnabled
        {
            get
            {
                return this._buttonPageIndex > 0;
            }
        }

        // 取得 BackPackButton Enabled
        public bool IsBackPackButtonEnabled
        {
            get
            {
                return this._isBackPackButtonEnabled;
            }
        }

        #region Button Style Process
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

        // 取得 delete 按鈕圖片 Rectangle
        public Rectangle GetDeleteButtonRectangle(Image image, Rectangle cellBounds)
        {
            int width = image.Width;
            int height = image.Height;
            return new Rectangle(cellBounds.Left + ((cellBounds.Width - width) >> 1), cellBounds.Top + ((cellBounds.Height - height) >> 1), width, height);
        }
        #endregion

        #endregion

        #region Event Invoke Function 
        // 通知所有 databing 改變
        private void NotifyPropertyChanged()
        {
            foreach (string dataBinding in _notifyList)
                NotifyPropertyChanged(dataBinding);
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