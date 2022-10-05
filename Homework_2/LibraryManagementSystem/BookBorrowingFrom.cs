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
        private Library _model;

        #region Constrctor
        public BookBorrowingFrom(Library model)
        {
            InitializeComponent();
            this._model = model;
            this.CreateAllTabPage();
            this.UpdateControls();
        }

        public BookBorrowingFrom(BookBorrowingFrom other)
        {
            InitializeComponent();
            this._model = other._model;
            this.CreateAllTabPage();
            this.UpdateControls();
        }
        #endregion

        #region Private Function
        // span all tabpage 
        private void CreateAllTabPage()
        {
            this._bookCategoryTabControl.TabPages.Clear();
            Dictionary<string, int> categoryQuantity = this._model.GetCategoryQuantityPair();
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

        // create tabpagebutton
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

        // update BookInfomation and remainingBookQuantity
        private void UpdateBookInformation()
        {
            this._bookIntroductionRichTextBox.Text = this._model.GetSelectedBookInformation();
            this._remainingBookQuantityLabel.Text = this._model.GetSelectedBookQuantityString();
        }

        // Update BorrowingList
        private void UpdateBorrowingList()
        {
            this._bookInformationDataGridView.Rows.Clear();
            List<string[]> borrowingList = this._model.GetBorrowingListInformationList();
            foreach (string[] row in borrowingList)
                this._bookInformationDataGridView.Rows.Add(row);
            this._borrowingBookQuantityLabel.Text = this._model.GetBorrowingListQuantityString();
        }

        // update all view
        private void UpdateView()
        {
            this.UpdateBookInformation();
            this.UpdateBorrowingList();
        }

        // Update all Controls Enable
        private void UpdateControls()
        {
            this._addBookButton.Enabled = this._model.IsAddBookButtonEnabled();
            this._confirmBorrowingButton.Enabled = this._model.IsConfirmBorrowingButtonEnabled();
        }
        #endregion

        #region Event
        // Form Load initialization
        private void BookBorrowingFromLoad(object sender, EventArgs e)
        {
            // now do nothing
        }

        // tabpage button Clicked
        private void ClickTabPageButton(object sender, EventArgs e)
        {
            this._model.SelectBookItem(this._bookCategoryTabControl.SelectedTab.Text, int.Parse(((Button)sender).Tag.ToString()));
            this.UpdateBookInformation();
            this.UpdateControls();
        }

        // AddBookButtonClick
        private void ClickAddBookButton(object sender, EventArgs e)
        {
            this._model.JoinSelectedBookItemToBorrowingList();
            this.UpdateView();
            this.UpdateControls();
        }

        // BookCategoryTabControl SelectedIndex is Changed
        private void BookCategoryTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            this._model.UnselectedBookItem();
            this.UpdateBookInformation();
            this.UpdateControls();
        }

        // ConfirmBorrowingButton Click
        private void ClickConfirmBorrowingButton(object sender, EventArgs e)
        {
            this._model.BorrowBooks();
            this.UpdateView();
            this.UpdateControls();
            const string MESSAGE = "借書功能尚未實作";
            MessageBox.Show(MESSAGE);
        }
        #endregion
    }
}
