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
        private bool _isManagementEnabled = true;

        #region Const Attributes
        const string NOTIFY_BORROWING_ENABLED = "IsBorrowingEnabled";
        const string NOTIFY_INVENTORY_ENABLED = "IsInventoryEnabled";
        const string NOTIFY_MANAGEMENT_ENABLED = "IsManagementEnabled";
        private readonly string[] _notifyList = { 
            NOTIFY_BORROWING_ENABLED,
            NOTIFY_INVENTORY_ENABLED,
            NOTIFY_MANAGEMENT_ENABLED };
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

        // 顯示 Inventory Form
        public void ShowManagementForm()
        {
            this.IsManagementEnabled = false;
        }

        // 關閉 Inventory Form
        public void CloseManagementForm()
        {
            this.IsManagementEnabled = true;
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

        public bool IsManagementEnabled 
        {
            get
            {
                return this._isManagementEnabled;
            }
            set
            {
                this._isManagementEnabled = value;
                this.NotifyPropertyChanged(NOTIFY_MANAGEMENT_ENABLED);
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
