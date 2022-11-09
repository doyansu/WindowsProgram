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
    public class BackPackListRowTests
    {
        BackPackListRow _backPackListRow;
        BookInformation _bookInformation;
        BorrowedItem _borrowedItem;
        PrivateObject _privateObject;

        const int QUANTITY = 1;
        const string CATEGORY = "6月暢銷書";
        readonly string[] _bookInformationList = {
            "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]",
            "../../../image/1.jpg" };

        readonly string[] _notifyList = {
            "",
            "notify"
        };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            Book book;
            BookItem bookItem;
            book = new Book(_bookInformationList[0], _bookInformationList[1], _bookInformationList[2], _bookInformationList[3], _bookInformationList[4]);
            bookItem = new BookItem(book, QUANTITY);
            _borrowedItem = new BorrowedItem(bookItem);
            _bookInformation = new BookInformation(bookItem, CATEGORY);
            _backPackListRow = new BackPackListRow(new BorrowedBookInformation(_borrowedItem));
            _privateObject = new PrivateObject(_backPackListRow);
        }

        // TestBackPackListRow
        [TestMethod()]
        public void TestBackPackListRow()
        {
            Assert.AreEqual(_bookInformation.BookName, _backPackListRow.BookName);
            Assert.AreEqual(_bookInformation.BookAuthor, _backPackListRow.BookAuthor);
            Assert.AreEqual(_bookInformation.BookPublicationItem, _backPackListRow.BookPublicationItem);
            Assert.AreEqual(_bookInformation.BookNumber, _backPackListRow.BookNumber);
            Assert.AreEqual(_borrowedItem.BookItem.Quantity, _backPackListRow.BorrowedCount);
            Assert.AreEqual(_borrowedItem.Date.ToShortDateString(), _backPackListRow.BorrowingDate);
            Assert.AreEqual(_borrowedItem.ReturnDue.ToShortDateString(), _backPackListRow.ReturnDue);
            Assert.AreEqual(1, _backPackListRow.ReturnCount);

            const int NEW_RETURN_COUNT = 2;
            _backPackListRow.ReturnCount = NEW_RETURN_COUNT;
            Assert.AreEqual(NEW_RETURN_COUNT, _backPackListRow.ReturnCount);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            _privateObject.Invoke("NotifyPropertyChanged", "");
            _backPackListRow.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            foreach (string propertyName in _notifyList)
                _privateObject.Invoke("NotifyPropertyChanged", propertyName);
            for (int i = 0; i < _notifyList.Count(); i++)
                Assert.AreEqual(_notifyList[i], receivedEvents[i]);
        }
    }
}