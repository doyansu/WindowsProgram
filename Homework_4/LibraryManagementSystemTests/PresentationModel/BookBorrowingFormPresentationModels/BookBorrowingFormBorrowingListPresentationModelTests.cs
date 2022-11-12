using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel.BindingListObject;
using System.ComponentModel;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels.Tests
{
    [TestClass()]
    public class BookBorrowingFormBorrowingListPresentationModelTests
    {
        BookBorrowingFormBorrowingListPresentationModel _bookBorrowingFormBorrowingListPresentationModel;
        PrivateObject _privateObject;

        List<List<string>> _receivedEvents;
        Action<string, string> _showMessage;

        List<BookItem> _bookItems;
        BindingList<BorrowingListRow> _borrowingList;

        Library _model;

        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _privateObject = new PrivateObject(_model);
            _bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");

            _bookBorrowingFormBorrowingListPresentationModel = new BookBorrowingFormBorrowingListPresentationModel(new BookBorrowingFormPresentationModel(_model));
            _privateObject = new PrivateObject(_bookBorrowingFormBorrowingListPresentationModel);
            _borrowingList = (BindingList<BorrowingListRow>)_bookBorrowingFormBorrowingListPresentationModel.BorrowingList;
            
            _receivedEvents = new List<List<string>>();

            _showMessage = (message, title) =>
            {
                List<string> temp = new List<string>();
                temp.Add(message);
                temp.Add(title);
                _receivedEvents.Add(temp);
            };
            _bookBorrowingFormBorrowingListPresentationModel._showMessage += _showMessage;
        }

        // TestBookBorrowingFormBorrowingListPresentationModel
        [TestMethod()]
        public void TestBookBorrowingFormBorrowingListPresentationModel()
        {
            Assert.AreEqual(0, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 0", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(false, _bookBorrowingFormBorrowingListPresentationModel.IsAddBookButtonEnabled);
            Assert.AreEqual(false, _bookBorrowingFormBorrowingListPresentationModel.IsConfirmBorrowingButtonEnabled);
        }

        [TestMethod()]
        public void ClickAddBookButtonTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClickDataGridView1CellContentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClickConfirmBorrowingButtonTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BookBorrowingFromClosingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ChangeCellValueTest()
        {
            Assert.Fail();
        }

        // TestShowMessage
        [TestMethod()]
        public void TestShowMessage()
        {
            const string MESSAGE = "message";
            const string TITLE = "title";

            _bookBorrowingFormBorrowingListPresentationModel._showMessage -= _showMessage;

            _privateObject.Invoke("ShowMessage", new object[] { MESSAGE, TITLE });
            Assert.AreEqual(0, _receivedEvents.Count);

            _bookBorrowingFormBorrowingListPresentationModel._showMessage += _showMessage;

            _privateObject.Invoke("ShowMessage", new object[] { null, TITLE });
            Assert.AreEqual(0, _receivedEvents.Count);

            _privateObject.Invoke("ShowMessage", new object[] { MESSAGE, TITLE });
            Assert.AreEqual(1, _receivedEvents.Count);
            Assert.AreEqual(2, _receivedEvents[0].Count);
            Assert.AreEqual(MESSAGE, _receivedEvents[0][0]);
            Assert.AreEqual(TITLE, _receivedEvents[0][1]);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string[] notifyList = (string[])_privateObject.GetFieldOrProperty("_notifyList");
            _privateObject.Invoke("NotifyPropertyChanged");
            Assert.AreEqual(0, receivedEvents.Count);
            _bookBorrowingFormBorrowingListPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged");
            foreach (string propertyName in notifyList)
                Assert.AreEqual(true, receivedEvents.Contains(propertyName));
        }
    }
}