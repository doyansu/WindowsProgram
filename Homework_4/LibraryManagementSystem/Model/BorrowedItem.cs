using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BorrowedItem
    {
        private DateTime _date;
        private BookItem _bookItem;

        #region Constructor
        public BorrowedItem(BookItem bookItem)
        {
            this.Date = DateTime.Now;
            this.BookItem = bookItem;
        }
        #endregion

        #region Member Function
        // 取得資料清單
        public List<string> GetInformationList()
        {
            const int BORROWING_PERIOD = 30;
            const int INSERT_DATE_INDEX = 2;
            List<string> informationList = this.BookItem.GetInformationList();
            informationList.Insert(INSERT_DATE_INDEX, this.Date.AddDays(BORROWING_PERIOD).ToShortDateString());
            informationList.Insert(INSERT_DATE_INDEX, this.Date.ToShortDateString());
            return informationList;
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
