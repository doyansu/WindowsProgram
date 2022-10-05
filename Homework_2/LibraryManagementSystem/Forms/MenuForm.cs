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
        private BookBorrowingFrom _bookBorrowingFrom;
        private BookInventoryForm _bookInventoryForm;

        public MenuForm(BookBorrowingFrom bookBorrowingFrom, BookInventoryForm bookInventoryForm)
        {
            InitializeComponent();
            this._bookBorrowingFrom = bookBorrowingFrom;
            this._bookInventoryForm = bookInventoryForm;
        }

        #region Event
        // 點擊按鈕離開圖書館系統
        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // 顯示借書視窗
        private void BookBorrowingSystemButtonClick(object sender, EventArgs e)
        {
            new BookBorrowingFrom(this._bookBorrowingFrom).Show();
        }

        // 顯示庫存視窗
        private void BookInventorySystemButtonClick(object sender, EventArgs e)
        {
            new BookInventoryForm(this._bookInventoryForm).Show();
        }
        #endregion
    }
}
