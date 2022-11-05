using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class ManagementListRow : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private BookInformation _bookInformation;

        private bool _isStoreAble = false;

        private const string NOTIFY_NAME = "BookName";
        private const string NOTIFY_NUMBER = "BookInternationalStandardBookNumber";
        private const string NOTIFY_AUTHOR = "BookAuthor";
        private const string NOTIFY_PUBLICATION_ITEM = "BookPublicationItem";
        private const string NOTIFY_CATEGORY = "BookCategory";
        private const string NOTIFY_IMAGE_PATH = "BookImagePath";
        private const string NOTIFY_IS_STORE_ABLE = "IsStoreAble";

        #endregion

        #region Constructor
        public ManagementListRow(BookInformation bookInformation)
        {
            this._bookInformation = bookInformation;
        }
        #endregion

        #region Property
        public string BookName
        {
            get
            {
                return this._bookInformation.BookName;
            }
            set
            {
                if (this._bookInformation.BookName != value)
                {
                    this._bookInformation.BookName = value;
                    this.NotifyPropertyChanged(NOTIFY_NAME);
                    this.IsStoreAble = this._bookInformation.ContentEdited && this.ContentFull;
                }
            }
        }

        public string BookInternationalStandardBookNumber
        {
            get
            {
                return this._bookInformation.BookNumber;
            }
            set
            {
                if (this._bookInformation.BookNumber != value)
                {
                    this._bookInformation.BookNumber = value;
                    this.NotifyPropertyChanged(NOTIFY_NUMBER);
                    this.IsStoreAble = this._bookInformation.ContentEdited && this.ContentFull;
                }
            }
        }

        public string BookAuthor
        {
            get
            {
                return this._bookInformation.BookAuthor;
            }
            set
            {
                if (this._bookInformation.BookAuthor != value)
                {
                    this._bookInformation.BookAuthor = value;
                    this.NotifyPropertyChanged(NOTIFY_AUTHOR);
                    this.IsStoreAble = this._bookInformation.ContentEdited && this.ContentFull;
                }
            }
        }

        public string BookPublicationItem
        {
            get
            {
                return this._bookInformation.BookPublicationItem;
            }
            set
            {
                if (this._bookInformation.BookPublicationItem != value)
                {
                    this._bookInformation.BookPublicationItem = value;
                    this.NotifyPropertyChanged(NOTIFY_PUBLICATION_ITEM);
                    this.IsStoreAble = this._bookInformation.ContentEdited && this.ContentFull;
                }
            }
        }

        public string BookCategory
        {
            get
            {
                return this._bookInformation.BookCategory;
            }
            set
            {
                if (this._bookInformation.BookCategory != value)
                {
                    this._bookInformation.BookCategory = value;
                    this.NotifyPropertyChanged(NOTIFY_CATEGORY);
                    this.IsStoreAble = this._bookInformation.ContentEdited && this.ContentFull;
                }
            }
        }

        public string BookImagePath
        {
            get
            {
                return this._bookInformation.BookImagePath;
            }
            set
            {
                if (this._bookInformation.BookImagePath != value)
                {
                    this._bookInformation.BookImagePath = value;
                    this.NotifyPropertyChanged(NOTIFY_IMAGE_PATH);
                    this.IsStoreAble = this._bookInformation.ContentEdited && this.ContentFull;
                }
            }
        }

        private bool ContentFull
        {
            get
            {
                return this.BookName != "" && this.BookInternationalStandardBookNumber != "" && this.BookAuthor != "" && this.BookPublicationItem != "" && this.BookCategory != "" && this.BookImagePath != "";
            }
        }

        public bool IsStoreAble
        {
            get
            {
                return this._isStoreAble;
            }
            set
            {
                if (this._isStoreAble != value)
                {
                    this._isStoreAble = value;
                    this.NotifyPropertyChanged(NOTIFY_IS_STORE_ABLE);
                }
            }
        }
        #endregion

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
