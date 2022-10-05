
namespace LibraryManagementSystem
{
    partial class BookBorrowingFrom
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._bookInformationGroupBox = new System.Windows.Forms.GroupBox();
            this._bookCategoryTabControl = new System.Windows.Forms.TabControl();
            this._addBookButton = new System.Windows.Forms.Button();
            this._bookIntroductionGroupBox = new System.Windows.Forms.GroupBox();
            this._bookIntroductionRichTextBox = new System.Windows.Forms.RichTextBox();
            this._remainingBookQuantityLabel = new System.Windows.Forms.Label();
            this._borrowingBookQuantityLabel = new System.Windows.Forms.Label();
            this._borrowingListLabel = new System.Windows.Forms.Label();
            this._bookInformationDataGridView = new System.Windows.Forms.DataGridView();
            this._bookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookPublicationItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._confirmBorrowingButton = new System.Windows.Forms.Button();
            this._backPackButton = new System.Windows.Forms.Button();
            this._bookInformationGroupBox.SuspendLayout();
            this._bookIntroductionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._bookInformationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _bookInformationGroupBox
            // 
            this._bookInformationGroupBox.Controls.Add(this._bookCategoryTabControl);
            this._bookInformationGroupBox.Controls.Add(this._addBookButton);
            this._bookInformationGroupBox.Controls.Add(this._bookIntroductionGroupBox);
            this._bookInformationGroupBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookInformationGroupBox.Location = new System.Drawing.Point(12, 12);
            this._bookInformationGroupBox.Name = "_bookInformationGroupBox";
            this._bookInformationGroupBox.Size = new System.Drawing.Size(300, 440);
            this._bookInformationGroupBox.TabIndex = 0;
            this._bookInformationGroupBox.TabStop = false;
            this._bookInformationGroupBox.Text = "書籍";
            // 
            // _bookCategoryTabControl
            // 
            this._bookCategoryTabControl.Location = new System.Drawing.Point(16, 22);
            this._bookCategoryTabControl.Name = "_bookCategoryTabControl";
            this._bookCategoryTabControl.SelectedIndex = 0;
            this._bookCategoryTabControl.Size = new System.Drawing.Size(270, 150);
            this._bookCategoryTabControl.TabIndex = 2;
            this._bookCategoryTabControl.SelectedIndexChanged += new System.EventHandler(this.BookCategoryTabControlSelectedIndexChanged);
            // 
            // _addBookButton
            // 
            this._addBookButton.Enabled = false;
            this._addBookButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addBookButton.Location = new System.Drawing.Point(180, 395);
            this._addBookButton.Name = "_addBookButton";
            this._addBookButton.Size = new System.Drawing.Size(106, 32);
            this._addBookButton.TabIndex = 1;
            this._addBookButton.Text = "加入借書單";
            this._addBookButton.UseVisualStyleBackColor = true;
            this._addBookButton.Click += new System.EventHandler(this.ClickAddBookButton);
            // 
            // _bookIntroductionGroupBox
            // 
            this._bookIntroductionGroupBox.Controls.Add(this._bookIntroductionRichTextBox);
            this._bookIntroductionGroupBox.Controls.Add(this._remainingBookQuantityLabel);
            this._bookIntroductionGroupBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookIntroductionGroupBox.Location = new System.Drawing.Point(6, 196);
            this._bookIntroductionGroupBox.Name = "_bookIntroductionGroupBox";
            this._bookIntroductionGroupBox.Size = new System.Drawing.Size(280, 190);
            this._bookIntroductionGroupBox.TabIndex = 0;
            this._bookIntroductionGroupBox.TabStop = false;
            this._bookIntroductionGroupBox.Text = "書籍介紹";
            // 
            // _bookIntroductionRichTextBox
            // 
            this._bookIntroductionRichTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this._bookIntroductionRichTextBox.Location = new System.Drawing.Point(4, 22);
            this._bookIntroductionRichTextBox.Name = "_bookIntroductionRichTextBox";
            this._bookIntroductionRichTextBox.Size = new System.Drawing.Size(270, 130);
            this._bookIntroductionRichTextBox.TabIndex = 1;
            this._bookIntroductionRichTextBox.Text = "";
            // 
            // _remainingBookQuantityLabel
            // 
            this._remainingBookQuantityLabel.AutoSize = true;
            this._remainingBookQuantityLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._remainingBookQuantityLabel.Location = new System.Drawing.Point(0, 155);
            this._remainingBookQuantityLabel.Name = "_remainingBookQuantityLabel";
            this._remainingBookQuantityLabel.Size = new System.Drawing.Size(82, 21);
            this._remainingBookQuantityLabel.TabIndex = 0;
            this._remainingBookQuantityLabel.Text = "剩餘數量 :";
            // 
            // _borrowingBookQuantityLabel
            // 
            this._borrowingBookQuantityLabel.AutoSize = true;
            this._borrowingBookQuantityLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._borrowingBookQuantityLabel.Location = new System.Drawing.Point(316, 415);
            this._borrowingBookQuantityLabel.Name = "_borrowingBookQuantityLabel";
            this._borrowingBookQuantityLabel.Size = new System.Drawing.Size(96, 24);
            this._borrowingBookQuantityLabel.TabIndex = 1;
            this._borrowingBookQuantityLabel.Text = "借書數量 :";
            // 
            // _borrowingListLabel
            // 
            this._borrowingListLabel.AutoSize = true;
            this._borrowingListLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._borrowingListLabel.Location = new System.Drawing.Point(521, 12);
            this._borrowingListLabel.Name = "_borrowingListLabel";
            this._borrowingListLabel.Size = new System.Drawing.Size(75, 26);
            this._borrowingListLabel.TabIndex = 2;
            this._borrowingListLabel.Text = "借書單";
            // 
            // _bookInformationDataGridView
            // 
            this._bookInformationDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._bookInformationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._bookInformationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._bookName,
            this._bookNumber,
            this._bookAuthor,
            this._bookPublicationItem});
            this._bookInformationDataGridView.Location = new System.Drawing.Point(320, 50);
            this._bookInformationDataGridView.Name = "_bookInformationDataGridView";
            this._bookInformationDataGridView.ReadOnly = true;
            this._bookInformationDataGridView.RowHeadersVisible = false;
            this._bookInformationDataGridView.RowTemplate.Height = 24;
            this._bookInformationDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._bookInformationDataGridView.Size = new System.Drawing.Size(470, 350);
            this._bookInformationDataGridView.TabIndex = 3;
            // 
            // _bookName
            // 
            this._bookName.HeaderText = "書籍名稱";
            this._bookName.Name = "_bookName";
            this._bookName.ReadOnly = true;
            // 
            // _bookNumber
            // 
            this._bookNumber.HeaderText = "書籍編號";
            this._bookNumber.Name = "_bookNumber";
            this._bookNumber.ReadOnly = true;
            // 
            // _bookAuthor
            // 
            this._bookAuthor.HeaderText = "作者";
            this._bookAuthor.Name = "_bookAuthor";
            this._bookAuthor.ReadOnly = true;
            // 
            // _bookPublicationItem
            // 
            this._bookPublicationItem.HeaderText = "出版項";
            this._bookPublicationItem.Name = "_bookPublicationItem";
            this._bookPublicationItem.ReadOnly = true;
            // 
            // _confirmBorrowingButton
            // 
            this._confirmBorrowingButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._confirmBorrowingButton.Location = new System.Drawing.Point(695, 406);
            this._confirmBorrowingButton.Name = "_confirmBorrowingButton";
            this._confirmBorrowingButton.Size = new System.Drawing.Size(95, 35);
            this._confirmBorrowingButton.TabIndex = 4;
            this._confirmBorrowingButton.Text = "確認借書";
            this._confirmBorrowingButton.UseVisualStyleBackColor = true;
            this._confirmBorrowingButton.Click += new System.EventHandler(this.ClickConfirmBorrowingButton);
            // 
            // _backPackButton
            // 
            this._backPackButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._backPackButton.Location = new System.Drawing.Point(598, 407);
            this._backPackButton.Name = "_backPackButton";
            this._backPackButton.Size = new System.Drawing.Size(91, 35);
            this._backPackButton.TabIndex = 5;
            this._backPackButton.Text = "我的書包";
            this._backPackButton.UseVisualStyleBackColor = true;
            this._backPackButton.Click += new System.EventHandler(this.ClickBackPackButton);
            // 
            // BookBorrowingFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._backPackButton);
            this.Controls.Add(this._confirmBorrowingButton);
            this.Controls.Add(this._bookInformationDataGridView);
            this.Controls.Add(this._borrowingListLabel);
            this.Controls.Add(this._borrowingBookQuantityLabel);
            this.Controls.Add(this._bookInformationGroupBox);
            this.Name = "BookBorrowingFrom";
            this.Text = "借書";
            this.Load += new System.EventHandler(this.BookBorrowingFromLoad);
            this._bookInformationGroupBox.ResumeLayout(false);
            this._bookIntroductionGroupBox.ResumeLayout(false);
            this._bookIntroductionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._bookInformationDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _bookInformationGroupBox;
        private System.Windows.Forms.GroupBox _bookIntroductionGroupBox;
        private System.Windows.Forms.Button _addBookButton;
        private System.Windows.Forms.Label _remainingBookQuantityLabel;
        private System.Windows.Forms.Label _borrowingBookQuantityLabel;
        private System.Windows.Forms.Label _borrowingListLabel;
        private System.Windows.Forms.DataGridView _bookInformationDataGridView;
        private System.Windows.Forms.Button _confirmBorrowingButton;
        private System.Windows.Forms.TabControl _bookCategoryTabControl;
        private System.Windows.Forms.RichTextBox _bookIntroductionRichTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookPublicationItem;
        private System.Windows.Forms.Button _backPackButton;
    }
}

