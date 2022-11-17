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
    public partial class BookAddingForm : Form
    {
        BookAddingFormPresentationModel _presentationModel;

        public BookAddingForm(Library model)
        {
            InitializeComponent();
            this._presentationModel = new BookAddingFormPresentationModel(model);
            this._addingQuantityTextBox.KeyPress += this.KeyPressTextBox;
            this.BindData();
        }

        // binding data
        private void BindData()
        {
            const string BIND_ATTRIBUTE_TEXT = "Text";
            this._addingBookInformationRichTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel, "BookInformation");
        }

        // SetBookInformation
        public void SetBookInformation(string bookInformation)
        {
            this._presentationModel.BookInformation = bookInformation;
        }

        // 取得補貨數量
        public int GetAddingQuantity()
        {
            return this._presentationModel.AddingQuantity;
        }

        #region Form Event
        // 輸入文字
        private void KeyPressTextBox(object sender, KeyPressEventArgs e)
        {
            const int BACK_SPACE_KEY_CHAR = 8;
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != BACK_SPACE_KEY_CHAR)
                e.Handled = true;
        }

        // TextBox Text 改變
        private void ChangeAddingQuantityTextBoxText(object sender, EventArgs e)
        {
            this._presentationModel.SetAddingQuantity(this._addingQuantityTextBox.Text);
        }

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
