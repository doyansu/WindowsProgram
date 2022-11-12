using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel.BindingListObject;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels.Tests
{
    [TestClass()]
    public class BookBorrowingFormPresentationModelTests
    {
        BookBorrowingFormPresentationModel _bookBorrowingFormPresentationModel;
        PrivateObject _privateObject;


        List<BookItem> _bookItems;
        Book _book;
        BookInformation _bookInformation;

        Library _model;

        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _privateObject = new PrivateObject(_model);
            _bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            _book = _bookItems[0].Book;
            _model.SelectBook(_book.Name);
            _bookInformation = _model.GetSelectedBookInformation();

            _bookBorrowingFormPresentationModel = new BookBorrowingFormPresentationModel(_model);
            _privateObject = new PrivateObject(_bookBorrowingFormPresentationModel);
        }

        // TestBookBorrowingFormPresentationModel
        [TestMethod()]
        public void TestBookBorrowingFormPresentationModel()
        {
            Assert.AreEqual(_model, _bookBorrowingFormPresentationModel.Model);
            Assert.AreEqual(null, _bookBorrowingFormPresentationModel.SelectedBookInformation);
            Assert.AreEqual("", _bookBorrowingFormPresentationModel.SelectedBookName);
            Assert.AreEqual("", _bookBorrowingFormPresentationModel.SelectedBookFormatInformation);
            Assert.AreEqual(-1, _bookBorrowingFormPresentationModel.SelectedBookQuantity);
            Assert.AreEqual("剩餘數量 : ", _bookBorrowingFormPresentationModel.SelectedBookQuantityString);
        }

        // TestSelectedBookInformation
        [TestMethod()]
        public void TestSelectedBookInformation()
        {
            const string NEW_VALUE = "NEW";
            _bookBorrowingFormPresentationModel.SelectedBookInformation = _bookInformation;
            Assert.AreEqual(_bookInformation, _bookBorrowingFormPresentationModel.SelectedBookInformation);
            Assert.AreEqual(_book.Name, _bookBorrowingFormPresentationModel.SelectedBookName);
            Assert.AreEqual(_book.GetFormatInformation(), _bookBorrowingFormPresentationModel.SelectedBookFormatInformation);
            Assert.AreEqual(_bookInformation.BookQuantity, _bookBorrowingFormPresentationModel.SelectedBookQuantity);
            Assert.AreEqual("剩餘數量 : " + _bookInformation.BookQuantity, _bookBorrowingFormPresentationModel.SelectedBookQuantityString);

            _bookBorrowingFormPresentationModel.SelectedBookInformation.BookName = NEW_VALUE;
            Assert.AreEqual(_bookInformation, _bookBorrowingFormPresentationModel.SelectedBookInformation);
            Assert.AreEqual(_book.Name, _bookBorrowingFormPresentationModel.SelectedBookName);
            Assert.AreEqual(_book.GetFormatInformation(), _bookBorrowingFormPresentationModel.SelectedBookFormatInformation);
            Assert.AreEqual(_bookInformation.BookQuantity, _bookBorrowingFormPresentationModel.SelectedBookQuantity);
            Assert.AreEqual("剩餘數量 : " + _bookInformation.BookQuantity, _bookBorrowingFormPresentationModel.SelectedBookQuantityString);

        }

        // TestUnselectBook
        [TestMethod()]
        public void TestUnselectBook()
        {
            _bookBorrowingFormPresentationModel.UnselectBook();
            Assert.AreEqual(null, _bookBorrowingFormPresentationModel.SelectedBookInformation);
            Assert.AreEqual("", _bookBorrowingFormPresentationModel.SelectedBookName);
            Assert.AreEqual("", _bookBorrowingFormPresentationModel.SelectedBookFormatInformation);
            Assert.AreEqual(-1, _bookBorrowingFormPresentationModel.SelectedBookQuantity);
            Assert.AreEqual("剩餘數量 : ", _bookBorrowingFormPresentationModel.SelectedBookQuantityString);
        }

        // TestSelectedBookChanged
        [TestMethod()]
        public void TestSelectedBookChanged()
        {
            Action action = null;
            int test = 0;
            _bookBorrowingFormPresentationModel._selectedBookChanged += action;
            _privateObject.Invoke("SelectedBookChanged");
            Assert.AreEqual(0, test);

            action += () => {
                test = 1;
            };
            _bookBorrowingFormPresentationModel._selectedBookChanged += action;
            _privateObject.Invoke("SelectedBookChanged");
            Assert.AreEqual(1, test);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string[] notifyList = (string[])_privateObject.GetFieldOrProperty("_notifyList");
            _privateObject.Invoke("NotifyPropertyChanged");
            Assert.AreEqual(0, receivedEvents.Count);
            _bookBorrowingFormPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged");
            foreach (string propertyName in notifyList)
                Assert.AreEqual(true, receivedEvents.Contains(propertyName));
        }
    }
}