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
        public event ModelEventHandler _updateView;
        public delegate void ModelEventHandler();
        #endregion

        #region Book Data
        private BookItem _selectedBookItem;
        private List<Book> _bookList;
        private List<BookItem> _borrowingList;
        private List<BookItem> _bookItemList;
        private List<BookCategory> _bookCategoryList;
        private BorrowedList _borrowedList;
        #endregion

        #region Constrctor
        public Library()
        {
            this._selectedBookItem = null;
            this._bookList = new List<Book>();
            this._bookItemList = new List<BookItem>();
            this._borrowingList = new List<BookItem>();
            this._bookCategoryList = new List<BookCategory>();
            this._borrowedList = new BorrowedList();
        }
        #endregion

        #region View Process
        // 從 hw2_books_source.txt 下載資料
        public void LoadsBooksData()
        {
            const string FILE_NAME = "../../../hw2_books_source.txt";
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

        // 透過類別選擇書籍
        public void SelectBookItem(string category, int index)
        {
            BookCategory bookCategoryQuery = this._bookCategoryList.Find(bookCategory => bookCategory.Category == category);
            BookItem bookItemQuery = this._bookItemList.Find(bookItem => bookItem.Book == bookCategoryQuery.GetBookByIndex(index));
            this._selectedBookItem = bookItemQuery;
        }

        // 將選擇的書籍加入借書單
        public void JoinSelectedBookItemToBorrowingList()
        {
            if (this._selectedBookItem != null)
                this._borrowingList.Add(this._selectedBookItem.Take(1));
        }

        // 不選擇任何書籍
        public void UnselectedBookItem()
        {
            this._selectedBookItem = null;
        }

        // 借書
        public void BorrowBooks()
        {
            // return book to _bookItemList
            foreach (BookItem returnBook in this._borrowingList)
                this._bookItemList.Find(bookItem => bookItem.IsBookEquals(returnBook)).AddQuantity(returnBook);
            this._borrowingList.Clear();
        }
        #endregion

        #region Private Function
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

        // 清空所有資料
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

        // 取得借書單的資料陣列
        public List<string[]> GetBorrowingListInformationList()
        {
            List<string[]> informationList = new List<string[]>();
            foreach (BookItem bookItem in this._borrowingList)
                informationList.Add(bookItem.Book.GetInformationArray());
            return informationList;
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
