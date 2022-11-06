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
        PrivateObject _PrivateObject;
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
        }

        // GetInformationListTest
        [TestMethod()]
        public void GetBookItemAtTest()
        {
            foreach (BookItem bookItem in _bookItemList)
                _borrowedList.Add(new BorrowedItem(bookItem));

            for(int i = 0; i < _bookItemList.Count; i++)
                Assert.AreEqual(_bookItemList[i], _borrowedList.GetBookItemAt(i));
        }

        // GetInformationListTest
        [TestMethod()]
        public void GetInformationListTest()
        {
            Assert.Fail();
        }
    }
}