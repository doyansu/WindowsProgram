using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using System.ComponentModel;
using LibraryManagementSystem.PresentationModel.BindingListObject;

namespace LibraryManagementSystem.PresentationModel.Tests
{
    [TestClass()]
    public class BookInventoryFormPresentationModelTests
    {
        BookInventoryFormPresentationModel _inventoryFormPresentationModel;
        PrivateObject _privateObject;

        List<BookItem> _bookItems;
        BindingList<InventoryListRow> _inventoryList;

        Library _model;

        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _privateObject = new PrivateObject(_model);
            _bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            
            _inventoryFormPresentationModel = new BookInventoryFormPresentationModel(_model);
            _privateObject = new PrivateObject(_inventoryFormPresentationModel);
            _inventoryList = (BindingList<InventoryListRow>)_inventoryFormPresentationModel.InventoryList;
        }

        // TestBookInventoryFormPresentationModel
        [TestMethod()]
        public void TestBookInventoryFormPresentationModel()
        {
            Assert.AreEqual(_model, (Library)_privateObject.GetFieldOrProperty("_model"));
            Assert.AreEqual(_bookItems.Count, _inventoryList.Count);
            Assert.AreEqual(-1, _inventoryFormPresentationModel.SelectedRowIndex);
            Assert.AreEqual("", _inventoryFormPresentationModel.SelectedBookImage);
            Assert.AreEqual("", _inventoryFormPresentationModel.BookInformation);
        }

        // TestClickAddingButton
        [TestMethod()]
        public void TestClickAddingButton()
        {
            int addingCount = 1;
            int quantityTemp; 
            const string INFORMATION_FORMAT = "書籍名稱 : {0}\n\n書籍類別 : {1}\n庫存數量 : {2}";
            InventoryListRow inventoryListRow;

            _inventoryFormPresentationModel.SelectedRowIndex = -1;
            _inventoryFormPresentationModel.ClickAddingButton(addingCount);
            Assert.AreEqual("", _inventoryFormPresentationModel.SelectedBookImage);
            Assert.AreEqual("", _inventoryFormPresentationModel.BookInformation);

            _inventoryFormPresentationModel.SelectedRowIndex = 0;
            quantityTemp = _bookItems[_inventoryFormPresentationModel.SelectedRowIndex].Quantity;
            _inventoryFormPresentationModel.ClickAddingButton(addingCount);
            inventoryListRow = _inventoryList[_inventoryFormPresentationModel.SelectedRowIndex];

            Assert.AreEqual(quantityTemp + addingCount, inventoryListRow.BookQuantity);
            Assert.AreEqual(_bookItems[_inventoryFormPresentationModel.SelectedRowIndex].Book.ImagePath, _inventoryFormPresentationModel.SelectedBookImage);
            Assert.AreEqual(_bookItems[_inventoryFormPresentationModel.SelectedRowIndex].Book.GetFormatInformation(), _inventoryFormPresentationModel.BookInformation);
            Assert.AreEqual(string.Format(INFORMATION_FORMAT, inventoryListRow.BookName, inventoryListRow.BookCategory, quantityTemp + addingCount), _inventoryFormPresentationModel.BookItemInformation);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string[] notifyList = (string[])_privateObject.GetFieldOrProperty("_notifyList");
            _privateObject.Invoke("NotifyPropertyChanged");
            _inventoryFormPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged");
            foreach (string propertyName in notifyList)
                Assert.AreEqual(true, receivedEvents.Contains(propertyName));
        }

        // TestUseAction
        [TestMethod()]
        public void TestUseAction()
        {
            Action action = null;
            int test = 0;
            _privateObject.Invoke("UseAction", new object[] { action });
            Assert.AreEqual(0, test);

            action += () => {
                test = 1;
            };
            _privateObject.Invoke("UseAction", new object[] { action });
            Assert.AreEqual(1, test);
        }
    }
}