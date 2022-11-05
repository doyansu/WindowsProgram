using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BookInformation
    {
        private BookItem _bookItem;
        private Book _book;
        private string _category;

        public BookInformation(BookItem bookItem, string category)
        {
            this._bookItem = bookItem;
            this._book = bookItem.Book;
            this._category = category;
        }

        #region Getter and Setter
        public string BookName
        {
            get
            {
                return this._book.Name;
            }
        }

        public string BookNumber
        {
            get
            {
                return this._book.InternationalStandardBookNumber;
            }
        }

        public string BookAuthor
        {
            get
            {
                return this._book.Author;
            }
        }

        public string BookPublicationItem
        {
            get
            {
                return this._book.PublicationItem;
            }
        }

        public string BookImagePath
        {
            get
            {
                return this._book.ImagePath;
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
        }

        public int BookQuantity
        {
            get
            {
                return this._bookItem.Quantity;
            }
        }
        #endregion
    }
}
