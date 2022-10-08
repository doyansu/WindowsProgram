using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.PresentationModel;

namespace LibraryManagementSystem
{
    public partial class MenuForm : Form
    {
        private BookBorrowingFrom _bookBorrowingFrom;
        private BookInventoryForm _bookInventoryForm;
        private MenuFormPresentationModel _menuFormPresentationModel;

        #region Constructor
        public MenuForm(MenuFormPresentationModel menuFormPresentationModel, BookBorrowingFrom bookBorrowingFrom, BookInventoryForm bookInventoryForm)
        {
            InitializeComponent();
            this._menuFormPresentationModel = menuFormPresentationModel;
            this._bookBorrowingFrom = bookBorrowingFrom;
            this._bookBorrowingFrom.FormClosing += BookBorrowingFormClosing;
            this._bookInventoryForm = bookInventoryForm;
            this._bookInventoryForm.FormClosing += BookInventoryFormClosing;
        }
        #endregion

        #region Private Function
        // 更新按鈕啟用狀態
        private void UpdateControls()
        {
            this._bookBorrowingSystemButton.Enabled = this._menuFormPresentationModel.IsBorrowingEnabled();
            this._bookInventorySystemButton.Enabled = this._menuFormPresentationModel.IsInventoryEnabled();
        }
        #endregion

        #region Form Event
        // 點擊按鈕離開圖書館系統
        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        // 顯示借書視窗
        private void BookBorrowingSystemButtonClick(object sender, EventArgs e)
        {
            this._bookBorrowingFrom.Show();
            this._menuFormPresentationModel.ShowBorrowingForm();
            this.UpdateControls();
        }

        // 顯示庫存視窗
        private void BookInventorySystemButtonClick(object sender, EventArgs e)
        {
            this._bookInventoryForm.Show();
            this._menuFormPresentationModel.ShowInventoryForm();
            this.UpdateControls();
        }

        // 關閉 BorrowingForm
        private void BookBorrowingFormClosing(object sender, FormClosingEventArgs e)
        {
            // 關閉視窗時取消
            e.Cancel = true;
            // 隱藏式窗，下次再show出
            ((Form)sender).Hide();
            this._menuFormPresentationModel.CloseBorrowingForm();
            this.UpdateControls();
        }

        // 關閉 InventoryForm
        private void BookInventoryFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
            this._menuFormPresentationModel.CloseInventoryForm();
            this.UpdateControls();
        }
        #endregion
    }
}
