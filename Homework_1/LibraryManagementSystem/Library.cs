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
        public Library()
        {
            this._selectedBookItem = null;
            this._bookList = new List<Book>();
            this._bookItemList = new List<BookItem>();
            this._borrowingList = new List<BookItem>();
            this._bookCategoryDictionary = new Dictionary<string, BookCategory>();
        }

        // Process
        // load books data from hw1_books_source.txt
        public void LoadBookData()
        {
            const string FILE_NAME = "../../../hw1_books_source.txt";
            StreamReader file = new StreamReader(@FILE_NAME);

            while (!file.EndOfStream)
            {
                const string BOOK = "BOOK";
                string line = file.ReadLine();

                if (line == BOOK)
                {
                    List<string> bookData = new List<string>();
                    const int dataRows = 6;
                    for (int i = 0; i < dataRows; i++)
                        bookData.Add(file.ReadLine());
                    this.CollectBooks(bookData);
                }
            }
        }

        // save book data
        private void CollectBooks(List<string> bookData)
        {
            int quantity = int.Parse(bookData[0]);
            string category = bookData[1];
            const int NAME_INDEX = 2;
            const int BOOK_NUMBER_INDEX = 3;
            const int AUTHOR_INDEX = 4;
            const int PUBLICATION_ITEM_INDEX = 5;
            Book book = new Book(bookData[NAME_INDEX], bookData[BOOK_NUMBER_INDEX], bookData[AUTHOR_INDEX], bookData[PUBLICATION_ITEM_INDEX]);
            
            _bookList.Add(book);
            _bookItemList.Add(new BookItem(book, quantity));
            if (!_bookCategoryDictionary.ContainsKey(category))
                _bookCategoryDictionary[category] = new BookCategory(category);
            _bookCategoryDictionary[category].AddBook(book);
        }

        // process TabPageButton onClick
        public void ClickTabPageButton(string category, object buttonTag)
        {
            int index = int.Parse(buttonTag.ToString()); 
            foreach (BookItem bookItem in this._bookItemList)
            {
                if (bookItem.GetBook() == this._bookCategoryDictionary[category].GetBookByIndex(index))
                {
                    this._selectedBookItem = bookItem;
                    break;
                }
            }
        }

        // add book to BorrowingList
        public void JoinBorrowingList()
        {
            if (this._selectedBookItem != null)
            {
                BookItem bookItem = this._selectedBookItem.BorrowBook(1);
                if (bookItem != null)
                {
                    this._borrowingList.Add(bookItem);
                }
            }
        }

        // output
        // get tabpage data (return Dictionary<Category, BookCount>)
        public Dictionary<string, int> GetTabPageData()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            foreach (BookCategory bookCategory in this._bookCategoryDictionary.Values)
                data[bookCategory.GetCategory()] = bookCategory.GetCategoryCount();
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
            const string NO_BOOK_ITEM = "NULL";
            return QUANTITY_TEXT + (this._selectedBookItem != null ? this._selectedBookItem.GetQuantity().ToString() : NO_BOOK_ITEM);
        }

        // get borrowingList Quantity string
        public string GetBorrowingListQuantityString()
        {
            const string TITLE = "借書數量 : ";
            return TITLE + this._borrowingList.Count;
        }

        private BookItem _selectedBookItem;
        private List<Book> _bookList;
        private List<BookItem> _borrowingList;
        private List<BookItem> _bookItemList;
        //private List<BookCategory> _bookCategoryList;
        private Dictionary<string, BookCategory> _bookCategoryDictionary;
    }
}
