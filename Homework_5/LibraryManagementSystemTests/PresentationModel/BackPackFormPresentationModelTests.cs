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
    public class BackPackFormPresentationModelTests
    {
        PrivateObject _privateObject;
        BackPackFormPresentationModel _backPackFormPresentationModel;
        List<List<string>> _receivedEvents = new List<List<string>>();
        Action<string, string> _showMessage;

        Library _model;
        List<BookItem> _bookItems;
        BorrowedList _borrowedLists;
        BindingList<BackPackListRow> _backPackListRows;

        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _privateObject = new PrivateObject(_model);

            _bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            _borrowedLists = new BorrowedList();
            foreach (BookItem bookItem in _bookItems)
                _borrowedLists.Add(new BorrowedItem(bookItem.Copy()));
            _privateObject.SetFieldOrProperty("_borrowedList", _borrowedLists);

            _backPackFormPresentationModel = new BackPackFormPresentationModel(_model);
            _privateObject = new PrivateObject(_backPackFormPresentationModel);
            _backPackListRows = (BindingList<BackPackListRow>)_backPackFormPresentationModel.BackPackList;
            _receivedEvents = new List<List<string>>();

            _showMessage = (message, title) =>
            {
                List<string> temp = new List<string>();
                temp.Add(message);
                temp.Add(title);
                _receivedEvents.Add(temp);
            };
            _backPackFormPresentationModel._showMessage += _showMessage;
        }

        // TestBackPackFormPresentationModel
        [TestMethod()]
        public void TestBackPackFormPresentationModel()
        {
            Assert.AreEqual(_model, (Library)_privateObject.GetFieldOrProperty("_model"));
            Assert.AreEqual(_borrowedLists.Count, _backPackListRows.Count);
        }

        // TestUpdateBackPackList
        [TestMethod()]
        public void TestUpdateBackPackList()
        {
            _privateObject.Invoke("UpdateBackPackList");
            Assert.AreEqual(_borrowedLists.Count, _backPackListRows.Count);
        }

        // TestClickDataGridView1CellContent
        [TestMethod()]
        public void TestClickDataGridView1CellContent()
        {
            int tempCount = _backPackListRows.Count;

            _backPackFormPresentationModel.ClickDataGridView1CellContent(-1);
            Assert.AreEqual(tempCount, _backPackListRows.Count);
            Assert.AreEqual(0, _receivedEvents.Count);

            _backPackFormPresentationModel.ClickDataGridView1CellContent(9999);
            Assert.AreEqual(tempCount, _backPackListRows.Count);
            Assert.AreEqual(0, _receivedEvents.Count);

            int returnCount = _backPackListRows[0].ReturnCount;
            int borrowedCount = _backPackListRows[0].BorrowedCount;
            string returnName = _backPackListRows[0].BookName;
            int messageCount = 0;

            _backPackFormPresentationModel.ClickDataGridView1CellContent(0);
            messageCount++;
            Assert.AreEqual(borrowedCount - returnCount, _borrowedLists.GetBookItemAt(0).Quantity);
            Assert.AreEqual(messageCount, _receivedEvents.Count);
            Assert.AreEqual(2, _receivedEvents[messageCount - 1].Count);
            Assert.AreEqual(string.Format("[{0}] 已成功歸還{1}本", returnName, returnCount), _receivedEvents[messageCount - 1][0]);
            Assert.AreEqual("歸還結果", _receivedEvents[messageCount - 1][1]);

            returnCount = _backPackListRows[0].ReturnCount = _backPackListRows[0].BorrowedCount;
            _backPackFormPresentationModel.ClickDataGridView1CellContent(0);
            messageCount++;
            Assert.AreEqual(tempCount - 1, _backPackListRows.Count);
            Assert.AreEqual(messageCount, _receivedEvents.Count);
            Assert.AreEqual(2, _receivedEvents[messageCount - 1].Count);
            Assert.AreEqual(string.Format("[{0}] 已成功歸還{1}本", returnName, returnCount), _receivedEvents[messageCount - 1][0]);
            Assert.AreEqual("歸還結果", _receivedEvents[messageCount - 1][1]);
        }

        // TestChangeCellValue
        [TestMethod()]
        public void TestChangeCellValue()
        {
            int borrowedCount = _backPackListRows[0].BorrowedCount;
            int messageCount = 0;

            _backPackListRows[0].ReturnCount = 1;
            _backPackFormPresentationModel.ChangeCellValue(0);
            Assert.AreEqual(1, _backPackListRows[0].ReturnCount);
            Assert.AreEqual(messageCount, _receivedEvents.Count);

            _backPackListRows[0].ReturnCount = 0;
            _backPackFormPresentationModel.ChangeCellValue(0);
            messageCount++;
            Assert.AreEqual(1, _backPackListRows[0].ReturnCount);
            Assert.AreEqual(messageCount, _receivedEvents.Count);
            Assert.AreEqual(2, _receivedEvents[messageCount - 1].Count);
            Assert.AreEqual("您至少要歸還1本書", _receivedEvents[messageCount - 1][0]);
            Assert.AreEqual("還書錯誤", _receivedEvents[messageCount - 1][1]);

            _backPackListRows[0].ReturnCount = -1;
            _backPackFormPresentationModel.ChangeCellValue(0);
            messageCount++;
            Assert.AreEqual(1, _backPackListRows[0].ReturnCount);
            Assert.AreEqual(messageCount, _receivedEvents.Count);
            Assert.AreEqual(2, _receivedEvents[messageCount - 1].Count);
            Assert.AreEqual("您至少要歸還1本書", _receivedEvents[messageCount - 1][0]);
            Assert.AreEqual("還書錯誤", _receivedEvents[messageCount - 1][1]);

            _backPackListRows[0].ReturnCount = borrowedCount + 1;
            _backPackFormPresentationModel.ChangeCellValue(0);
            messageCount++;
            Assert.AreEqual(borrowedCount, _backPackListRows[0].ReturnCount);
            Assert.AreEqual(messageCount, _receivedEvents.Count);
            Assert.AreEqual(2, _receivedEvents[messageCount - 1].Count);
            Assert.AreEqual("還書數量不能超過已借數量", _receivedEvents[messageCount - 1][0]);
            Assert.AreEqual("還書錯誤", _receivedEvents[messageCount - 1][1]);
        }

        // TestShowMessage
        [TestMethod()]
        public void TestShowMessage()
        {
            const string MESSAGE = "message";
            const string TITLE = "title";

            _backPackFormPresentationModel._showMessage -= _showMessage;

            _privateObject.Invoke("ShowMessage", new object[] { MESSAGE, TITLE });
            Assert.AreEqual(0, _receivedEvents.Count);

            _backPackFormPresentationModel._showMessage += _showMessage;

            _privateObject.Invoke("ShowMessage", new object[] { null, TITLE });
            Assert.AreEqual(0, _receivedEvents.Count);

            _privateObject.Invoke("ShowMessage", new object[] { MESSAGE, TITLE });
            Assert.AreEqual(1, _receivedEvents.Count);
            Assert.AreEqual(2, _receivedEvents[0].Count);
            Assert.AreEqual(MESSAGE, _receivedEvents[0][0]);
            Assert.AreEqual(TITLE, _receivedEvents[0][1]);
        }
    }
}