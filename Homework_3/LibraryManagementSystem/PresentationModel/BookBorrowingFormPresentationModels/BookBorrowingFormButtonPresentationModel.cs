using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LibraryManagementSystem.PresentationModel.BindingListObject;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    public class BookBorrowingFormButtonPresentationModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private BookBorrowingFormPresentationModel _presentationModel;
        private List<List<TabPageButtonVisible>> _bookButtonVisibles = new List<List<TabPageButtonVisible>>();
        private int _buttonPageIndex = 0;
        private int _selectedTabPageIndex = 0;
        private bool _isBackPackButtonEnabled = true;
        private int _createButtonIndex = 0;

        #region Const Attributes
        // 每頁書籍按鈕數
        private const int BUTTONS_PER_PAGE = 3;
        // 所有需要通知的 databing 屬性
        const string NOTIFY_BACK_PACK_BUTTON_ENABLED = "IsBackPackButtonEnabled";
        const string NOTIFY_SELECTED_INDEX_CHANGED = "SelectedTabPageIndex";
        private readonly string[] _notifyList = { 
            "IsNextButtonButtonEnabled",
            "IsLastButtonButtonEnabled",
            "PageLabelString", };
        #endregion
        #endregion

        public BookBorrowingFormButtonPresentationModel(BookBorrowingFormPresentationModel presentationModel)
        {
            this._presentationModel = presentationModel;
            this._presentationModel._selectedBookNameChanged += this.NotifyPropertyChanged;
        }

        #region View Process
        // 切換 Tabpage
        public void BookCategoryTabControlSelectedIndexChanged(int index)
        {
            this.SelectedTabPageIndex = index;
            this.ButtonPageIndex = 0;
            this._presentationModel.UnselectBook();
        }

        // 點擊下一頁按鈕
        public void ClickNextPageButton()
        {
            this.ButtonPageIndex++;
            this._presentationModel.UnselectBook();
        }

        // 點擊上一頁按鈕
        public void ClickLastPageButton()
        {
            this.ButtonPageIndex--; 
            this._presentationModel.UnselectBook();
        }

        // 點擊我的書包
        public void ClickBackPackButton()
        {
            this.IsBackPackButtonEnabled = false;
        }

        // 關閉借書視窗
        public void BookBorrowingFromClosing()
        {
            this.ButtonPageIndex = this.SelectedTabPageIndex = 0;
            this._presentationModel.UnselectBook();
        }

        // 關閉我的書包視窗
        public void BackPackFormClosing()
        {
            this.IsBackPackButtonEnabled = true;
        }
        #endregion

        #region Private Function
        // 更新 buttonVisible
        private void UpdateButtonsVisible()
        {
            if (this.SelectedTabPageIndex < this._bookButtonVisibles.Count)
            {
                foreach (TabPageButtonVisible tabPageButtonVisible in this._bookButtonVisibles[this.SelectedTabPageIndex])
                    tabPageButtonVisible.IsVisible = false;
                int start = this.ButtonPageIndex * BUTTONS_PER_PAGE;
                for (int i = start; i < start + BUTTONS_PER_PAGE && i < this._bookButtonVisibles[this.SelectedTabPageIndex].Count; i++)
                    this._bookButtonVisibles[this.SelectedTabPageIndex][i].IsVisible = true;
            }
        }

        // 取得當前頁面最大的 page index
        private int GetMaxTabPageIndex()
        {
            return (this._bookButtonVisibles[this.SelectedTabPageIndex].Count + BUTTONS_PER_PAGE - 1) / BUTTONS_PER_PAGE - 1;
        }
        #endregion

        #region Output
        // 創建按鈕 binding 物件
        public TabPageButtonVisible CreateButtonBindingObject()
        {
            if (this.SelectedTabPageIndex >= this._bookButtonVisibles.Count)
            {
                this._bookButtonVisibles.Add(new List<TabPageButtonVisible>());
                this._createButtonIndex = 0;
            }
            this._bookButtonVisibles[this.SelectedTabPageIndex].Add(new TabPageButtonVisible());
            return this._bookButtonVisibles[this.SelectedTabPageIndex][this._createButtonIndex++];
        }

        #endregion

        #region Property
        public string PageLabelString
        {
            get
            {
                return string.Format("Page : {0} / {1}", this.ButtonPageIndex + 1, this.GetMaxTabPageIndex() + 1);
            }
        }

        public bool IsNextButtonButtonEnabled
        {
            get
            {
                return this.ButtonPageIndex < this.GetMaxTabPageIndex();
            }
        }

        public bool IsLastButtonButtonEnabled
        {
            get
            {
                return this.ButtonPageIndex > 0;
            }
        }

        public bool IsBackPackButtonEnabled
        {
            get
            {
                return this._isBackPackButtonEnabled;
            }
            set
            {
                if (this._isBackPackButtonEnabled != value)
                {
                    this._isBackPackButtonEnabled = value;
                    this.NotifyPropertyChanged(NOTIFY_BACK_PACK_BUTTON_ENABLED);
                }
            }
        }

        public int SelectedTabPageIndex
        {
            get
            {
                return this._selectedTabPageIndex;
            }
            set
            {
                if (this._selectedTabPageIndex != value)
                {
                    this._selectedTabPageIndex = value;
                    this.UpdateButtonsVisible();
                    this.NotifyPropertyChanged(NOTIFY_SELECTED_INDEX_CHANGED);
                }
            }
        }

        public int ButtonPageIndex 
        {
            get
            {
                return this._buttonPageIndex;
            }
            set
            {
                if (this._buttonPageIndex != value)
                {
                    this._buttonPageIndex = value;
                    this.UpdateButtonsVisible();
                    this.NotifyPropertyChanged();
                }
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
        #endregion
    }
}