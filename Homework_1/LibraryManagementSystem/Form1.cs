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

        public BookBorrowingFrom(Library model)
        {
            InitializeComponent();
            this._model = model;
            this._model._updateView += this.UpdateBookInformation;
            this._model._updateView += this.UpdateAddBookButtonEnable;
        }

        #region Private Function
        // span all tabpage 
        private void SpanAllTabPage()
        {
            Dictionary<string, int> tabPageData = this._model.GetTabPageData();
            foreach (KeyValuePair<string, int> data in tabPageData)
            {
                TabPage tabPage = new TabPage(data.Key);

                for (int id = 0; id < data.Value; id++)
                    tabPage.Controls.Add(this.CreateTabPageButton(id));
                this._bookCategoryTabControl.TabPages.Add(tabPage);
            }
        }

        // create tabpagebutton
        private Button CreateTabPageButton(int buttonID)
        {
            const string BUTTON_NAME = "book";
            string buttonName = BUTTON_NAME + buttonID;
            const int BUTTON_OFFSET = 87;
            const int BUTTON_WIDTH = 85;
            const int BUTTON_HEIGHT = 120;

            Button button = new Button();
            button.Text = buttonName;
            button.Tag = buttonID;
            button.Location = new Point(BUTTON_OFFSET * buttonID, 0);
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

        // Update AddBookButton Enable
        private void UpdateAddBookButtonEnable()
        {
            this._addBookButton.Enabled = this._model.IsSelectedBookItemLeft();
        }
        #endregion

        #region Event
        // Form Load initialization
        private void BookBorrowingFromLoad(object sender, EventArgs e)
        {
            // load data
            this._model.LoadBookData();
            // add tabpages
            this.SpanAllTabPage();
        }

        // tabpage button onClick
        private void ClickTabPageButton(object sender, EventArgs e)
        {
            this._model.ClickTabPageButton(this._bookCategoryTabControl.SelectedTab.Text, ((Button)sender).Tag);
        }

        // AddBookButtonClick
        private void ClickAddBookButton(object sender, EventArgs e)
        {
            this._model.JoinBorrowingList();
            this._bookInformationDataGridView.Rows.Add(this._model.GetSelectedBookInformationArray());
            this._borrowingBookQuantityLabel.Text = this._model.GetBorrowingListQuantityString();
        }

        // BookCategoryTabControl SelectedIndex is Changed
        private void BookCategoryTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            this._model.BookCategoryTabControlSelectedIndexChanged();
        }
        #endregion
    }
}
