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
            _isBorrowingEnabled = false;
            this.NotifyPropertyChanged();
        }

        // 關閉 Borrowing Form
        public void CloseBorrowingForm()
        {
            _isBorrowingEnabled = true;
            this.NotifyPropertyChanged();
        }

        // 顯示 Inventory Form
        public void ShowInventoryForm()
        {
            _isInventoryEnabled = false;
            this.NotifyPropertyChanged();
        }

        // 關閉 Inventory Form
        public void CloseInventoryForm()
        {
            _isInventoryEnabled = true;
            this.NotifyPropertyChanged();
        }
        #endregion

        #region Output
        // Borrowing button 的啟用狀態
        public bool IsBorrowingEnabled
        {
            get
            {
                return this._isBorrowingEnabled;
            }
        }

        // Inventory button 的啟用狀態
        public bool IsInventoryEnabled
        {
            get
            {
                return this._isInventoryEnabled;
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
