﻿using System;
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
        public event Action _updateView;
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
        }

        // 不選擇任何書籍
        public void UnselectedBookItem()
        {
            this._selectedBookItem = null;
        }

        // 將選擇的書籍加入借書單
        public string JoinSelectedBookItemToBorrowingList()
        {
            const int LIST_LIMIT = 5;
            const string BORROWING_LIST_IS_FULL = "每次借書限借五本，您的借書單已滿";
            const string UNSELECT_BOOK = "未選擇書籍";
            string errorMessage = null;
            if (this._selectedBookItem == null)
                errorMessage = UNSELECT_BOOK;
            if (this._borrowingList.Count >= LIST_LIMIT)
                errorMessage = BORROWING_LIST_IS_FULL;
            if (errorMessage == null)
                this._borrowingList.Add(this._selectedBookItem.Take(1));
            return errorMessage;
        }

        // 借書
        public void BorrowBooks()
        {
            foreach (BookItem borrowedBook in this._borrowingList)
                this._borrowedList.Add(new BorrowedItem(borrowedBook.Book));
            this._borrowingList.Clear();
        }

        // 刪除全部借書單內的 item
        public void ReturnAllBorrowingListItem()
        {
            while (this._borrowingList.Count > 0)
                ReturnBorrowingListItem(0);
        }

        // 刪除借書單內的 item
        public void ReturnBorrowingListItem(int index)
        {
            if (index >= 0 && index < this._borrowingList.Count)
            {
                this.ReturnBookItem(this._borrowingList[index]);
                this._borrowingList.RemoveAt(index);
            }
        }

        // 歸還書籍
        public void ReturnBorrowedListItem(int index)
        {
            this.ReturnBookItem(new BookItem(this._borrowedList.GetBookAt(index), 1));
            this._borrowedList.RemoveAt(index);
        }
        #endregion

        #region Private Function
        // 從 hw2_books_source.txt 下載資料
        private void LoadsBooksData()
        {
            const string FILE_NAME = "../../../hw2_books_source.txt";
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

        // 取得所選書籍的書籍資訊
        public string GetSelectedBookInformation()
        {
            const string NULL_VALUE = "";
            return this._selectedBookItem != null ? this._selectedBookItem.Book.GetFormatInformation() : NULL_VALUE;
        }

        // 取得所選書籍的剩餘數量
        public int GetSelectedBookQuantity()
        {
            const int NULL_VALUE = -1;
            return this._selectedBookItem != null ? this._selectedBookItem.Quantity : NULL_VALUE;
        }

        // 取得所選書籍的剩餘數量字串
        public string GetSelectedBookQuantityString()
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
        public List<List<string>> GetBorrowedInformationList()
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

        // 取得當前選擇的書籍是否可加入至借書單
        public bool IsSelectedBookCanBorrowed()
        {
            return this._selectedBookItem != null ? this._selectedBookItem.Quantity > 0 && !(this._borrowingList.Where(bookItem => bookItem.IsBookEquals(this._selectedBookItem)).Count() > 0) : false;
        }
        #endregion

        #region Event Invoke Function
        // handle _updateView evnet
        private void UpdateView()
        {
            if (this._updateView != null)
                this._updateView.Invoke();
        }
        #endregion
    }
}
