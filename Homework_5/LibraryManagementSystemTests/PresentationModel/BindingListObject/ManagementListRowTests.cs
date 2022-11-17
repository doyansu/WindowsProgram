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
    public class ManagementListRowTests
    {
        ManagementListRow _managementListRow;
        PrivateObject _privateObject;

        Book _book;
        BookItem _bookItem;
        BookInformation _bookInformation;

        const int QUANTITY = 1;
        const string CATEGORY = "6月暢銷書";
        const string NEW_CATEGORY = "4月暢銷書";
        readonly string[] _bookInformationList = {
            "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]",
            "../../../image/1.jpg" };

        readonly string[] _bookInformationChangeList = {
            "微調有差",
            "964",
            "ingectar",
            "原點",
            "../../../image/2.jpg" };

        readonly string[] _notifyList = {
            "",
            "notify"
        };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {

            _book = new Book(_bookInformationList[0], _bookInformationList[1], _bookInformationList[2], _bookInformationList[3], _bookInformationList[4]);
            _bookItem = new BookItem(_book, QUANTITY);
            _bookInformation = new BookInformation(_bookItem, CATEGORY);
            _managementListRow = new ManagementListRow(_bookInformation);
            _privateObject = new PrivateObject(_managementListRow);
        }

        // TestManagementListRow
        [TestMethod()]
        public void TestManagementListRow()
        {
            Assert.AreEqual(_bookInformation.BookName, _managementListRow.BookName);
            Assert.AreEqual(_bookInformation.BookAuthor, _managementListRow.BookAuthor);
            Assert.AreEqual(_bookInformation.BookPublicationItem, _managementListRow.BookPublicationItem);
            Assert.AreEqual(_bookInformation.BookNumber, _managementListRow.BookInternationalStandardBookNumber);
            Assert.AreEqual(_bookInformation.BookImagePath, _managementListRow.BookImagePath);
            Assert.AreEqual(_bookInformation.BookName, _managementListRow.SourceBookName);
            Assert.AreEqual(_bookInformation, _managementListRow.BookInformationObject);
            Assert.AreEqual(CATEGORY, _managementListRow.BookCategory);
            Assert.AreEqual(false, _managementListRow.IsStoreAble);
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
        }

        // TestContentFull
        [TestMethod()]
        public void TestContentFull()
        {
            const string NOT_NULL = "NOT_NULL";
            _managementListRow.BookName = "";
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookName = NOT_NULL;

            _managementListRow.BookAuthor = "";
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookAuthor = NOT_NULL;

            _managementListRow.BookPublicationItem = "";
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookPublicationItem = NOT_NULL;

            _managementListRow.BookInternationalStandardBookNumber = "";
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookInternationalStandardBookNumber = NOT_NULL;

            _managementListRow.BookImagePath = "";
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookImagePath = NOT_NULL;

            _managementListRow.BookCategory = "";
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookCategory = NOT_NULL;

            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
        }

        // TestIsStoreAble
        [TestMethod()]
        public void TestIsStoreAble()
        {
            _managementListRow.BookName = _bookInformationChangeList[0];
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            _managementListRow.BookName = _bookInformationList[0];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));

            _managementListRow.BookInternationalStandardBookNumber = _bookInformationChangeList[1];
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            _managementListRow.BookInternationalStandardBookNumber = _bookInformationList[1];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));

            _managementListRow.BookAuthor = _bookInformationChangeList[2];
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            _managementListRow.BookAuthor = _bookInformationList[2];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));

            _managementListRow.BookPublicationItem = _bookInformationChangeList[3];
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            _managementListRow.BookPublicationItem = _bookInformationList[3];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));

            _managementListRow.BookImagePath = _bookInformationChangeList[4];
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            _managementListRow.BookImagePath = _bookInformationList[4];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));

            _managementListRow.BookCategory = NEW_CATEGORY;
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            _managementListRow.BookCategory = CATEGORY;
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));

            _managementListRow.BookName = "";
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
        }

        // TestSetPropertyNotChange
        [TestMethod()]
        public void TestSetPropertyNotChange()
        {
            _managementListRow.BookName = _bookInformationList[0];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookInternationalStandardBookNumber = _bookInformationList[1];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookAuthor = _bookInformationList[2];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookPublicationItem = _bookInformationList[3];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookImagePath = _bookInformationList[4];
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
            _managementListRow.BookCategory = CATEGORY;
            Assert.AreEqual(false, (bool)_privateObject.GetFieldOrProperty("IsStoreAble"));
            Assert.AreEqual(true, (bool)_privateObject.GetFieldOrProperty("ContentFull"));
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            _privateObject.Invoke("NotifyPropertyChanged", "");
            _managementListRow.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
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