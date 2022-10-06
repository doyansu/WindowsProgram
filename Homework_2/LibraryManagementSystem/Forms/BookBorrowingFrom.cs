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
        private BookBorrowingFormPresentationModel _presentationModel;
        private BackPackForm _backPackForm;

        #region Constrctor
        public BookBorrowingFrom(BookBorrowingFormPresentationModel presentationModel, BackPackForm backPackForm)
        {
            InitializeComponent();
            this._presentationModel = presentationModel;
            this._backPackForm = backPackForm;
            this.CreateAllTabPage();
            this.UpdateControls();
        }
        #endregion

        #region Private Function
        // 生成所有 tabpage 
        private void CreateAllTabPage()
        {
            this._bookCategoryTabControl.TabPages.Clear();
            Dictionary<string, int> categoryQuantity = this._presentationModel.GetCategoryQuantityPair();
            int totalIndex = 1;

            foreach (var data in categoryQuantity)
            {
                string category = data.Key;
                int quantity = data.Value;
                TabPage tabPage = new TabPage(category);

                for (int index = 0; index < quantity; index++)
                    tabPage.Controls.Add(this.CreateTabPageButton(totalIndex++, index));
                this._bookCategoryTabControl.TabPages.Add(tabPage);
            }
        }

        // 創建 tabpagebuttons
        private Button CreateTabPageButton(int totalIndex, int categoryIndex)
        {
            string imageFileName = string.Format("../../../image/{0}.jpg", totalIndex);

            Button button = new Button();
            button.Tag = categoryIndex;
            button.Image = Image.FromFile(imageFileName);
            button.Location = this._presentationModel.GetButtonLocation(this._bookCategoryTabControl.Size.Width, categoryIndex);
            button.Size = this._presentationModel.GetButtonSize(this._bookCategoryTabControl.Size);
            button.ImageAlign = ContentAlignment.MiddleRight;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.FlatStyle = FlatStyle.Flat;
            button.Click += ClickTabPageButton;
            return button;
        }

        // 更新借書單
        private void UpdateBorrowingList()
        {
            this._bookInformationDataGridView.Rows.Clear();
            List<string[]> borrowingList = this._presentationModel.GetBorrowingListInformationList();
            foreach (string[] row in borrowingList)
                this._bookInformationDataGridView.Rows.Add(row);
            this._borrowingBookQuantityLabel.Text = this._presentationModel.GetBorrowingListQuantityString();
        }

        // 更新按鈕是否可見
        private void UpdateButtonVisible()
        {
            int index = 0;
            List<bool> buttonVisibleList = this._presentationModel.GetButtonVisibleList(this._bookCategoryTabControl.SelectedIndex);
            foreach (object button in this._bookCategoryTabControl.SelectedTab.Controls)
                ((Button)button).Visible = buttonVisibleList[index++];
        }

        // 更新所有 Controls Enable
        private void UpdateControls()
        {
            this._addBookButton.Enabled = this._presentationModel.IsAddBookButtonEnabled();
            this._confirmBorrowingButton.Enabled = this._presentationModel.IsConfirmBorrowingButtonEnabled();
            this._nextPageButton.Enabled = this._presentationModel.IsNextButtonButtonEnabled();
            this._lastPageButton.Enabled = this._presentationModel.IsLastButtonButtonEnabled();
            this._pageLabel.Text = this._presentationModel.GetPageLabelString();
            this._bookIntroductionRichTextBox.Text = this._presentationModel.GetSelectedBookInformation();
            this._remainingBookQuantityLabel.Text = this._presentationModel.GetSelectedBookQuantityString();
        }

        // 更新所有 View
        private void UpdateView()
        {
            this.UpdateControls();
            this.UpdateBorrowingList();
            this.UpdateButtonVisible();
        }
        #endregion

        #region Event
        // 載入 Form
        private void BookBorrowingFromLoad(object sender, EventArgs e)
        {
            this.UpdateView();
        }

        // 點擊書籍按鈕
        private void ClickTabPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickTabPageButton(this._bookCategoryTabControl.SelectedTab.Text, ((Button)sender).Tag);
            this.UpdateControls();
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
            this.UpdateControls();
            this.UpdateButtonVisible();
        }

        // 點擊確認借書
        private void ClickConfirmBorrowingButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickConfirmBorrowingButton();
            this.UpdateView();
            const string MESSAGE = "借書功能尚未實作";
            MessageBox.Show(MESSAGE);
        }

        // 點擊我的書包
        private void ClickBackPackButton(object sender, EventArgs e)
        {
            this._backPackForm.ShowDialog();
        }
        
        // 點擊下一頁按鈕
        private void ClickNextPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickNextPageButton();
            this.UpdateControls();
            this.UpdateButtonVisible();
        }

        // 點擊上一頁按鈕
        private void ClickLastPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickLastPageButton();
            this.UpdateControls();
            this.UpdateButtonVisible();
        }
        #endregion
    }
}
