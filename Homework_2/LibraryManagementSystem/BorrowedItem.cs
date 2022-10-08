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
        private Book _book;

        #region Constructor
        public BorrowedItem(Book book)
        {
            this.Date = DateTime.Now;
            this.Book = book;
        }
        #endregion

        #region Member Function
        // 取得資料清單
        public List<string> GetInformationList()
        {
            const int BORROWING_PERIOD = 30;
            List<string> informationList = this.Book.GetInformationList();
            informationList.Insert(1, this.Date.AddDays(BORROWING_PERIOD).ToShortDateString());
            informationList.Insert(1, this.Date.ToShortDateString());
            informationList.Insert(1, 1.ToString());
            return informationList;
        }
        #endregion

        #region Getter and Setter
        public DateTime Date 
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public Book Book 
        {
            get
            {
                return _book;
            }
            set
            {
                _book = value;
            }
        }
        #endregion
    }
}
