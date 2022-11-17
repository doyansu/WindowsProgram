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
    public class BookInformationTests
    {
        BookInformation _bookInformation;
        PrivateObject _privateObject;
        List<Book> _bookList = new List<Book>();
        List<BookItem> _bookItemList = new List<BookItem>();
        const string CATEGORY = "category";
        const string CATEGORY_BOOK = "book";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
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

        // TestBookInformation
        [TestMethod()]
        public void TestBookInformation()
        {
            BookItem bookItem = _bookItemList[0];
            Book book = bookItem.Book;
            _bookInformation = new BookInformation(bookItem, CATEGORY);
            Assert.AreEqual(bookItem.Quantity, _bookInformation.BookQuantity);
            Assert.AreEqual(book.Name, _bookInformation.BookName);
            Assert.AreEqual(book.InternationalStandardBookNumber, _bookInformation.BookNumber);
            Assert.AreEqual(book.PublicationItem, _bookInformation.BookPublicationItem);
            Assert.AreEqual(book.Author, _bookInformation.BookAuthor);
            Assert.AreEqual(book.ImagePath, _bookInformation.BookImagePath);
            Assert.AreEqual(book.Name, _bookInformation.SourceBookName);
            Assert.AreEqual(book.GetFormatInformation(), _bookInformation.BookFormatInformation);
            Assert.AreEqual(false, _bookInformation.ContentEdited);
            Assert.AreEqual(CATEGORY, _bookInformation.BookCategory);
        }

        // TestContentEdited
        [TestMethod()]
        public void TestContentEdited()
        {
            BookInformation bookInformationIndex1 = new BookInformation(_bookItemList[1], CATEGORY_BOOK);
            _bookInformation = new BookInformation(_bookItemList[0], CATEGORY);
            BookItem bookItem = _bookItemList[0];
            Book book = bookItem.Book;

            _bookInformation.BookQuantity = bookInformationIndex1.BookQuantity;
            Assert.AreEqual(true, _bookInformation.ContentEdited);
            _bookInformation.BookQuantity = bookItem.Quantity;
            _bookInformation.BookName = bookInformationIndex1.BookName;
            Assert.AreEqual(true, _bookInformation.ContentEdited);
            _bookInformation.BookName = book.Name;
            _bookInformation.BookNumber = bookInformationIndex1.BookNumber;
            Assert.AreEqual(true, _bookInformation.ContentEdited);
            _bookInformation.BookNumber = book.InternationalStandardBookNumber;
            _bookInformation.BookPublicationItem = bookInformationIndex1.BookPublicationItem;
            Assert.AreEqual(true, _bookInformation.ContentEdited);
            _bookInformation.BookPublicationItem = book.PublicationItem;
            _bookInformation.BookAuthor = bookInformationIndex1.BookAuthor;
            Assert.AreEqual(true, _bookInformation.ContentEdited);
            _bookInformation.BookAuthor = book.Author;
            _bookInformation.BookImagePath = bookInformationIndex1.BookImagePath;
            Assert.AreEqual(true, _bookInformation.ContentEdited);
            _bookInformation.BookImagePath = book.ImagePath;
            _bookInformation.BookCategory = bookInformationIndex1.BookCategory;
            Assert.AreEqual(true, _bookInformation.ContentEdited);
        }

        // TestIsSourceBookEquals
        [TestMethod()]
        public void TestIsSourceBookEquals()
        {
            BookInformation bookInformationIndex1 = new BookInformation(_bookItemList[1], CATEGORY_BOOK);
            _bookInformation = new BookInformation(_bookItemList[0], CATEGORY);

            _bookInformation.BookQuantity = bookInformationIndex1.BookQuantity;
            _bookInformation.BookName = bookInformationIndex1.BookName;
            _bookInformation.BookNumber = bookInformationIndex1.BookNumber;
            _bookInformation.BookPublicationItem = bookInformationIndex1.BookPublicationItem;
            _bookInformation.BookAuthor = bookInformationIndex1.BookAuthor;
            _bookInformation.BookImagePath = bookInformationIndex1.BookImagePath;
            _bookInformation.BookCategory = bookInformationIndex1.BookCategory;

            foreach (BookItem bookItem in _bookItemList)
                Assert.AreEqual(bookItem == _bookItemList[0], _bookInformation.IsSourceBookEquals(new BookInformation(bookItem, CATEGORY))); 
        }

        // TestReset
        [TestMethod()]
        public void TestReset()
        {
            BookInformation bookInformationIndex = new BookInformation(_bookItemList[1], CATEGORY_BOOK);
            BookItem bookItem = _bookItemList[0];
            Book book = bookItem.Book;
            _bookInformation = new BookInformation(bookItem, CATEGORY);

            _bookInformation.BookQuantity = bookInformationIndex.BookQuantity;
            _bookInformation.BookName = bookInformationIndex.BookName;
            _bookInformation.BookNumber = bookInformationIndex.BookNumber;
            _bookInformation.BookPublicationItem = bookInformationIndex.BookPublicationItem;
            _bookInformation.BookAuthor = bookInformationIndex.BookAuthor;
            _bookInformation.BookImagePath = bookInformationIndex.BookImagePath;
            _bookInformation.BookCategory = bookInformationIndex.BookCategory;
            _bookInformation.Reset();

            Assert.AreEqual(bookItem.Quantity, _bookInformation.BookQuantity);
            Assert.AreEqual(book.Name, _bookInformation.BookName);
            Assert.AreEqual(book.InternationalStandardBookNumber, _bookInformation.BookNumber);
            Assert.AreEqual(book.PublicationItem, _bookInformation.BookPublicationItem);
            Assert.AreEqual(book.Author, _bookInformation.BookAuthor);
            Assert.AreEqual(book.ImagePath, _bookInformation.BookImagePath);
            Assert.AreEqual(book.Name, _bookInformation.SourceBookName);
            Assert.AreEqual(book.GetFormatInformation(), _bookInformation.BookFormatInformation);
            Assert.AreEqual(false, _bookInformation.ContentEdited);
            Assert.AreEqual(CATEGORY, _bookInformation.BookCategory);
        }

        // TestGetCopyBook
        [TestMethod()]
        public void TestGetCopyBook()
        {
            BookInformation bookInformationIndex = new BookInformation(_bookItemList[1], CATEGORY_BOOK);
            BookItem bookItem = _bookItemList[0];
            Book book = bookItem.Book;
            _bookInformation = new BookInformation(bookItem, CATEGORY);

            _privateObject = new PrivateObject(_bookInformation); 
            Book copyBook = _bookInformation.GetCopyBook();

            Assert.AreEqual(copyBook.Name, _bookInformation.BookName);
            Assert.AreEqual(copyBook.InternationalStandardBookNumber, _bookInformation.BookNumber);
            Assert.AreEqual(copyBook.PublicationItem, _bookInformation.BookPublicationItem);
            Assert.AreEqual(copyBook.Author, _bookInformation.BookAuthor);
            Assert.AreEqual(copyBook.ImagePath, _bookInformation.BookImagePath);
            Assert.AreEqual(false, copyBook == ((BookItem)_privateObject.GetFieldOrProperty("_bookItem")).Book);
            Assert.AreEqual(true, book.Name == _bookInformation.SourceBookName);
        }
    }
}