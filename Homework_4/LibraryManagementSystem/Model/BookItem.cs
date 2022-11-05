using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BookItem
    {
        private Book _book;
        private int _quantity;

        #region Constrctor
        public BookItem(Book book, int quantity)
        {
            this.Book = book;
            this.Quantity = quantity > 0 ? quantity : 0;
        }
        #endregion

        #region Member Function
        // Copy Object
        public BookItem Copy()
        {
            BookItem newBookItem = new BookItem(this.Book, this.Quantity);
            return newBookItem;
        }

        // take book form this object
        public BookItem Take(int quantity)
        {
            if (quantity < 0)
                return null;
            if (this.Quantity < quantity)
            {
                quantity = this.Quantity;
                this.Quantity = 0;
            }
            else
            {
                this.Quantity -= quantity;
            }
            return new BookItem(this.Book, quantity);
        }

        // add Quantity by int
        public void AddQuantity(BookItem otherItem)
        {
            if (this.Book == otherItem.Book)
                this.Quantity += otherItem.Quantity;
        }

        // check book equal
        public bool IsBookEquals(BookItem otherItem)
        {
            return this.Book == otherItem.Book;
        }

        // 取得資訊陣列
        public List<string> GetInformationList()
        {
            List<string> informationList = this.Book.GetInformationList();
            informationList.Insert(1, this.Quantity.ToString());
            return informationList;
        }
        #endregion

        #region Getter and Setter
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

        public int Quantity 
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value > 0 ? value : 0;
            }
        }
        #endregion
    }
}
