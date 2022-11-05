using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class BookManagementForm : Form
    {
        private Library _model;
        private BookManagementFormPresentationModel _presentationModel;

        const string BIND_ATTRIBUTE_TEXT = "Text";
        const string BIND_ATTRIBUTE_ENABLED = "Enabled";
        const string BIND_ATTRIBUTE_SELECTED_INDEX = "SelectedIndex";

        public BookManagementForm(Library model)
        {
            this._model = model;
            this._presentationModel = new BookManagementFormPresentationModel(model);
            InitializeComponent();
            BindData();
        }

        // BindingManager
        private BindingManagerBase BindingManager(IBindingList bindingList)
        {
            return BindingContext[bindingList]; 
        }

        #region Private Function
        // Binding data
        private void BindData()
        {
            this._bookNameTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this._bookNameTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel.ManagementList, "BookName");
            this._bookNumberTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this._bookNumberTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel.ManagementList, "BookInternationalStandardBookNumber");
            this._bookAuthorTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this._bookAuthorTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel.ManagementList, "BookAuthor");
            this._bookCategoryComboBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this._bookCategoryComboBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel.ManagementList, "BookCategory");
            this._bookPublicationItemTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this._bookPublicationItemTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel.ManagementList, "BookPublicationItem");
            this._bookImagePathTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this._bookImagePathTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel.ManagementList, "BookImagePath");
            this._saveBookButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel.ManagementList, "IsStoreAble");
            this._addBookButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsAddEnabled");
            this._browseImageButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsBrowseEnabled");
            this._bookListBox.DataSource = this._presentationModel.ManagementList;
            this._bookCategoryComboBox.DataSource = this._presentationModel.ManagementCategoryList;
        }
        #endregion

        // Form load
        private void BookManagementFormLoad(object sender, EventArgs e)
        {
        }

        // 點擊新增書籍按鈕
        private void AddBookButtonClick(object sender, EventArgs e)
        {
            this._presentationModel.AddBookButtonClick();
        }

        // 點擊瀏覽按鈕
        private void BrowseImageButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files|*.jpg;*.jpeg;*.png;";
            dialog.InitialDirectory = this._presentationModel.SelectedBookImagePath;
            dialog.Title = "請選擇書籍圖片";
            if (dialog.ShowDialog() == DialogResult.OK)
                this._presentationModel.SelectedBookImagePath = dialog.FileName;
        }

        // 點擊儲存按鈕
        private void SaveBookButtonClick(object sender, EventArgs e)
        {
            this._presentationModel.SaveBookButtonClick();
        }

        // booklist index 改變
        private void BookListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            this._presentationModel.SelectedIndex = this._bookListBox.SelectedIndex;
        }
    }
}
