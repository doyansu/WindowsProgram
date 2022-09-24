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
        public event ModelEventHandler _updateView;
        public delegate void ModelEventHandler();
        #endregion

        #region Book Data
        private BookItem _selectedBookItem;
        private List<Book> _bookList;
        private List<BookItem> _borrowingList;
        private List<BookItem> _bookItemList;
        private List<BookCategory> _bookCategoryList;
        #endregion

        #region Constrctor
        public Library()
        {
            this._selectedBookItem = null;
            this._bookList = new List<Book>();
            this._bookItemList = new List<BookItem>();
            this._borrowingList = new List<BookItem>();
            this._bookCategoryList = new List<BookCategory>();
        }
        #endregion

        #region Process
        // load books data from hw1_books_source.txt
        public void LoadBookData()
        {
            const string FILE_NAME = "../../../hw1_books_source.txt";
            const string BOOK = "BOOK";
            const int DATA_ROWS = 6;
            StreamReader file = new StreamReader(@FILE_NAME);

            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                List<string> bookData = new List<string>();
                if (line == BOOK)
                {
                    for (int i = 0; i < DATA_ROWS; i++)
                        bookData.Add(file.ReadLine());
                    this.CollectBooks(bookData);
                }
            }
        }

        // save book data
        private void CollectBooks(List<string> bookData)
        {
            int index = 0;
            int quantity = int.Parse(bookData[index++]);
            string category = bookData[index++];
            Book book = new Book(bookData[index++], bookData[index++], bookData[index++], bookData[index++]);
            List<BookCategory> bookCategoryQueryResult = _bookCategoryList.Where(new Func<BookCategory, bool>((bookCategory) =>
            {
                return bookCategory.GetCategory() == category;
            })).ToList();

            _bookList.Add(book);
            _bookItemList.Add(new BookItem(book, quantity));
            if (bookCategoryQueryResult.Count == 0)
            {
                _bookCategoryList.Add(new BookCategory(category));
                bookCategoryQueryResult.Add(_bookCategoryList.Last());
            }
            bookCategoryQueryResult.First().AddBook(book);
        }

        // process TabPageButton onClick
        public void ClickTabPageButton(string category, object buttonTag)
        {
            int index = int.Parse(buttonTag.ToString());
            List<BookCategory> bookCategoryQuery = _bookCategoryList.Where(new Func<BookCategory, bool>((bookCategory) =>
            {
                return bookCategory.GetCategory() == category;
            })).ToList();
            List<BookItem> bookItemQuery = _bookItemList.Where(new Func<BookItem, bool>((bookItem) =>
            {
                return bookItem.GetBook() == bookCategoryQuery.First().GetBookByIndex(index);
            })).ToList();
            this._selectedBookItem = bookItemQuery.First();
            this.UpdateView();
        }

        // add book to BorrowingList
        public void JoinBorrowingList()
        {
            if (this._selectedBookItem != null)
                this._borrowingList.Add(this._selectedBookItem.TakeBookItem(1));
            this.UpdateView();
        }

        // BookCategoryTabControl SelectedIndex is Changed
        public void BookCategoryTabControlSelectedIndexChanged()
        {
            this._selectedBookItem = null;
            this.UpdateView();
        }

        // ConfirmBorrowingButton Click
        public void ConfirmBorrowingButtonClick()
        {
            // now do nothing
        }
        #endregion

        #region output
        // get tabpage data (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetTabPageData()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            foreach (BookCategory bookCategory in this._bookCategoryList)
                data[bookCategory.GetCategory()] = bookCategory.GetBookCount();
            return data;
        }

        // get Selected Book infomation
        public string GetSelectedBookInformation()
        {
            string information = "";
            if (this._selectedBookItem != null)
                information += this._selectedBookItem.GetBook().GetFormatInformation();
            return information;
        }

        // get SelectedBook's InformationArray
        public string[] GetSelectedBookInformationArray()
        {
            const string NULL = "null";
            string[] information = { NULL, NULL, NULL, NULL };
            if (this._selectedBookItem != null)
                information = this._selectedBookItem.GetBook().GetBookInformationArray();
            return information;
        }

        // get Selected Book Quantity
        public string GetSelectedBookQuantityString()
        {
            const string QUANTITY_TEXT = "剩餘數量 : ";
            const string NO_BOOK_ITEM = "";
            return QUANTITY_TEXT + (this._selectedBookItem != null ? this._selectedBookItem.GetQuantity().ToString() : NO_BOOK_ITEM);
        }

        // get borrowingList Quantity string
        public string GetBorrowingListQuantityString()
        {
            const string TITLE = "借書數量 : ";
            int quantity = 0;
            foreach (BookItem bookItem in this._borrowingList)
                quantity += bookItem.GetQuantity();
            return TITLE + quantity;
        }

        // get selectedBookItem quantity state
        public bool IsAddBookButtonEnabled()
        {
            return _selectedBookItem != null && _selectedBookItem.GetQuantity() > 0;
        }
        #endregion

        #region Event Handle
        // handle _updateView evnet
        private void UpdateView()
        {
            if (_updateView != null)
                _updateView.Invoke();
        }
        #endregion
    }
}
