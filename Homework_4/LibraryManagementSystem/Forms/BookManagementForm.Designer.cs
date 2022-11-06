
namespace LibraryManagementSystem
{
    partial class BookManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._bookManagementLabel = new System.Windows.Forms.Label();
            this._bookListBox = new System.Windows.Forms.ListBox();
            this._managementListRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._bookEditGroupBox = new System.Windows.Forms.GroupBox();
            this._bookCategoryComboBox = new System.Windows.Forms.ComboBox();
            this._managementCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._bookImagePathTextBox = new System.Windows.Forms.TextBox();
            this._bookAuthorTextBox = new System.Windows.Forms.TextBox();
            this._bookNumberTextBox = new System.Windows.Forms.TextBox();
            this._bookPublicationItemTextBox = new System.Windows.Forms.TextBox();
            this._bookNameTextBox = new System.Windows.Forms.TextBox();
            this._browseImageButton = new System.Windows.Forms.Button();
            this._bookNumberLabel = new System.Windows.Forms.Label();
            this._bookAuthorLabel = new System.Windows.Forms.Label();
            this._bookCategoryLabel = new System.Windows.Forms.Label();
            this._bookImagePathLabel = new System.Windows.Forms.Label();
            this._bookPublicationItemLabel = new System.Windows.Forms.Label();
            this._bookNameLabel = new System.Windows.Forms.Label();
            this._addBookButton = new System.Windows.Forms.Button();
            this._saveBookButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._managementListRowBindingSource)).BeginInit();
            this._bookEditGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._managementCategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _bookManagementLabel
            // 
            this._bookManagementLabel.AutoSize = true;
            this._bookManagementLabel.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookManagementLabel.Location = new System.Drawing.Point(426, 9);
            this._bookManagementLabel.Name = "_bookManagementLabel";
            this._bookManagementLabel.Size = new System.Drawing.Size(209, 40);
            this._bookManagementLabel.TabIndex = 0;
            this._bookManagementLabel.Text = "館藏管理系統";
            // 
            // _bookListBox
            // 
            this._bookListBox.DataSource = this._managementListRowBindingSource;
            this._bookListBox.DisplayMember = "SourceBookName";
            this._bookListBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookListBox.FormattingEnabled = true;
            this._bookListBox.ItemHeight = 20;
            this._bookListBox.Location = new System.Drawing.Point(12, 52);
            this._bookListBox.Name = "_bookListBox";
            this._bookListBox.Size = new System.Drawing.Size(415, 504);
            this._bookListBox.TabIndex = 1;
            this._bookListBox.ValueMember = "BookName";
            this._bookListBox.SelectedIndexChanged += new System.EventHandler(this.BookListBoxSelectedIndexChanged);
            // 
            // _managementListRowBindingSource
            // 
            this._managementListRowBindingSource.DataSource = typeof(LibraryManagementSystem.PresentationModel.BindingListObject.ManagementListRow);
            // 
            // _bookEditGroupBox
            // 
            this._bookEditGroupBox.Controls.Add(this._bookCategoryComboBox);
            this._bookEditGroupBox.Controls.Add(this._bookImagePathTextBox);
            this._bookEditGroupBox.Controls.Add(this._bookAuthorTextBox);
            this._bookEditGroupBox.Controls.Add(this._bookNumberTextBox);
            this._bookEditGroupBox.Controls.Add(this._bookPublicationItemTextBox);
            this._bookEditGroupBox.Controls.Add(this._bookNameTextBox);
            this._bookEditGroupBox.Controls.Add(this._browseImageButton);
            this._bookEditGroupBox.Controls.Add(this._bookNumberLabel);
            this._bookEditGroupBox.Controls.Add(this._bookAuthorLabel);
            this._bookEditGroupBox.Controls.Add(this._bookCategoryLabel);
            this._bookEditGroupBox.Controls.Add(this._bookImagePathLabel);
            this._bookEditGroupBox.Controls.Add(this._bookPublicationItemLabel);
            this._bookEditGroupBox.Controls.Add(this._bookNameLabel);
            this._bookEditGroupBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookEditGroupBox.Location = new System.Drawing.Point(433, 52);
            this._bookEditGroupBox.Name = "_bookEditGroupBox";
            this._bookEditGroupBox.Size = new System.Drawing.Size(619, 544);
            this._bookEditGroupBox.TabIndex = 2;
            this._bookEditGroupBox.TabStop = false;
            this._bookEditGroupBox.Text = "編輯書籍";
            // 
            // _bookCategoryComboBox
            // 
            this._bookCategoryComboBox.BackColor = System.Drawing.SystemColors.Window;
            this._bookCategoryComboBox.DataSource = this._managementCategoryBindingSource;
            this._bookCategoryComboBox.DisplayMember = "Category";
            this._bookCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._bookCategoryComboBox.FormattingEnabled = true;
            this._bookCategoryComboBox.Location = new System.Drawing.Point(114, 277);
            this._bookCategoryComboBox.Name = "_bookCategoryComboBox";
            this._bookCategoryComboBox.Size = new System.Drawing.Size(220, 29);
            this._bookCategoryComboBox.TabIndex = 11;
            this._bookCategoryComboBox.ValueMember = "Category";
            // 
            // _managementCategoryBindingSource
            // 
            this._managementCategoryBindingSource.DataSource = typeof(LibraryManagementSystem.PresentationModel.BindingListObject.ManagementCategory);
            // 
            // _bookImagePathTextBox
            // 
            this._bookImagePathTextBox.Location = new System.Drawing.Point(114, 437);
            this._bookImagePathTextBox.Name = "_bookImagePathTextBox";
            this._bookImagePathTextBox.Size = new System.Drawing.Size(356, 29);
            this._bookImagePathTextBox.TabIndex = 10;
            // 
            // _bookAuthorTextBox
            // 
            this._bookAuthorTextBox.Location = new System.Drawing.Point(114, 197);
            this._bookAuthorTextBox.Name = "_bookAuthorTextBox";
            this._bookAuthorTextBox.Size = new System.Drawing.Size(220, 29);
            this._bookAuthorTextBox.TabIndex = 9;
            // 
            // _bookNumberTextBox
            // 
            this._bookNumberTextBox.Location = new System.Drawing.Point(114, 117);
            this._bookNumberTextBox.Name = "_bookNumberTextBox";
            this._bookNumberTextBox.Size = new System.Drawing.Size(220, 29);
            this._bookNumberTextBox.TabIndex = 8;
            // 
            // _bookPublicationItemTextBox
            // 
            this._bookPublicationItemTextBox.Location = new System.Drawing.Point(114, 357);
            this._bookPublicationItemTextBox.Name = "_bookPublicationItemTextBox";
            this._bookPublicationItemTextBox.Size = new System.Drawing.Size(420, 29);
            this._bookPublicationItemTextBox.TabIndex = 7;
            // 
            // _bookNameTextBox
            // 
            this._bookNameTextBox.Location = new System.Drawing.Point(114, 37);
            this._bookNameTextBox.Name = "_bookNameTextBox";
            this._bookNameTextBox.Size = new System.Drawing.Size(420, 29);
            this._bookNameTextBox.TabIndex = 6;
            // 
            // _browseImageButton
            // 
            this._browseImageButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._browseImageButton.Location = new System.Drawing.Point(486, 433);
            this._browseImageButton.Name = "_browseImageButton";
            this._browseImageButton.Size = new System.Drawing.Size(110, 35);
            this._browseImageButton.TabIndex = 5;
            this._browseImageButton.Text = "瀏覽";
            this._browseImageButton.UseVisualStyleBackColor = true;
            this._browseImageButton.Click += new System.EventHandler(this.BrowseImageButtonClick);
            // 
            // _bookNumberLabel
            // 
            this._bookNumberLabel.AutoSize = true;
            this._bookNumberLabel.Location = new System.Drawing.Point(15, 120);
            this._bookNumberLabel.Name = "_bookNumberLabel";
            this._bookNumberLabel.Size = new System.Drawing.Size(93, 21);
            this._bookNumberLabel.TabIndex = 5;
            this._bookNumberLabel.Text = "書籍編號(*)";
            // 
            // _bookAuthorLabel
            // 
            this._bookAuthorLabel.AutoSize = true;
            this._bookAuthorLabel.Location = new System.Drawing.Point(15, 200);
            this._bookAuthorLabel.Name = "_bookAuthorLabel";
            this._bookAuthorLabel.Size = new System.Drawing.Size(93, 21);
            this._bookAuthorLabel.TabIndex = 4;
            this._bookAuthorLabel.Text = "書籍作者(*)";
            // 
            // _bookCategoryLabel
            // 
            this._bookCategoryLabel.AutoSize = true;
            this._bookCategoryLabel.Location = new System.Drawing.Point(15, 280);
            this._bookCategoryLabel.Name = "_bookCategoryLabel";
            this._bookCategoryLabel.Size = new System.Drawing.Size(93, 21);
            this._bookCategoryLabel.TabIndex = 3;
            this._bookCategoryLabel.Text = "書籍類別(*)";
            // 
            // _bookImagePathLabel
            // 
            this._bookImagePathLabel.AutoSize = true;
            this._bookImagePathLabel.Location = new System.Drawing.Point(15, 440);
            this._bookImagePathLabel.Name = "_bookImagePathLabel";
            this._bookImagePathLabel.Size = new System.Drawing.Size(93, 21);
            this._bookImagePathLabel.TabIndex = 2;
            this._bookImagePathLabel.Text = "圖片路徑(*)";
            // 
            // _bookPublicationItemLabel
            // 
            this._bookPublicationItemLabel.AutoSize = true;
            this._bookPublicationItemLabel.Location = new System.Drawing.Point(15, 360);
            this._bookPublicationItemLabel.Name = "_bookPublicationItemLabel";
            this._bookPublicationItemLabel.Size = new System.Drawing.Size(77, 21);
            this._bookPublicationItemLabel.TabIndex = 1;
            this._bookPublicationItemLabel.Text = "出版項(*)";
            // 
            // _bookNameLabel
            // 
            this._bookNameLabel.AutoSize = true;
            this._bookNameLabel.Location = new System.Drawing.Point(15, 40);
            this._bookNameLabel.Name = "_bookNameLabel";
            this._bookNameLabel.Size = new System.Drawing.Size(93, 21);
            this._bookNameLabel.TabIndex = 0;
            this._bookNameLabel.Text = "書籍名稱(*)";
            // 
            // _addBookButton
            // 
            this._addBookButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addBookButton.Location = new System.Drawing.Point(12, 619);
            this._addBookButton.Name = "_addBookButton";
            this._addBookButton.Size = new System.Drawing.Size(415, 50);
            this._addBookButton.TabIndex = 3;
            this._addBookButton.Text = "新增書籍";
            this._addBookButton.UseVisualStyleBackColor = true;
            this._addBookButton.Click += new System.EventHandler(this.AddBookButtonClick);
            // 
            // _saveBookButton
            // 
            this._saveBookButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._saveBookButton.Location = new System.Drawing.Point(771, 619);
            this._saveBookButton.Name = "_saveBookButton";
            this._saveBookButton.Size = new System.Drawing.Size(281, 50);
            this._saveBookButton.TabIndex = 4;
            this._saveBookButton.Text = "儲存";
            this._saveBookButton.UseVisualStyleBackColor = true;
            this._saveBookButton.Click += new System.EventHandler(this.SaveBookButtonClick);
            // 
            // BookManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this._saveBookButton);
            this.Controls.Add(this._addBookButton);
            this.Controls.Add(this._bookEditGroupBox);
            this.Controls.Add(this._bookListBox);
            this.Controls.Add(this._bookManagementLabel);
            this.Name = "BookManagementForm";
            this.Text = "BookManagementForm";
            this.Load += new System.EventHandler(this.BookManagementFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._managementListRowBindingSource)).EndInit();
            this._bookEditGroupBox.ResumeLayout(false);
            this._bookEditGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._managementCategoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _bookManagementLabel;
        private System.Windows.Forms.ListBox _bookListBox;
        private System.Windows.Forms.GroupBox _bookEditGroupBox;
        private System.Windows.Forms.Button _addBookButton;
        private System.Windows.Forms.Button _saveBookButton;
        private System.Windows.Forms.Button _browseImageButton;
        private System.Windows.Forms.Label _bookNumberLabel;
        private System.Windows.Forms.Label _bookAuthorLabel;
        private System.Windows.Forms.Label _bookCategoryLabel;
        private System.Windows.Forms.Label _bookImagePathLabel;
        private System.Windows.Forms.Label _bookPublicationItemLabel;
        private System.Windows.Forms.Label _bookNameLabel;
        private System.Windows.Forms.ComboBox _bookCategoryComboBox;
        private System.Windows.Forms.TextBox _bookImagePathTextBox;
        private System.Windows.Forms.TextBox _bookAuthorTextBox;
        private System.Windows.Forms.TextBox _bookNumberTextBox;
        private System.Windows.Forms.TextBox _bookPublicationItemTextBox;
        private System.Windows.Forms.TextBox _bookNameTextBox;
        private System.Windows.Forms.BindingSource _managementCategoryBindingSource;
        private System.Windows.Forms.BindingSource _managementListRowBindingSource;
    }
}