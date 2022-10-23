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
        private Book _selectedBook = null;
        private List<BookItem> _bookItemList = new List<BookItem>();
        private List<BookCategory> _bookCategoryList = new List<BookCategory>();
        private BorrowedList _borrowedList = new BorrowedList();
        #endregion

        #region Constrctor
        public Library()
        {
            this.InitializeBooksData();
        }
        #endregion

        #region Member Function
        // 透過類別選擇書籍
        public void SelectBook(string category, int index)
        {
            BookCategory bookCategoryQuery = this._bookCategoryList.Find(bookCategory => bookCategory.Category == category);
            BookItem bookItemQuery = this.FindBookItem(bookCategoryQuery.GetBookByIndex(index));
            this._selectedBook = bookItemQuery != null ? bookItemQuery.Book : null;
        }

        // 透過名稱選擇書籍
        public void SelectBook(string bookName)
        {
            BookItem bookItemQuery = this.FindBookItem(bookName);
            this._selectedBook = bookItemQuery != null ? bookItemQuery.Book : null;
        }

        // 不選擇任何書籍
        public void UnselectedBook()
        {
            this._selectedBook = null;
        }

        // 借書
        public void BorrowBook(string bookName, int quantity)
        {
            BookItem bookItem = this.FindBookItem(bookName);
            if (bookItem != null)
                this._borrowedList.Add(new BorrowedItem(bookItem.Take(quantity)));
            this.ModelChanged();
        }

        // 歸還書籍
        public void ReturnBorrowedListItem(int index, int quantity)
        {
            this.ReturnBookItem(this._borrowedList.GetBookItemAt(index).Take(quantity));
            this._borrowedList.RefreshList();
            this.ModelChanged();
        }

        // 補貨
        public void AddBook(string bookName, int quantity)
        {
            this.FindBookItem(bookName).Quantity += quantity;
            this.ModelChanged();
        }
        #endregion

        #region Private Function
        // 下載書籍資料
        private void InitializeBooksData()
        {
            const string FILE_NAME = "../../../hw3_books_source.txt";
            const string START_LINE = "BOOK";
            const int DATA_ROWS = 6;
            StreamReader file = new StreamReader(@FILE_NAME);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line == START_LINE)
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
            this._bookItemList.Add(new BookItem(book, quantity));
            if (bookCategoryQueryResult == null)
            {
                bookCategoryQueryResult = new BookCategory(category);
                this._bookCategoryList.Add(bookCategoryQueryResult);
            }
            bookCategoryQueryResult.AddBook(book);
        }

        // 使用名稱找到 bookItem
        private BookItem FindBookItem(string bookName)
        {
            return this._bookItemList.Find(content => content.Book.Name == bookName);
        }

        // 使用書籍找到 bookItem
        private BookItem FindBookItem(Book book)
        {
            return this._bookItemList.Find(content => content.Book == book);
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
        
        // 取得所選書籍的書籍名稱
        public string GetSelectedBookName()
        {
            const string NULL_VALUE = null;
            return this._selectedBook != null ? this._selectedBook.Name : NULL_VALUE;
        }

        // 取得所選書籍的書籍資訊
        public string GetSelectedBookInformation()
        {
            const string NULL_VALUE = null;
            return this._selectedBook != null ? this._selectedBook.GetFormatInformation() : NULL_VALUE;
        }

        // 取得所選書籍的剩餘數量
        public int GetSelectedBookQuantity()
        {
            const int NULL_VALUE = -1;
            return this._selectedBook != null ? this.FindBookItem(this._selectedBook).Quantity : NULL_VALUE;
        }

        // 取得所選書籍的剩餘數量字串
        public string GetSelectedBookQuantityString()
        {
            const string NULL_VALUE = "";
            return this._selectedBook != null ? this.FindBookItem(this._selectedBook).Quantity.ToString() : NULL_VALUE;
        }

        // 取得書籍的資料清單
        public List<List<string>> GetBookItemsInformationList()
        {
            List<List<string>> informationList = new List<List<string>>();
            foreach (BookItem bookItem in this._bookItemList)
            {
                List<string> stringList = bookItem.Book.GetInformationList();
                stringList.Add(this._bookCategoryList.Find(content => content.ContainBook(bookItem.Book)).Category);
                stringList.Add(bookItem.Quantity.ToString());
                stringList.Add(bookItem.Book.GetFormatInformation());
                informationList.Add(stringList);
            }
            return informationList;
        }

        // 取得我的書包的資料清單
        public List<List<string>> GetBorrowedListInformationList()
        {
            return this._borrowedList.GetInformationList();
        }
        #endregion

        #region Event Invoke Function
        // handle _modelChanged evnet
        private void ModelChanged()
        {
            if (this._modelChanged != null)
                this._modelChanged.Invoke();
        }
        #endregion
    }
}
