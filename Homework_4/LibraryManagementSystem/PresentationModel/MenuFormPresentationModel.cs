using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class MenuFormPresentationModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private bool _isBorrowingEnabled = true;
        private bool _isInventoryEnabled = true;

        #region Const Attributes
        private readonly string[] _notifyList = { 
            "IsBorrowingEnabled",
            "IsInventoryEnabled", };
        const string NOTIFY_BORROWING_ENABLED = "IsBorrowingEnabled";
        const string NOTIFY_INVENTORY_ENABLED = "IsInventoryEnabled";
        #endregion
        #endregion

        #region Constructor
        public MenuFormPresentationModel()
        {

        }
        #endregion

        #region View Process
        // 顯示 Borrowing Form
        public void ShowBorrowingForm()
        {
            this.IsBorrowingEnabled = false;
        }

        // 關閉 Borrowing Form
        public void CloseBorrowingForm()
        {
            this.IsBorrowingEnabled = true;
        }

        // 顯示 Inventory Form
        public void ShowInventoryForm()
        {
            this.IsInventoryEnabled = false;
        }

        // 關閉 Inventory Form
        public void CloseInventoryForm()
        {
            this.IsInventoryEnabled = true;
        }
        #endregion

        #region Setter Getter
        // Borrowing button 的啟用狀態
        public bool IsBorrowingEnabled
        {
            get
            {
                return this._isBorrowingEnabled;
            }
            set
            {
                this._isBorrowingEnabled = value;
                this.NotifyPropertyChanged(NOTIFY_BORROWING_ENABLED);
            }
        }

        // Inventory button 的啟用狀態
        public bool IsInventoryEnabled
        {
            get
            {
                return this._isInventoryEnabled;
            }
            set 
            {
                this._isInventoryEnabled = value;
                this.NotifyPropertyChanged(NOTIFY_INVENTORY_ENABLED);
            }
        }
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
        #endregion
    }
}
