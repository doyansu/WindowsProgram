using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    // model class
    public class Library
    {
        #region Event
        public event Action _modelChanged;
        #endregion

        #region Attributes
        private BookItem _selectedBookItem = null;
        private List<Book> _bookList = new List<Book>();
        private List<BookItem> _borrowingList = new List<BookItem>();
        private List<BookItem> _bookItemList = new List<BookItem>();
        private List<BookCategory> _bookCategoryList = new List<BookCategory>();
        private BorrowedList _borrowedList = new BorrowedList();
        #endregion

        #region Constrctor
        public Library()
        {
            this.LoadsBooksData();
        }
        #endregion

        #region Member Function
        // 透過類別選擇書籍
        public void SelectBookItem(string category, int index)
        {
            BookCategory bookCategoryQuery = this._bookCategoryList.Find(bookCategory => bookCategory.Category == category);
            BookItem bookItemQuery = this._bookItemList.Find(bookItem => bookItem.Book == bookCategoryQuery.GetBookByIndex(index));
            this._selectedBookItem = bookItemQuery;
            this.ModelChanged();
        }

        // 不選擇任何書籍
        public void UnselectedBookItem()
        {
            this._selectedBookItem = null;
            this.ModelChanged();
        }

        // 將選擇的書籍加入借書單
        public void JoinSelectedBookItemToBorrowingList()
        {
            this._borrowingList.Add(this._selectedBookItem.Take(1));
            this.ModelChanged();
        }

        // 借書
        public void BorrowBooks()
        {
            foreach (BookItem borrowedBook in this._borrowingList)
                this._borrowedList.Add(new BorrowedItem(borrowedBook.Book));
            this._borrowingList.Clear();
            this.ModelChanged();
        }

        // 刪除全部借書單內的 item
        public void ReturnAllBorrowingListItem()
        {
            while (this._borrowingList.Count > 0)
                ReturnBorrowingListItem(0);
            this.ModelChanged();
        }

        // 刪除借書單內的 item
        public void ReturnBorrowingListItem(int index)
        {
            if (index >= 0 && index < this._borrowingList.Count)
            {
                this.ReturnBookItem(this._borrowingList[index]);
                this._borrowingList.RemoveAt(index);
            }
            this.ModelChanged();
        }

        // 歸還書籍
        public void ReturnBorrowedListItem(int index)
        {
            this.ReturnBookItem(new BookItem(this._borrowedList.GetBookAt(index), 1));
            this._borrowedList.RemoveAt(index);
            this.ModelChanged();
        }
        #endregion

        #region Private Function
        // 從 hw2_books_source.txt 下載資料
        private void LoadsBooksData()
        {
            const string FILE_NAME = "../../../hw3_books_source.txt";
            const string BOOK = "BOOK";
            const int DATA_ROWS = 6;
            StreamReader file = new StreamReader(@FILE_NAME);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line == BOOK)
                {
                    List<string> bookData = new List<string>();
                    for (int i = 0; i < DATA_ROWS; i++)
                        bookData.Add(file.ReadLine());
                    this.SaveBooks(bookData);
                }
            }
        }

        // 存取書籍資料
        private void SaveBooks(List<string> bookData)
        {
            int index = 0;
            int quantity = int.Parse(bookData[index++]);
            string category = bookData[index++];
            Book book = new Book(bookData[index++], bookData[index++], bookData[index++], bookData[index++]);
            BookCategory bookCategoryQueryResult = this._bookCategoryList.Find(bookCategory => bookCategory.Category == category);

            this._bookList.Add(book);
            this._bookItemList.Add(new BookItem(book, quantity));
            if (bookCategoryQueryResult == null)
            {
                bookCategoryQueryResult = new BookCategory(category);
                this._bookCategoryList.Add(bookCategoryQueryResult);
            }
            bookCategoryQueryResult.AddBook(book);
        }

        // 將書籍還回 _bookItemList 清單
        private void ReturnBookItem(BookItem returnItem)
        {
            this._bookItemList.Find(bookItem => bookItem.IsBookEquals(returnItem)).AddQuantity(returnItem);
        }
        #endregion

        #region Output
        // 取得每類書籍對映的數量鍵值對 (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetCategoryQuantityPair()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            foreach (BookCategory bookCategory in this._bookCategoryList)
                data[bookCategory.Category] = bookCategory.GetBookCount();
            return data;
        }

        // 取得書籍的書籍數量
        public int GetBookItemQuantity(string bookName)
        {
            const int NULL_VALUE = -1;
            BookItem bookItem = this._bookItemList.Find(content => content.Book.Name == bookName);
            return bookItem != null ? bookItem.Quantity : NULL_VALUE;
        }

        // 取得所選書籍的書籍名稱
        public string GetSelectedBookItemName()
        {
            const string NULL_VALUE = null;
            return this._selectedBookItem != null ? this._selectedBookItem.Book.Name : NULL_VALUE;
        }

        // 取得所選書籍的書籍資訊
        public string GetSelectedBookItemInformation()
        {
            const string NULL_VALUE = null;
            return this._selectedBookItem != null ? this._selectedBookItem.Book.GetFormatInformation() : NULL_VALUE;
        }

        // 取得所選書籍的剩餘數量
        public int GetSelectedBookItemQuantity()
        {
            const int NULL_VALUE = -1;
            return this._selectedBookItem != null ? this._selectedBookItem.Quantity : NULL_VALUE;
        }

        // 取得所選書籍的剩餘數量字串
        public string GetSelectedBookItemQuantityString()
        {
            const string NULL_VALUE = "";
            return this._selectedBookItem != null ? this._selectedBookItem.Quantity.ToString() : NULL_VALUE;
        }

        // 取得借書單的資料清單
        public List<List<string>> GetBorrowingListInformationList()
        {
            List<List<string> > informationList = new List<List<string>>();
            foreach (BookItem bookItem in this._borrowingList)
                informationList.Add(bookItem.GetInformationList());
            return informationList;
        }

        // 取得我的書包的資料清單
        public List<List<string>> GetBorrowedListInformationList()
        {
            return this._borrowedList.GetInformationList();
        }

        // 取得借書單總共有幾本書
        public int GetBorrowingListQuantity()
        {
            int quantity = 0;
            foreach (BookItem bookItem in this._borrowingList)
                quantity += bookItem.Quantity;
            return quantity;
        }

        // 取得借書單有幾種書
        public int GetBorrowedListCount()
        {
            return this._borrowingList.Count;
        }

        // 取得已借書籍名稱
        public string GetBorrowedBookName(int index)
        {
            Book book = this._borrowedList.GetBookAt(index);
            return book != null ? book.Name : null;
        }
        #endregion

        #region Event Invoke Function
        // handle _updateView evnet
        private void ModelChanged()
        {
            if (this._modelChanged != null)
                this._modelChanged.Invoke();
        }
        #endregion
    }
}
