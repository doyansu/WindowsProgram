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

        #region Constrctor
        public BookBorrowingFrom(BookBorrowingFormPresentationModel presentationModel)
        {
            InitializeComponent();
            this._presentationModel = presentationModel;
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
            foreach (var data in categoryQuantity)
            {
                string category = data.Key;
                int quantity = data.Value;
                TabPage tabPage = new TabPage(category);

                for (int index = 0; index < quantity; index++)
                    tabPage.Controls.Add(this.CreateTabPageButton(index));
                this._bookCategoryTabControl.TabPages.Add(tabPage);
            }
        }

        // 創建 tabpagebuttons
        private Button CreateTabPageButton(int buttonIndex)
        {
            const string BUTTON_NAME = "book";
            string buttonName = BUTTON_NAME + buttonIndex;
            const int BUTTON_OFFSET = 87;
            const int BUTTON_OFFSET_HEIGHT = 0;
            const int BUTTON_WIDTH = 85;
            const int BUTTON_HEIGHT = 120;

            Button button = new Button();
            button.Text = buttonName;
            button.Tag = buttonIndex;
            button.Location = new Point(BUTTON_OFFSET * buttonIndex, BUTTON_OFFSET_HEIGHT);
            button.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            button.Click += ClickTabPageButton;
            return button;
        }

        // 更新書籍資訊
        private void UpdateBookInformation()
        {
            this._bookIntroductionRichTextBox.Text = this._presentationModel.GetSelectedBookInformation();
            this._remainingBookQuantityLabel.Text = this._presentationModel.GetSelectedBookQuantityString();
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

        // 更新所有 View
        private void UpdateView()
        {
            this.UpdateBookInformation();
            this.UpdateBorrowingList();
        }

        // 更新所有 Controls Enable
        private void UpdateControls()
        {
            this._addBookButton.Enabled = this._presentationModel.IsAddBookButtonEnabled();
            this._confirmBorrowingButton.Enabled = this._presentationModel.IsConfirmBorrowingButtonEnabled();
        }
        #endregion

        #region Event
        // Form Load initialization
        private void BookBorrowingFromLoad(object sender, EventArgs e)
        {
            // now do nothing
        }

        // 點擊書籍按鈕
        private void ClickTabPageButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickTabPageButton(this._bookCategoryTabControl.SelectedTab.Text, ((Button)sender).Tag);
            this.UpdateBookInformation();
            this.UpdateControls();
        }

        // 點擊加入借書單
        private void ClickAddBookButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickAddBookButton();
            this.UpdateView();
            this.UpdateControls();
        }

        // 切換 Tabpage
        private void BookCategoryTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            this._presentationModel.BookCategoryTabControlSelectedIndexChanged();
            this.UpdateBookInformation();
            this.UpdateControls();
        }

        // 點擊確認借書
        private void ClickConfirmBorrowingButton(object sender, EventArgs e)
        {
            this._presentationModel.ClickConfirmBorrowingButton();
            this.UpdateView();
            this.UpdateControls();
            const string MESSAGE = "借書功能尚未實作";
            MessageBox.Show(MESSAGE);
        }
        #endregion
    }
}
