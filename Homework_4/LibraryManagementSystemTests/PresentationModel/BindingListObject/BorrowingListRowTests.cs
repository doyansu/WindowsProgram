using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.PresentationModel.BindingListObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using System.ComponentModel;

namespace LibraryManagementSystem.PresentationModel.BindingListObject.Tests
{
    [TestClass()]
    public class BorrowingListRowTests
    {
        BorrowingListRow _borrowingListRow;
        PrivateObject _privateObject;

        Book _book;
        BookItem _bookItem;
        BookInformation _bookInformation;

        const int QUANTITY = 1;
        const string CATEGORY = "6月暢銷書";
        readonly string[] _bookInformationList = {
            "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]",
            "../../../image/1.jpg" };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            
            _book = new Book(_bookInformationList[0], _bookInformationList[1], _bookInformationList[2], _bookInformationList[3], _bookInformationList[4]);
            _bookItem = new BookItem(_book, QUANTITY);
            _bookInformation = new BookInformation(_bookItem, CATEGORY);
            _borrowingListRow = new BorrowingListRow(_bookInformation);
            _privateObject = new PrivateObject(_borrowingListRow);
        }

        // TestBorrowingListRow
        [TestMethod()]
        public void TestBorrowingListRow()
        {
            Assert.AreEqual(_bookInformation.BookName, _borrowingListRow.BookName);
            Assert.AreEqual(_bookInformation.BookAuthor, _borrowingListRow.BookAuthor);
            Assert.AreEqual(_bookInformation.BookPublicationItem, _borrowingListRow.BookPublicationItem);
            Assert.AreEqual(_bookInformation.BookNumber, _borrowingListRow.BookNumber);
            Assert.AreEqual(1, _borrowingListRow.BorrowingCount);

            const int NEW_RETURN_COUNT = 2;
            _borrowingListRow.BorrowingCount = NEW_RETURN_COUNT;
            Assert.AreEqual(NEW_RETURN_COUNT, _borrowingListRow.BorrowingCount);
        }

        // TestRefresh
        [TestMethod()]
        public void TestRefresh()
        {
            List<string> changeList = new List<string>();
            for (int i = 0; i < 5; i++)
                changeList.Add(i.ToString());

            _book.Name = changeList[0];
            _book.InternationalStandardBookNumber = changeList[1];
            _book.Author = changeList[2];
            _book.PublicationItem = changeList[3];
            _book.ImagePath = changeList[4];

            Assert.AreEqual(_bookInformation.BookName, _borrowingListRow.BookName);
            Assert.AreEqual(_bookInformation.BookAuthor, _borrowingListRow.BookAuthor);
            Assert.AreEqual(_bookInformation.BookPublicationItem, _borrowingListRow.BookPublicationItem);
            Assert.AreEqual(_bookInformation.BookNumber, _borrowingListRow.BookNumber);

            _borrowingListRow.Refresh();

            Assert.AreEqual(_book.Name, _borrowingListRow.BookName);
            Assert.AreEqual(_book.Author, _borrowingListRow.BookAuthor);
            Assert.AreEqual(_book.PublicationItem, _borrowingListRow.BookPublicationItem);
            Assert.AreEqual(_book.InternationalStandardBookNumber, _borrowingListRow.BookNumber);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string[] notifyList = (string[])_privateObject.GetFieldOrProperty("_notifyList");
            _privateObject.Invoke("NotifyPropertyChanged");
            _borrowingListRow.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged");
            foreach (string propertyName in notifyList)
                Assert.AreEqual(true, receivedEvents.Contains(propertyName));
        }
    }
}