using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    // model class
    public class Library
    {
        #region Event
        public event Action _modelChanged;
        public event Action _bookInformationChanged;
        #endregion

        #region Attributes
        private Book _selectedBook = null;
        private List<BookItem> _bookItemList = new List<BookItem>();
        private List<BookCategory> _bookCategoryList = new List<BookCategory>();
        private BorrowedList _borrowedList = new BorrowedList();

        const int BOOK_DATA_ROWS = 6;
        #endregion

        #region Constrctor
        public Library(string dataFileName)
        {
            this.LoadBooksData(@dataFileName);
        }
        #endregion

        #region Member Function
        // 透過名稱選擇書籍
        public void SelectBook(string bookName)
        {
            BookItem bookItemQuery = this.FindBookItem(bookName);
            this._selectedBook = bookItemQuery != null ? bookItemQuery.Book : null;
        }

        // 借書
        public void BorrowSelectedBook(int quantity)
        {
            BookItem bookItem = this.FindBookItem(this._selectedBook);
            if (bookItem != null)
            {
                this._borrowedList.Add(new BorrowedItem(bookItem.Take(quantity)));
                this._borrowedList.RefreshList();
                this.UseAction(this._modelChanged);
            }
        }

        // 歸還書籍
        public void ReturnBorrowedListItem(int index, int quantity)
        {
            BookItem targetBookItem = this._borrowedList.GetBookItemAt(index);
            if (targetBookItem != null)
            {
                BookItem returnItem = targetBookItem.Take(quantity);
                this.ReturnBookItem(returnItem);
            }
            this._borrowedList.RefreshList();
            this.UseAction(this._modelChanged);
        }

        // 補貨
        public void AddBookQuantity(string bookName, int quantity)
        {
            BookItem bookItem = this.FindBookItem(bookName);
            if (quantity >= 0 && bookItem!= null)
            {
                bookItem.Quantity += quantity;
                this.UseAction(this._modelChanged);
            }
        }

        // 編輯書籍類別
        public void ChangeBookInformation(BookInformation bookInformation)
        {
            if (bookInformation != null)
            {
                Book changeBook = this.FindBookItem(bookInformation.SourceBookName).Book;
                changeBook.CopyContent(bookInformation.GetCopyBook());
                BookCategory bookCategory;
                if ((bookCategory = this.FindBookCategory(changeBook)).Category != bookInformation.BookCategory)
                {
                    bookCategory.Remove(changeBook);
                    this.FindBookCategory(bookInformation.BookCategory).AddBook(changeBook);
                }
                this.UseAction(this._bookInformationChanged);
                this.UseAction(this._modelChanged);
            }
        }
        #endregion

        #region Private Function
        // 重置 model
        private void Reset()
        {
            this._selectedBook = null;
            this._bookItemList.Clear();
            this._bookCategoryList.Clear();
            this._borrowedList.Clear();
        }

        // 下載書籍資料
        private void LoadBooksData(string fileName)
        {
            this.Reset();
            const string START_LINE = "BOOK";
            string imagePathFormat = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../image/{0}.jpg"));
            int imageIndex = 1;
            StreamReader file = new StreamReader(@fileName);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line == START_LINE)
                {
                    List<string> bookData = new List<string>();
                    for (int i = 0; i < BOOK_DATA_ROWS; i++)
                        bookData.Add(file.ReadLine());
                    bookData.Add(string.Format(imagePathFormat, imageIndex++));
                    this.SaveBook(bookData);
                }
            }
        }

        // 存取書籍資料
        private void SaveBook(List<string> bookData)
        {
            int index = 0;
            int quantity;
            const int BOOK_DATA_COUNT = BOOK_DATA_ROWS + 1;
            if (bookData.Count != BOOK_DATA_COUNT || !int.TryParse(bookData[index++], out quantity))
                return;
            string category = bookData[index++];
            Book book = new Book(bookData[index++], bookData[index++], bookData[index++], bookData[index++], bookData[index++]);
            BookCategory bookCategoryQueryResult = this.FindBookCategory(category);
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

        // 使用 Category 找到 BookCategory
        private BookCategory FindBookCategory(string category)
        {
            return this._bookCategoryList.Find(bookCategory => bookCategory.Category == category);
        }

        // 使用書籍找到 BookCategory
        private BookCategory FindBookCategory(Book book)
        {
            return this._bookCategoryList.Find(content => content.ContainBook(book));
        }

        // 將書籍還回 _bookItemList 清單
        private void ReturnBookItem(BookItem returnItem)
        {
            this.FindBookItem(returnItem.Book).AddQuantity(returnItem);
        }

        // 建立 BookInformation 物件
        private BookInformation CreateBookInformation(Book book)
        {
            return book != null ? new BookInformation(this.FindBookItem(book), this.FindBookCategory(book).Category) : null;
        }
        #endregion

        #region Output
        // 取得書籍類別清單
        public List<string> GetCategoryList()
        {
            List<string> categoryList = new List<string>();
            foreach (BookCategory bookCategory in _bookCategoryList)
                categoryList.Add(bookCategory.Category);
            return categoryList;
        }

        // 取得每類書籍對映的數量鍵值對 (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetCategoryQuantityPair()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            foreach (BookCategory bookCategory in this._bookCategoryList)
                data[bookCategory.Category] = bookCategory.GetBookCount();
            return data;
        }

        // 取得每類書籍對映的BookInformation鍵值對
        public Dictionary<string, List<BookInformation>> GetCategoryBookInformationPair()
        {
            Dictionary<string, List<BookInformation>> data = new Dictionary<string, List<BookInformation>>();
            foreach (BookCategory bookCategory in this._bookCategoryList)
            {
                List<BookInformation> bookInformation = new List<BookInformation>();
                foreach (BookItem bookItem in this._bookItemList)
                    if (bookCategory.ContainBook(bookItem.Book))
                        bookInformation.Add(new BookInformation(bookItem, bookCategory.Category));
                data[bookCategory.Category] = bookInformation;
            }
            return data;
        }

        // 取得所選書籍的剩餘數量
        public int GetSelectedBookQuantity()
        {
            const int NULL_VALUE = -1;
            return this._selectedBook != null ? this.FindBookItem(this._selectedBook).Quantity : NULL_VALUE;
        }

        // 取得書籍的資訊物件
        public BookInformation GetSelectedBookInformation()
        {
            return this.CreateBookInformation(this._selectedBook);
        }

        // 取得書籍的資訊清單
        public List<BookInformation> GetBookItemsInformationList()
        {
            List<BookInformation> informationList = new List<BookInformation>();
            foreach (BookItem bookItem in this._bookItemList)
                informationList.Add(this.CreateBookInformation(bookItem.Book));
            return informationList;
        }

        // 取得我的書包的資料清單
        public List<BorrowedBookInformation> GetBorrowedListInformationList()
        {
            return this._borrowedList.GetInformationList();
        }
        #endregion

        // handle Action evnet
        private void UseAction(Action action)
        {
            if (action != null)
                action.Invoke();
        }
    }
}