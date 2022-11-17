using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryManagementSystem.Model.Tests
{
    [TestClass()]
    public class BorrowedListTests
    {
        BorrowedList _borrowedList;
        List<Book> _bookList = new List<Book>();
        List<BookItem> _bookItemList = new List<BookItem>();
        const string CATEGORY = "category";


        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _borrowedList = new BorrowedList();
            ReadFile("TestFile/hw4_books_source.txt");
        }

        // readfile
        private void ReadFile(string fileName)
        {
            _bookList = new List<Book>();
            const string START_LINE = "BOOK";
            StreamReader file = new StreamReader(@fileName);
            int imagePath = 1;
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line == START_LINE)
                {
                    List<string> bookData = new List<string>();
                    for (int i = 0; i < 6; i++)
                        bookData.Add(file.ReadLine());
                    Book book = new Book(bookData[2], bookData[3], bookData[4], bookData[5], imagePath++.ToString());
                    _bookList.Add(book);
                    _bookItemList.Add(new BookItem(book, int.Parse(bookData[0])));
                }
            }
        }

        // TestBorrowedList
        [TestMethod()]
        public void TestBorrowedList()
        {
            Assert.AreEqual(0, _borrowedList.Count);
        }

        // TestAdd
        [TestMethod()]
        public void TestAdd()
        {
            foreach (BookItem bookItem in _bookItemList)
                _borrowedList.Add(new BorrowedItem(bookItem));

            Assert.AreEqual(_bookItemList.Count, _borrowedList.Count);
        }

        // TestClear
        [TestMethod()]
        public void TestClear()
        {
            foreach (BookItem bookItem in _bookItemList)
                _borrowedList.Add(new BorrowedItem(bookItem));
            _borrowedList.Clear();

            Assert.AreEqual(0, _borrowedList.Count);
        }

        // TestRefreshList
        [TestMethod()]
        public void TestRefreshList()
        {
            int answer = 0;
            for (int i = 0; i < _bookItemList.Count; i++)
                if (i % 2 == 0)
                    _bookItemList[i].Quantity = 0;
                else
                    answer++;

            foreach (BookItem bookItem in _bookItemList)
                _borrowedList.Add(new BorrowedItem(bookItem));
            _borrowedList.RefreshList();

            Assert.AreEqual(answer, _borrowedList.Count);

            _borrowedList.Clear();
            for (int i = 0; i < _bookItemList.Count; i++)
                    _bookItemList[i].Quantity = 0;

            foreach (BookItem bookItem in _bookItemList)
                _borrowedList.Add(new BorrowedItem(bookItem));
            _borrowedList.RefreshList();

            Assert.AreEqual(0, _borrowedList.Count);
        }

        // TestGetBookItemAt
        [TestMethod()]
        public void TestGetBookItemAt()
        {
            foreach (BookItem bookItem in _bookItemList)
                _borrowedList.Add(new BorrowedItem(bookItem));

            for(int i = 0; i < _bookItemList.Count; i++)
                Assert.AreEqual(_bookItemList[i], _borrowedList.GetBookItemAt(i));
            Assert.AreEqual(null, _borrowedList.GetBookItemAt(-1));
            Assert.AreEqual(null, _borrowedList.GetBookItemAt(_borrowedList.Count + 1));
        }

        // TestGetInformationList
        [TestMethod()]
        public void TestGetInformationList()
        {
            foreach (BookItem bookItem in _bookItemList)
                _borrowedList.Add(new BorrowedItem(bookItem));

            List<BorrowedBookInformation>  borrowedBookInformation = _borrowedList.GetInformationList();
            Assert.AreEqual(_bookItemList.Count, borrowedBookInformation.Count);
        }
    }
}