using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model.Tests
{
    [TestClass()]
    public class BorrowedBookInformationTests
    {

        Book _book;
        BookItem _bookItem;
        BorrowedItem _borrowedItem;
        BorrowedBookInformation _borrowedBookInformation;
        const int DUE_DAYS = 30;
        readonly string[] bookInformationList = {
            "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]",
            "../../../image/1.jpg" };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book(bookInformationList[0], bookInformationList[1], bookInformationList[2], bookInformationList[3], bookInformationList[4]);
            _bookItem = new BookItem(_book, 0);
            _borrowedItem = new BorrowedItem(_bookItem);
        }

        // TestBorrowedBookInformation
        [TestMethod()]
        public void TestBorrowedBookInformation()
        {
            _borrowedBookInformation = new BorrowedBookInformation(_borrowedItem);

            Assert.AreEqual(_bookItem.Quantity, _borrowedBookInformation.BookQuantity);
            Assert.AreEqual(_book.Name, _borrowedBookInformation.BookName);
            Assert.AreEqual(_book.InternationalStandardBookNumber, _borrowedBookInformation.BookNumber);
            Assert.AreEqual(_book.PublicationItem, _borrowedBookInformation.BookPublicationItem);
            Assert.AreEqual(_book.Author, _borrowedBookInformation.BookAuthor);
            Assert.AreEqual(_book.GetFormatInformation(), _borrowedBookInformation.BookFormatInformation);
            Assert.AreEqual(_borrowedItem.Date, _borrowedBookInformation.BorrowingDate);
            Assert.AreEqual(_borrowedItem.ReturnDue, _borrowedBookInformation.ReturnDue);
        }
    }
}