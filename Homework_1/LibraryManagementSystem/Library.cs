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

        #region View Process
        // load books data from hw1_books_source.txt
        public void LoadsBooksData()
        {
            const string FILE_NAME = "../../../hw1_books_source.txt";
            const string BOOK = "BOOK";
            const int DATA_ROWS = 6;
            StreamReader file = new StreamReader(@FILE_NAME);

            this.ClearAllData();
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

        // process TabPageButton onClick
        public void SelectBookItem(string category, int index)
        {
            BookCategory bookCategoryQuery = this._bookCategoryList.Find(t => t.GetCategory() == category);
            BookItem bookItemQuery = this._bookItemList.Find(bookItem => bookItem.GetBook() == bookCategoryQuery.GetBookByIndex(index));
            this._selectedBookItem = bookItemQuery;
        }

        // add book to BorrowingList
        public void JoinSelectedBookItemToBorrowingList()
        {
            if (this._selectedBookItem != null)
                this._borrowingList.Add(this._selectedBookItem.Take(1));
        }

        // Unselected BookItem
        public void UnselectedBookItem()
        {
            this._selectedBookItem = null;
        }

        // Borrow Books
        public void BorrowBooks()
        {
            // return book to _bookItemList
            foreach (BookItem returnBook in this._borrowingList)
                this._bookItemList.Find(bookItem => bookItem.IsBookEquals(returnBook)).AddQuantity(returnBook);
            this._borrowingList.Clear();
        }
        #endregion

        #region Private Function
        // save book data
        private void SaveBooks(List<string> bookData)
        {
            int index = 0;
            int quantity = int.Parse(bookData[index++]);
            string category = bookData[index++];
            Book book = new Book(bookData[index++], bookData[index++], bookData[index++], bookData[index++]);
            BookCategory bookCategoryQueryResult = this._bookCategoryList.Find(bookCategory => bookCategory.GetCategory() == category);

            this._bookList.Add(book);
            this._bookItemList.Add(new BookItem(book, quantity));
            if (bookCategoryQueryResult == null)
            {
                bookCategoryQueryResult = new BookCategory(category);
                this._bookCategoryList.Add(bookCategoryQueryResult);
            }
            bookCategoryQueryResult.AddBook(book);
        }

        // clear all of Library's data
        private void ClearAllData()
        {
            this._selectedBookItem = null;
            this._bookList.Clear();
            this._borrowingList.Clear();
            this._bookItemList.Clear();
            this._bookCategoryList.Clear();
        }
        #endregion

        #region Output
        // get tabpage data (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetCategoryQuantityPair()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            foreach (BookCategory bookCategory in this._bookCategoryList)
                data[bookCategory.GetCategory()] = bookCategory.GetBookCount();
            return data;
        }

        // get Selected Book's infomation
        public string GetSelectedBookInformation()
        {
            const string NULL_VALUE = "";
            return this._selectedBookItem != null ? this._selectedBookItem.GetBook().GetFormatInformation() : NULL_VALUE;
        }

        // get orrowingList's InformationArray
        public List<string[]> GetBorrowingListInformationList()
        {
            List<string[]> informationList = new List<string[]>();
            foreach (BookItem bookItem in this._borrowingList)
                informationList.Add(bookItem.GetBook().GetInformationArray());
            return informationList;
        }

        // get Selected Book's Quantity String
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

        // get selectedBookItem state (this function have to move to Presentation Model)
        public bool IsAddBookButtonEnabled()
        {
            return this._selectedBookItem != null && this._selectedBookItem.GetQuantity() > 0;
        }

        // get ConfirmBorrowingButton state (this function have to move to Presentation Model)
        public bool IsConfirmBorrowingButtonEnabled()
        {
            return this._borrowingList.Count > 0;
        }
        #endregion

        #region Event Handle Function
        // handle _updateView evnet
        private void UpdateView()
        {
            if (this._updateView != null)
                _updateView.Invoke();
        }

        #endregion
    }
}
