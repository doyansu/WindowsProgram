﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LibraryManagementSystem.PresentationModel.BindingListObject;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    public class BookBorrowingFormButtonPresentationModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private Library _model;
        private BookBorrowingFormPresentationModel _presentationModel;
        private TabPageButton _selectedButton = null;
        private List<List<TabPageButton>> _bookButtonList = new List<List<TabPageButton>>();
        private int _buttonPageIndex = 0;
        private int _selectedTabPageIndex = 0;
        private bool _isBackPackButtonEnabled = true;

        #region Const Attributes
        // 每頁書籍按鈕數
        private const int BUTTONS_PER_PAGE = 3;
        // 所有需要通知的 databing 屬性
        const string NOTIFY_BACK_PACK_BUTTON_ENABLED = "IsBackPackButtonEnabled";
        const string NOTIFY_SELECTED_INDEX_CHANGED = "SelectedTabPageIndex";
        private readonly string[] _notifyList = { 
            "IsNextButtonButtonEnabled",
            "IsLastButtonButtonEnabled",
            "PageLabelString",
            NOTIFY_SELECTED_INDEX_CHANGED,
            NOTIFY_BACK_PACK_BUTTON_ENABLED, };
        #endregion
        #endregion

        public BookBorrowingFormButtonPresentationModel(BookBorrowingFormPresentationModel presentationModel)
        {
            this._model = presentationModel.Model;
            this._presentationModel = presentationModel;
        }

        #region Form Event
        // UpdateBookButtonList
        public void UpdateBookButtonList()
        {
            this._bookButtonList.Clear();
            foreach (var data in this._model.GetCategoryBookInformationPair())
            {
                string category = data.Key;
                var bookInformationList = data.Value;
                List<TabPageButton> newList = new List<TabPageButton>();
                foreach (var bookInformation in bookInformationList)
                    newList.Add(new TabPageButton(bookInformation));
                this._bookButtonList.Add(newList);
            }
            this.SelectedTabPageIndex = 0;
            this.ButtonPageIndex = 0;
            this.UpdateButtonsVisible();
            this.NotifyPropertyChanged();
        }

        // SetButtonIndex
        public void SelectBookButton(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && rowIndex < this._bookButtonList.Count && columnIndex >= 0 && columnIndex < this._bookButtonList[rowIndex].Count)
                this._selectedButton = this._bookButtonList[rowIndex][columnIndex];
        }

        // SelectBook
        public void SelectBook(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && rowIndex < this._bookButtonList.Count && columnIndex >= 0 && columnIndex < this._bookButtonList[rowIndex].Count)
                this._presentationModel.SelectedBookInformation = this._bookButtonList[rowIndex][columnIndex].BookInformationObject;
        }

        // 切換 Tabpage
        public void BookCategoryTabControlSelectedIndexChanged(int index)
        {
            this.SelectedTabPageIndex = index;
            this.ButtonPageIndex = 0;
            //this._presentationModel.UnselectBook();
        }

        // 點擊下一頁按鈕
        public void ClickNextPageButton()
        {
            this.ButtonPageIndex++;
            //this._presentationModel.UnselectBook();
        }

        // 點擊上一頁按鈕
        public void ClickLastPageButton()
        {
            this.ButtonPageIndex--;
            //this._presentationModel.UnselectBook();
        }

        // 點擊我的書包
        public void ClickBackPackButton()
        {
            this.IsBackPackButtonEnabled = false;
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
            if (this.SelectedTabPageIndex >= 0 && this.SelectedTabPageIndex < this._bookButtonList.Count)
            {
                foreach (TabPageButton tabPageButtonVisible in this._bookButtonList[this.SelectedTabPageIndex])
                    tabPageButtonVisible.IsVisible = false;
                int start = this.ButtonPageIndex * BUTTONS_PER_PAGE;
                for (int i = start; i < start + BUTTONS_PER_PAGE && i < this._bookButtonList[this.SelectedTabPageIndex].Count; i++)
                    this._bookButtonList[this.SelectedTabPageIndex][i].IsVisible = true;
            }
        }

        // 取得當前頁面最大的 page index
        private int GetMaxTabPageIndex()
        {
            return (this.SelectedTabPageIndex >= 0 && this.SelectedTabPageIndex < this._bookButtonList.Count) ? (this._bookButtonList[this.SelectedTabPageIndex].Count - 1) / BUTTONS_PER_PAGE : 0;
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
                    this._selectedTabPageIndex = (value >= 0 && value < this._bookButtonList.Count) ? value : 0;
                    this.UpdateButtonsVisible();
                    this.NotifyPropertyChanged();
                }
            }
        }

        private int ButtonPageIndex 
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

        public TabPageButton BookButtonObject
        {
            get
            {
                return this._selectedButton;
            }
        }

        public string BookButtonImage
        {
            get
            {
                return this._selectedButton != null ? this._selectedButton.BookImagePath : null;
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