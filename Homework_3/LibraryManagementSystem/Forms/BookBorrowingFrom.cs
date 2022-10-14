﻿using System;
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
    public partial class BookBorrowingFrom : System.Windows.Forms.Form
    {
        #region Attributes
        private BookBorrowingFormPresentationModel _presentationModel;
        private BackPackForm _backPackForm;
        #endregion

        #region Constrctor
        public BookBorrowingFrom(Library model)
        {
            InitializeComponent();
            this.FormClosing += this.BookBorrowingFormClosing;
            this._presentationModel = new BookBorrowingFormPresentationModel(model);
            this._presentationModel._showMessage += this.ShowMessage;
            this._backPackForm = new BackPackForm(model);
            this._backPackForm.FormClosing += this.BackPackFormClosing;
            this.CreateAllTabPage();
            this._bookInformationDataGridView.CellPainting += this.PatingDataGridView;
            this._bookInformationDataGridView.CellContentClick += this.ClickDataGridView1CellContent;
            this.BindData();
        }
        #endregion

        #region Private Function
        // 顯示訊息
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        // 生成所有 tabpage 
        private void CreateAllTabPage()
        {
            this._bookCategoryTabControl.TabPages.Clear();
            Dictionary<string, int> categoryQuantity = this._presentationModel.GetCategoryQuantityPair();
            int imageName = 1;
            foreach (var data in categoryQuantity)
            {
                string category = data.Key;
                int quantity = data.Value;
                TabPage tabPage = new TabPage(category);
                for (int index = 0; index < quantity; index++)
                    tabPage.Controls.Add(this.CreateTabPageButton(imageName++, index));
                this._bookCategoryTabControl.TabPages.Add(tabPage);
            }
        }

        // 創建 tabpagebuttons
        private Button CreateTabPageButton(int imageName, int categoryIndex)
        {
            const string BUTTON_IMAGE_PATH_FORMAT = "../../../image/{0}.jpg";
            string imageFileName = string.Format(BUTTON_IMAGE_PATH_FORMAT, imageName);
            Button button = new Button();
            button.Tag = categoryIndex;
            button.BackgroundImage = Image.FromFile(imageFileName);
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Location = this._presentationModel.GetButtonLocation(this._bookCategoryTabControl.Size.Width, categoryIndex);
            button.Size = this._presentationModel.GetButtonSize(this._bookCategoryTabControl.Size);
            button.Click += ClickTabPageButton;
            return button;
        }

        // 繪製刪除按鈕圖片
        private void PatingDataGridView(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const string TRASH_IMAGE_PATH = "../../../image/trash_can.png";
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                Image image = Image.FromFile(TRASH_IMAGE_PATH);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawImage(image, this._presentationModel.GetDeleteButtonRectangle(image, e.CellBounds));
                e.Handled = true;
            }
        }

        // 更新按鈕是否可見
        private void UpdateButtonVisible()
        {
            int index = 0;
            List<bool> buttonVisibleList = this._presentationModel.GetButtonVisibleList();
            foreach (object button in this._bookCategoryTabControl.SelectedTab.Controls)
                ((Button)button).Visible = buttonVisibleList[index++];
        }

        // data binding
        private void BindData()
        {
            const string BIND_ATTRIBUTE_ENABLED = "Enabled";
            const string BIND_ATTRIBUTE_TEXT = "Text";
            this._addBookButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsAddBookButtonEnabled");
            this._confirmBorrowingButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsConfirmBorrowingButtonEnabled");
            this._nextPageButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsNextButtonButtonEnabled");
            this._lastPageButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsLastButtonButtonEnabled");
            this._backPackButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsBackPackButtonEnabled");
            this._pageLabel.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel, "PageLabelString");
            this._bookIntroductionRichTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel, "SelectedBookInformation");
            this._remainingBookQuantityLabel.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel, "SelectedBookQuantityString");
            this._borrowingBookQuantityLabel.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel, "BorrowingListQuantityString");
            this._bookInformationDataGridView.DataSource = this._presentationModel.BorrowingList;
        }

        // 更新所有 View
        private void UpdateView()
        {
            this.UpdateButtonVisible();
        }
        #endregion

        #region Form Event
        // 第一次載入 Form
        private void BookBorrowingFromLoad(object sender, EventArgs e)
        {
            this._presentationModel.BookBorrowingFromLoad();
            this.UpdateView();
        }

        // 點擊書籍按鈕
        private void ClickTabPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickTabPageButton(this._bookCategoryTabControl.SelectedTab.Text, ((Button)sender).Tag);
            this.UpdateView();
        }

        // 點擊加入借書單
        private void ClickAddBookButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickAddBookButton();
            this.UpdateView();
        }

        // 切換 Tabpage
        private void BookCategoryTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            this._presentationModel.BookCategoryTabControlSelectedIndexChanged(this._bookCategoryTabControl.SelectedIndex);
            this.UpdateView();
        }

        // 點擊確認借書
        private void ClickConfirmBorrowingButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickConfirmBorrowingButton();
            this.UpdateView();
        }

        // 點擊我的書包
        private void ClickBackPackButton(object sender, EventArgs e)
        {
            this._backPackForm.Show();
            this._presentationModel.ClickBackPackButton();
            this.UpdateView();
        }
        
        // 點擊下一頁按鈕
        private void ClickNextPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickNextPageButton();
            this.UpdateView();
        }

        // 點擊上一頁按鈕
        private void ClickLastPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickLastPageButton();
            this.UpdateView();
        }

        // 點擊借書單的刪除按鈕
        private void ClickDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            // ((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                this._presentationModel.ClickDataGridView1CellContent(((DataGridView)sender).Rows[e.RowIndex].Tag);
                this.UpdateView();
            }
        }

        // 關閉我的書包視窗
        private void BackPackFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
            this._presentationModel.BackPackFormClosing();
            this.UpdateView();
        }

        // 關閉借書視窗
        private void BookBorrowingFormClosing(object sender, FormClosingEventArgs e)
        {
            this._presentationModel.BookBorrowingFromClosing();
            // 改變 SelectedIndex 會觸發 tabpage 切換事件 (this.BookCategoryTabControlSelectedIndexChanged) (值未改變不會觸發)
            this._bookCategoryTabControl.SelectedIndex = this._presentationModel.GetSelectTabPageIndex();
            this.UpdateView();
        }
        #endregion
    }
}
