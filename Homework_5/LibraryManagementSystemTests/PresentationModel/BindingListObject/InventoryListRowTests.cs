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
    public class InventoryListRowTests
    {
        InventoryListRow _inventoryListRow;
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
            _inventoryListRow = new InventoryListRow(_bookInformation);
            _privateObject = new PrivateObject(_inventoryListRow);
        }

        // TestInventoryListRow
        [TestMethod()]
        public void TestInventoryListRow()
        {
            Assert.AreEqual(_bookInformation.BookName, _inventoryListRow.BookName);
            Assert.AreEqual(_bookInformation.BookImagePath, _inventoryListRow.BookImagePath);
            Assert.AreEqual(_bookInformation.BookFormatInformation, _inventoryListRow.BookFormatInformation);
            Assert.AreEqual(CATEGORY, _inventoryListRow.BookCategory);
            Assert.AreEqual(QUANTITY, _inventoryListRow.BookQuantity);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            _privateObject.Invoke("NotifyPropertyChanged", "");
            _inventoryListRow.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
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