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
    public class BorrowedItemTests
    {
        Book _book;
        BookItem _bookItem;
        BorrowedItem _borrowedItem;
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
        }

        // TestBorrowedItem
        [TestMethod()]
        public void TestBorrowedItem()
        {
            DateTime dateTime = DateTime.Now;
            _borrowedItem = new BorrowedItem(_bookItem);
            Assert.AreEqual(_book, _borrowedItem.Book);
            Assert.AreEqual(_bookItem, _borrowedItem.BookItem);
            Assert.AreEqual(dateTime, _borrowedItem.Date);
            Assert.AreEqual(dateTime.AddDays(DUE_DAYS).ToShortDateString(), _borrowedItem.ReturnDue.ToShortDateString());
        }
    }
}