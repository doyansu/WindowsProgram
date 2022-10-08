using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class MenuFormPresentationModel
    {
        private bool _isBorrowingEnabled = true;
        private bool _isInventoryEnabled = true;

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
        }

        // 關閉 Borrowing Form
        public void CloseBorrowingForm()
        {
            _isBorrowingEnabled = true;
        }

        // 顯示 Inventory Form
        public void ShowInventoryForm()
        {
            _isInventoryEnabled = false;
        }

        // 關閉 Inventory Form
        public void CloseInventoryForm()
        {
            _isInventoryEnabled = true;
        }
        #endregion

        #region Output
        // Borrowing button 的啟用狀態
        public bool IsBorrowingEnabled()
        {
            return this._isBorrowingEnabled;
        }

        // Inventory button 的啟用狀態
        public bool IsInventoryEnabled()
        {
            return this._isInventoryEnabled;
        }
        #endregion

    }
}
