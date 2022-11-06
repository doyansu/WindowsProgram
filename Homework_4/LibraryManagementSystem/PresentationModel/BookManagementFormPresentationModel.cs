using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel.BindingListObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class BookManagementFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Library _model;
        private BindingList<ManagementListRow> _managementList = new BindingList<ManagementListRow>();
        private BindingList<ManagementCategory> _managementCategoryList = new BindingList<ManagementCategory>();
        private int _selectedIndex = 0;
        private bool _isAddEnabled = false;
        private bool _isBrowseEnabled = false;
        private bool _isSaveEnabled = false;

        private const string NOTIFY_ADD = "IsAddEnabled";
        private const string NOTIFY_BROWSE = "IsBrowseEnabled";
        private const string NOTIFY_SAVE = "IsSaveEnabled";
        private const string NOTIFY_SELECTED_INDEX = "SelectIndex";

        public BookManagementFormPresentationModel(Library model)
        {
            this._model = model;
            this.UpdateManagementCategoryList();
            this.UpdateManagementList();
        }

        #region Private Function
        // 更新管理類別清單
        private void UpdateManagementCategoryList()
        {
            List<string> categoryList = this._model.GetCategoryList();
            this._managementCategoryList.Clear();
            foreach (string category in categoryList)
                this._managementCategoryList.Add(new ManagementCategory(category));
        }

        // 更新管理清單
        private void UpdateManagementList()
        {
            List<BookInformation> informationList = this._model.GetBookItemsInformationList();
            this._managementList.Clear();
            foreach (BookInformation bookInformation in informationList)
                this._managementList.Add(new ManagementListRow(bookInformation));
        }
        #endregion

        #region Form Event
        // 點擊新增書籍按鈕
        public void AddBookButtonClick()
        {
            // now do nothing
        }

        // 點擊儲存按鈕
        public void SaveBookButtonClick()
        {
            BookInformation bookInformation = this._managementList[this._selectedIndex].BookInformationObject;
            bookInformation.Commit();
            this._model.SelectBook(bookInformation.BookName);
            this._model.ChangeSelectedBookCategory(bookInformation.BookCategory);
            //this.UpdateManagementList();
        }
        #endregion

        #region Property
        public IBindingList ManagementList
        {
            get
            {
                return this._managementList;
            }
        }

        public IBindingList ManagementCategoryList
        {
            get
            {
                return this._managementCategoryList;
            }
        }

        public bool IsAddEnabled 
        {
            get
            {
                return this._isAddEnabled;
            }
            set
            {
                if (this._isAddEnabled != value)
                {
                    this._isAddEnabled = value;
                    this.NotifyPropertyChanged(NOTIFY_ADD);
                }
            }
        }

        public bool IsBrowseEnabled 
        {
            get
            {
                return this._isBrowseEnabled;
            }
            set
            {
                if (this._isBrowseEnabled != value)
                {
                    this._isBrowseEnabled = value;
                    this.NotifyPropertyChanged(NOTIFY_BROWSE);
                }
            }
        }

        public bool IsSaveEnabled 
        {
            get
            {
                return this._isSaveEnabled;
            }
            set
            {
                if (this._isSaveEnabled != value)
                {
                    this._isSaveEnabled = value;
                    this.NotifyPropertyChanged(NOTIFY_SAVE);
                }
            }
        }

        public string SelectedBookImagePath
        {
            get
            {
                return this._selectedIndex != -1 ? this._managementList[this._selectedIndex].BookImagePath : "";
            }
            set
            {
                if (this._selectedIndex != -1)
                    this._managementList[this._selectedIndex].BookImagePath = value;
            }
        }

        public int SelectedIndex 
        {
            get
            {
                return this._selectedIndex;
            }
            set
            {
                if (this._selectedIndex != value)
                {
                    this._selectedIndex = value;
                    this.NotifyPropertyChanged(NOTIFY_SELECTED_INDEX);
                }
                this.IsBrowseEnabled = this._selectedIndex >= 0;
            }
        }
        #endregion

        // 通知 databing 改變
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
