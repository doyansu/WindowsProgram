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
            this._presentationModel._showMessage += ShowMessage;
            this._backPackForm = backPackForm;
            this.CreateAllTabPage();
            this.InitializeDataGridView();
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

        // 初始化 DataGridView 物件
        private void InitializeDataGridView()
        {
            const string DELETE = "刪除";
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = DELETE;
            deleteColumn.UseColumnTextForButtonValue = true;
            this._bookInformationDataGridView.Columns.Insert(0, deleteColumn);
            this._bookInformationDataGridView.CellPainting += PatingDataGridView;
            this._bookInformationDataGridView.CellContentClick += ClickDataGridView1CellContent;
        }

        // 繪製刪除按鈕圖片
        private void PatingDataGridView(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) 
                return;
            if (e.ColumnIndex == 0)
            {
                Image image = Image.FromFile("../../../image/trash_can.png");
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawImage(image, this._presentationModel.GetDeleteButtonRectangle(image, e.CellBounds));
                e.Handled = true;
            }
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
            this.UpdateButtonVisible();
            this.UpdateControls();
            this.UpdateBorrowingList();
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

        // 點擊借書單的刪除按鈕
        private void ClickDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                this._presentationModel.ClickDataGridView1CellContent(e.RowIndex);
                this.UpdateBorrowingList();
                this.UpdateControls();
            }
        }
        #endregion
    }
}
