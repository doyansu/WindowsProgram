﻿using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel.BindingListObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class BookInventoryFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action _inventoryListChanged;

        private Library _model;
        private int _selectedRowIndex = -1;
        private BindingList<InventoryListRow> _inventoryList = new BindingList<InventoryListRow>();

        const string NOTIFY_BOOK_INFORMATION_CHANGED = "BookInformation";
        private readonly string[] _notifyList = { 
            NOTIFY_BOOK_INFORMATION_CHANGED };

        public BookInventoryFormPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.UpdateInventoryList;
            this._model._modelChanged += this.NotifyPropertyChanged;
            this.UpdateInventoryList();
        }

        // 更新庫存清單
        private void UpdateInventoryList()
        {
            List<BookInformation> informationList = this._model.GetBookItemsInformationList();
            /*for (int i = informationList.Count; i < this._inventoryList.Count; i++)
                this._inventoryList.RemoveAt(i);*/
            for (int i = 0; i < informationList.Count; i++)
                if (i < this._inventoryList.Count)
                    this._inventoryList[i] = new InventoryListRow(informationList[i]);
                else
                    this._inventoryList.Add(new InventoryListRow(informationList[i]));
            this.UseAction(_inventoryListChanged);
        }

        #region Form Event
        // 點擊補貨按鈕
        public void ClickAddingButton(int addingQuantity)
        {
            if (this.SelectedRowIndex >= 0 && this.SelectedRowIndex < this._inventoryList.Count)
                this._model.AddBookQuantity(this._inventoryList[this.SelectedRowIndex].BookName, addingQuantity);
        }
        #endregion

        #region Property
        public IBindingList InventoryList
        {
            get
            {
                return this._inventoryList;
            }
        }

        public int SelectedRowIndex
        {
            get
            {
                return this._selectedRowIndex;
            }
            set
            {
                if (this._selectedRowIndex != value)
                {
                    this._selectedRowIndex = value;
                    this.NotifyPropertyChanged(NOTIFY_BOOK_INFORMATION_CHANGED);
                    this.UseAction(_inventoryListChanged);
                }
            }
        }

        public string SelectedBookImage
        {
            get
            {
                return (this.SelectedRowIndex >= 0 && this.SelectedRowIndex < this._inventoryList.Count) ? this._inventoryList[this.SelectedRowIndex].BookImagePath : "";
            }
        }

        public string BookInformation
        {
            get
            {
                return (this.SelectedRowIndex >= 0 && this.SelectedRowIndex < this._inventoryList.Count) ? this._inventoryList[this.SelectedRowIndex].BookFormatInformation : "";
            }
        }

        public string BookItemInformation
        {
            get
            {
                const string INFORMATION_FORMAT = "書籍名稱 : {0}\n\n書籍類別 : {1}\n庫存數量 : {2}";
                InventoryListRow row = this._inventoryList[this.SelectedRowIndex];
                return string.Format(INFORMATION_FORMAT, row.BookName, row.BookCategory, row.BookQuantity);
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

        // 使用 action event
        private void UseAction(Action action)
        {
            if (action != null)
                action.Invoke();
        }
        #endregion
    }
}
