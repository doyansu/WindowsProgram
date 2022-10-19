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
    public partial class BookAddingForm : Form
    {
        BookAddingFormPresentationModel _presentationModel;

        public BookAddingForm(Library model)
        {
            InitializeComponent();
            this._presentationModel = new BookAddingFormPresentationModel(model);
        }

        // 取得補貨數量
        public int GetAddingQuantity()
        {
            return int.Parse(this._addingQuantityTextBox.Text);
        }

        #region Form Event
        // 點擊確認按鈕
        private void ClickConfirmButton(object sender, EventArgs e)
        {
            this.Close();
        }

        // 點擊取消按鈕
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
