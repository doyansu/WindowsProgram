using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BookInformation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BookItem _bookItem;
        private Book _book;
        private string _sourceCategory;
        private string _category;
        private int _bookQuantity;

        public BookInformation(BookItem bookItem, string category)
        {
            this._bookItem = bookItem;
            this._book = bookItem.Book.Copy();
            this._sourceCategory = this._category = category;
            this._bookQuantity = bookItem.Quantity;
        }

        // 書籍來源相同
        public bool isSourceBookEquals(Book book)
        {
            return this._bookItem.Book == book;
        }

        #region Getter and Setter
        public string BookName
        {
            get
            {
                return this._book.Name;
            }
            set
            {
                this._book.Name = value;
            }
        }

        public string BookNumber
        {
            get
            {
                return this._book.InternationalStandardBookNumber;
            }
            set
            {
                this._book.InternationalStandardBookNumber = value;
            }
        }

        public string BookAuthor
        {
            get
            {
                return this._book.Author;
            }
            set
            {
                this._book.Author = value;
            }
        }

        public string BookPublicationItem
        {
            get
            {
                return this._book.PublicationItem;
            }
            set
            {
                this._book.PublicationItem = value;
            }
        }

        public string BookImagePath
        {
            get
            {
                return this._book.ImagePath;
            }
            set
            {
                this._book.ImagePath = value;
            }
        }

        public string BookFormatInformation
        {
            get
            {
                return this._book.GetFormatInformation();
            }
        }

        public string BookCategory
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }

        public int BookQuantity
        {
            get
            {
                return this._bookQuantity;
            }
            set
            {
                this._bookQuantity = value;
            }
        }

        public bool ContentEdited
        {
            get
            {
                return this.BookName != this.SourceBook.Name || this.BookNumber != this.SourceBook.InternationalStandardBookNumber || this.BookAuthor != this.SourceBook.Author || this.BookPublicationItem != this.SourceBook.PublicationItem || this.BookImagePath != this.SourceBook.ImagePath || this.BookCategory != this._sourceCategory || this.BookQuantity != this._bookItem.Quantity;
            }
        }

        private Book SourceBook
        {
            get
            {
                return this._bookItem.Book;
            }
        }
        #endregion
    }
}
