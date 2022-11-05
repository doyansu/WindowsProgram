using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BookInformation
    {
        private Book _book;
        private string _category;
        private int _bookQuantity;

        public BookInformation(Book book, string category, int quantity)
        {
            this._book = book;
            this._category = category;
            this._bookQuantity = quantity;
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

        public string _bookFormatInformation
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
                return this._bookQuantity;
            }
        }
        #endregion
    }
}
