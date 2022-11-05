using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tests
{
    [TestClass()]
    public class BookItemTests
    {
        Book _book;
        BookItem _bookItem;
        PrivateObject _bookItemPrivate;
        readonly string[] bookInformationList = {
            "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]" };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book(bookInformationList[0], bookInformationList[1], bookInformationList[2], bookInformationList[3]);
            _bookItem = new BookItem(_book, 0);
            _bookItemPrivate = new PrivateObject(_bookItem);
        }

        // Cosntrctor
        [TestMethod()]
        public void TestBookItem()
        {
            Assert.AreEqual(_book, _bookItem.Book);
            Assert.AreEqual(0, _bookItem.Quantity);

            _bookItem = new BookItem(_book, 99999);
            Assert.AreEqual(_book, _bookItem.Book);
            Assert.AreEqual(99999, _bookItem.Quantity);

            _bookItem = new BookItem(_book, -1);
            Assert.AreEqual(_book, _bookItem.Book);
            Assert.AreEqual(0, _bookItem.Quantity);
        }

        // TestCopy
        [TestMethod()]
        public void TestCopy()
        {
            BookItem bookItemCopy = _bookItem.Copy();
            Assert.AreEqual(_book, bookItemCopy.Book);
            Assert.AreEqual(0, bookItemCopy.Quantity);

            _bookItem.Quantity = 999;
            Assert.AreEqual(0, bookItemCopy.Quantity);
        }

        // TestTake
        [TestMethod()]
        public void TestTake()
        {
            BookItem bookItemTake = _bookItem.Take(-1);
            Assert.AreEqual(null, bookItemTake);

            bookItemTake = _bookItem.Take(0);
            Assert.AreEqual(_book, bookItemTake.Book);
            Assert.AreEqual(0, bookItemTake.Quantity);

            bookItemTake = _bookItem.Take(1);
            Assert.AreEqual(_book, bookItemTake.Book);
            Assert.AreEqual(0, bookItemTake.Quantity);

            _bookItem = new BookItem(_book, 100);
            bookItemTake = _bookItem.Take(87);
            Assert.AreEqual(_book, bookItemTake.Book);
            Assert.AreEqual(87, bookItemTake.Quantity);
            Assert.AreEqual(100 - 87, _bookItem.Quantity);
        }

        // TestAddQuantity
        [TestMethod()]
        public void TestAddQuantity()
        {
            BookItem otherBookItem = new BookItem(_book, 5);

            otherBookItem.AddQuantity(_bookItem);
            Assert.AreEqual(5, otherBookItem.Quantity);
            Assert.AreEqual(0, _bookItem.Quantity);

            _bookItem.AddQuantity(otherBookItem);
            Assert.AreEqual(5, otherBookItem.Quantity);
            Assert.AreEqual(5, _bookItem.Quantity);

            otherBookItem.Book = _book.Copy();

            otherBookItem.AddQuantity(_bookItem);
            Assert.AreEqual(5, otherBookItem.Quantity);
            Assert.AreEqual(5, _bookItem.Quantity);

            _bookItem.AddQuantity(otherBookItem);
            Assert.AreEqual(5, otherBookItem.Quantity);
            Assert.AreEqual(5, _bookItem.Quantity);
        }

        // TestIsBookEquals
        [TestMethod()]
        public void TestIsBookEquals()
        {
            BookItem otherBookItem = new BookItem(_book, 5);
            Assert.AreEqual(true, _bookItem.IsBookEquals(otherBookItem));
            Assert.AreEqual(true, otherBookItem.IsBookEquals(_bookItem));

            otherBookItem.Book = _book.Copy();
            Assert.AreEqual(false, _bookItem.IsBookEquals(otherBookItem));
            Assert.AreEqual(false, otherBookItem.IsBookEquals(_bookItem));
        }

        // TestGetInformationList
        [TestMethod()]
        public void TestGetInformationList()
        {
            List<string> InformationList = _bookItem.GetInformationList();
            Assert.AreEqual(InformationList[0], _book.Name);
            Assert.AreEqual(InformationList[1], _bookItem.Quantity.ToString());
            Assert.AreEqual(InformationList[2], _book.InternationalStandardBookNumber);
            Assert.AreEqual(InformationList[3], _book.Author);
            Assert.AreEqual(InformationList[4], _book.PublicationItem);
        }
    }
}