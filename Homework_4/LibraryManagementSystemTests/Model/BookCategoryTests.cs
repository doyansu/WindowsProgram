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
    public class BookCategoryTests
    {
        BookCategory _bookCategory;
        PrivateObject _PrivateObject;
        List<Book> _bookList;
        const string CATEGORY = "category";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _bookCategory = new BookCategory(CATEGORY);
            _PrivateObject = new PrivateObject(_bookCategory);
            ReadFile("hw1_books_source.txt");
        }

        // TestBookCategory
        [TestMethod()]
        public void TestBookCategory()
        {
            Assert.AreEqual(CATEGORY, _bookCategory.Category);
            Assert.AreEqual(0, _bookCategory.GetBookCount());
        }

        // TestAddBook
        [TestMethod()]
        public void TestAddBook()
        {
            foreach (Book book in _bookList)
                _bookCategory.AddBook(book);
            Assert.AreEqual(CATEGORY, _bookCategory.Category);
            Assert.AreEqual(_bookList.Count, _bookCategory.GetBookCount());

            int index = 0;
            foreach (Book book in _bookList)
                Assert.AreEqual(book, _bookCategory.GetBookByIndex(index++));
        }

        // TestContainBook
        [TestMethod()]
        public void TestContainBook()
        {
            int mid = _bookList.Count / 2;
            for (int i = 0; i < mid; i++)
                _bookCategory.AddBook(_bookList[i]);

            for (int i = 0; i < _bookList.Count; i++)
            {
                if(i < mid)
                    Assert.AreEqual(true, _bookCategory.ContainBook(_bookList[i]));
                else
                    Assert.AreEqual(false, _bookCategory.ContainBook(_bookList[i]));
            }
        }

        // TestRemove
        [TestMethod()]
        public void TestRemove()
        {
            foreach (Book book in _bookList)
                _bookCategory.AddBook(book);

            for (int i = 0; i < _bookList.Count; i++)
                if (i % 2 == 0)
                    _bookCategory.Remove(_bookList[i]);

            for (int i = 0; i < _bookList.Count; i++)
                if (i % 2 == 0)
                    Assert.AreEqual(false, _bookCategory.ContainBook(_bookList[i]));
                else
                    Assert.AreEqual(true, _bookCategory.ContainBook(_bookList[i]));
        }

        // TestGetBookByIndex
        [TestMethod()]
        public void TestGetBookByIndex()
        {
            foreach (Book book in _bookList)
                _bookCategory.AddBook(book);

            int index = 0;
            foreach (Book book in _bookList)
                Assert.AreEqual(book, _bookCategory.GetBookByIndex(index++));

            Assert.AreEqual(null, _bookCategory.GetBookByIndex(-1));
            Assert.AreEqual(null, _bookCategory.GetBookByIndex(_bookList.Count + 1));
            Assert.AreEqual(null, _bookCategory.GetBookByIndex(_bookList.Count + 2));
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
                    for (int i = 0; i< 6; i++)
                        bookData.Add(file.ReadLine());
                    _bookList.Add(new Book(bookData[2], bookData[3], bookData[4], bookData[5], imagePath++.ToString()));
                }
            }
        }
    }
}