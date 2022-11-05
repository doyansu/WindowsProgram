using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BorrowedBookInformation
    {
        
        private BorrowedItem _borrowedItem;
        private BookItem _bookItem;
        private Book _book;

        public BorrowedBookInformation(BorrowedItem borrowedItem)
        {
            this._borrowedItem = borrowedItem;
            this._bookItem = borrowedItem.BookItem;
            this._book = this._bookItem.Book;
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

        public string BookFormatInformation
        {
            get
            {
                return this._book.GetFormatInformation();
            }
        }

        public int BookQuantity
        {
            get
            {
                return this._bookItem.Quantity;
            }
        }

        public DateTime BorrowingDate
        {
            get
            {
                return this._borrowedItem.Date;
            }
        }

        public DateTime ReturnDue
        {
            get
            {
                return this._borrowedItem.ReturnDue;
            }
        }
        #endregion
    }
}
