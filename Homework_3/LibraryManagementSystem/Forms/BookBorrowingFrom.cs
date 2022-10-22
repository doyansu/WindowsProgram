using LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels;
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
    public partial class BookBorrowingFrom : System.Windows.Forms.Form
    {

        #region PresentationModel
        private Library _model;
        private BookBorrowingFormPresentationModel _presentationModel;
        private BookBorrowingFormButtonPresentationModel _buttonPresentationModel;
        private BookBorrowingFormTextPresentationModel _textPresentationModel;
        private BookBorrowingFormBorrowingListPresentationModel _borrowingListPresentationModel;
        private BookBorrowingFormControlPresentationModel _controlPresentationModel = new BookBorrowingFormControlPresentationModel();
        #endregion

        private BackPackForm _backPackForm;
       
        public BookBorrowingFrom(Library model)
        {
            InitializeComponent();
            this.FormClosing += this.BookBorrowingFormClosing;
            this._model = model;
            this._presentationModel = new BookBorrowingFormPresentationModel(model);
            this._buttonPresentationModel = new BookBorrowingFormButtonPresentationModel(this._presentationModel);
            this._borrowingListPresentationModel = new BookBorrowingFormBorrowingListPresentationModel(model, this._presentationModel);
            this._textPresentationModel = new BookBorrowingFormTextPresentationModel(this._presentationModel);
            this._borrowingListPresentationModel._showMessage += this.ShowMessage;
            this._backPackForm = new BackPackForm(model);
            this._backPackForm.FormClosing += this.BackPackFormClosing;
            this.CreateAllTabPage();
            this._bookInformationDataGridView.CellPainting += this.PatingDataGridView;
            this._bookInformationDataGridView.CellValueChanged += this.ChangeCellValue;
            this._bookInformationDataGridView.EditingControlShowing += this.EditingControlShowing;
            this.BindData();
        }

        #region Private Function
        // 顯示訊息
        private void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title);
        }

        // 生成所有 tabpage 
        private void CreateAllTabPage()
        {
            this._controlPresentationModel.SetButtonSize(this._bookCategoryTabControl.Size.Width, this._bookCategoryTabControl.Size.Height);
            this._bookCategoryTabControl.TabPages.Clear();
            Dictionary<string, int> categoryQuantity = this._model.GetCategoryQuantityPair();
            int imageName = 1;
            foreach (var data in categoryQuantity)
            {
                string category = data.Key;
                int quantity = data.Value;
                TabPage tabPage = new TabPage(category);
                this._bookCategoryTabControl.TabPages.Add(tabPage);
                this._bookCategoryTabControl.SelectTab(tabPage);
                for (int index = 0; index < quantity; index++)
                    tabPage.Controls.Add(this.CreateTabPageButton(imageName++, index));
            }
            this._bookCategoryTabControl.SelectTab(0);
        }

        // 創建 tabpagebuttons
        private Button CreateTabPageButton(int imageName, int categoryIndex)
        {
            const string BUTTON_IMAGE_PATH_FORMAT = "../../../image/{0}.jpg";
            string imageFileName = string.Format(BUTTON_IMAGE_PATH_FORMAT, imageName);
            this._controlPresentationModel.ButtonIndex = categoryIndex;
            Button button = new Button();
            button.Tag = categoryIndex;
            button.Click += ClickTabPageButton;
            button.DataBindings.Add("Visible", this._buttonPresentationModel.CreateButtonBindingObject(), "IsVisible");
            button.BackgroundImage = Image.FromFile(imageFileName);
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Location = new Point(this._controlPresentationModel.GetButtonLocation(), 0);
            button.Size = new Size(this._controlPresentationModel.ButtonWidth, this._controlPresentationModel.ButtonHeight);
            return button;
        }

        // 繪製刪除按鈕圖片
        private void PatingDataGridView(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const string TRASH_IMAGE_PATH = "../../../image/trash_can.png";
            if (e.ColumnIndex == this._deleteButtonColumn.Index && e.RowIndex >= 0)
            {
                Image image = Image.FromFile(TRASH_IMAGE_PATH);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                this._controlPresentationModel.SetDeleteButtonSize(image.Width, image.Height);
                this._controlPresentationModel.SetCell(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width, e.CellBounds.Height);
                e.Graphics.DrawImage(image, new Rectangle(this._controlPresentationModel.DeleteButtonLocationLeft, this._controlPresentationModel.DeleteButtonLocationTop, this._controlPresentationModel.DeleteButtonWidth, this._controlPresentationModel.DeleteButtonHeight));
                e.Handled = true;
            }
        }

        // data binding
        private void BindData()
        {
            const string BIND_ATTRIBUTE_ENABLED = "Enabled";
            const string BIND_ATTRIBUTE_TEXT = "Text";
            const string BIND_ATTRIBUTE_SELECTED_INDEX = "SelectedIndex";
            this._addBookButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._borrowingListPresentationModel, "IsAddBookButtonEnabled");
            this._confirmBorrowingButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._borrowingListPresentationModel, "IsConfirmBorrowingButtonEnabled");
            this._nextPageButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._buttonPresentationModel, "IsNextButtonButtonEnabled");
            this._lastPageButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._buttonPresentationModel, "IsLastButtonButtonEnabled");
            this._backPackButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._buttonPresentationModel, "IsBackPackButtonEnabled");
            this._pageLabel.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._buttonPresentationModel, "PageLabelString");
            this._bookIntroductionRichTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._textPresentationModel, "SelectedBookInformation");
            this._remainingBookQuantityLabel.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._textPresentationModel, "SelectedBookQuantityString");
            this._borrowingBookQuantityLabel.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._borrowingListPresentationModel, "BorrowingListQuantityString");
            this._bookCategoryTabControl.DataBindings.Add(BIND_ATTRIBUTE_SELECTED_INDEX, this._buttonPresentationModel, "SelectedTabPageIndex");
            this._bookInformationDataGridView.DataSource = this._borrowingListPresentationModel.BorrowingList;
        }
        #endregion

        #region Form Event
        // 第一次載入 Form
        private void BookBorrowingFromLoad(object sender, EventArgs e)
        {
            // now do nothing
        }

        // 點擊書籍按鈕
        private void ClickTabPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickTabPageButton(this._bookCategoryTabControl.SelectedTab.Text, ((Button)sender).Tag);
        }

        // 點擊加入借書單
        private void ClickAddBookButton(object sender, EventArgs e)
        {
            this._borrowingListPresentationModel.ClickAddBookButton();
        }

        // 切換 Tabpage
        private void BookCategoryTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            this._buttonPresentationModel.BookCategoryTabControlSelectedIndexChanged(this._bookCategoryTabControl.SelectedIndex);
        }

        // 點擊確認借書
        private void ClickConfirmBorrowingButton(object sender, EventArgs e)
        {
            this._borrowingListPresentationModel.ClickConfirmBorrowingButton();
        }

        // 點擊我的書包
        private void ClickBackPackButton(object sender, EventArgs e)
        {
            this._backPackForm.Show();
            this._buttonPresentationModel.ClickBackPackButton();
        }
        
        // 點擊下一頁按鈕
        private void ClickNextPageButton(object sender, EventArgs e)
        {
            this._buttonPresentationModel.ClickNextPageButton();
        }

        // 點擊上一頁按鈕
        private void ClickLastPageButton(object sender, EventArgs e)
        {
            this._buttonPresentationModel.ClickLastPageButton();
        }

        // 點擊儲存格內容
        private void ClickDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {
            // 點擊借書單的刪除按鈕
            if (e.ColumnIndex == this._deleteButtonColumn.Index && e.RowIndex >= 0)
                this._borrowingListPresentationModel.ClickDataGridView1CellContent(e.RowIndex);
        }

        // 儲存格值改變
        private void ChangeCellValue(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this._borrowingCountDataGridViewTextBoxColumn.Index && e.RowIndex >= 0)
                this._borrowingListPresentationModel.ChangeCellValue(e.RowIndex, this._bookInformationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        // 編輯模式儲存格內容改變
        private void EditTextChanged(object sender, EventArgs e)
        {
            this._bookInformationDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 顯示儲存格編輯模式
        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= this.EditTextChanged;
            e.Control.TextChanged += this.EditTextChanged;
        }

        // 關閉我的書包視窗
        private void BackPackFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
            this._buttonPresentationModel.BackPackFormClosing();
        }

        // 關閉借書視窗
        private void BookBorrowingFormClosing(object sender, FormClosingEventArgs e)
        {
            this._buttonPresentationModel.BookBorrowingFromClosing();
        }
        #endregion
    }
}
