using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BorrowedItem
    {
        private DateTime _date;
        private BookItem _bookItem;

        const int BORROWING_PERIOD = 30;

        #region Constructor
        public BorrowedItem(BookItem bookItem)
        {
            this.Date = DateTime.Now;
            this.BookItem = bookItem;
        }
        #endregion

        #region Property
        public DateTime Date 
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }

        public DateTime ReturnDue
        {
            get
            {
                return this.Date.AddDays(BORROWING_PERIOD);
            }
        }

        public Book Book 
        {
            get
            {
                return this._bookItem.Book;
            }
            set
            {
                this._bookItem.Book = value;
            }
        }

        public BookItem BookItem
        {
            get
            {
                return this._bookItem;
            }
            set
            {
                this._bookItem = value;
            }
        }
        #endregion
    }
}
