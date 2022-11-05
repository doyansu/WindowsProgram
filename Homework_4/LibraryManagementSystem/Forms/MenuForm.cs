using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MenuForm : Form
    {
        #region Attributes
        private Library _model;
        private BookBorrowingFrom _bookBorrowingFrom;
        private BookInventoryForm _bookInventoryForm;
        private BookManagementForm _bookManagementForm;
        private MenuFormPresentationModel _menuFormPresentationModel;
        #endregion

        #region Constructor
        public MenuForm(Library model)
        {
            InitializeComponent();
            this._model = model;
            this._menuFormPresentationModel = new MenuFormPresentationModel();
            this._bookBorrowingFrom = new BookBorrowingFrom(model);
            this._bookBorrowingFrom.FormClosing += BookBorrowingFormClosing;
            BindData();
        }
        #endregion

        #region Private Function
        // 更新按鈕啟用狀態
        private void BindData()
        {
            const string BIND_ATTRIBUTE_ENABLED = "Enabled";
            this._bookBorrowingSystemButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._menuFormPresentationModel, "IsBorrowingEnabled");
            this._bookInventorySystemButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._menuFormPresentationModel, "IsInventoryEnabled");
            this._bookManagementSystemButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._menuFormPresentationModel, "IsManagementEnabled");
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
        }

        // 顯示庫存視窗
        private void BookInventorySystemButtonClick(object sender, EventArgs e)
        {
            this._bookInventoryForm = new BookInventoryForm(this._model);
            this._bookInventoryForm.FormClosing += BookInventoryFormClosing;
            this._bookInventoryForm.Show(); 
            this._menuFormPresentationModel.ShowInventoryForm();
        }

        // 顯示管理視窗
        private void BookManagementSystemButtonClick(object sender, EventArgs e)
        {
            this._bookManagementForm = new BookManagementForm(this._model);
            this._bookManagementForm.FormClosing += BookManagementFormClosing;
            this._bookManagementForm.Show();
            this._menuFormPresentationModel.ShowManagementForm();
        }

        // 關閉 BorrowingForm
        private void BookBorrowingFormClosing(object sender, FormClosingEventArgs e)
        {
            // 關閉視窗時取消
            e.Cancel = true;
            // 隱藏式窗，下次再show出
            ((Form)sender).Hide();
            this._menuFormPresentationModel.CloseBorrowingForm();
        }

        // 關閉 InventoryForm
        private void BookInventoryFormClosing(object sender, FormClosingEventArgs e)
        {
            this._menuFormPresentationModel.CloseInventoryForm();
        }

        // 關閉 ManagementForm
        private void BookManagementFormClosing(object sender, FormClosingEventArgs e)
        {
            this._menuFormPresentationModel.CloseManagementForm();
        }
        #endregion
    }
}