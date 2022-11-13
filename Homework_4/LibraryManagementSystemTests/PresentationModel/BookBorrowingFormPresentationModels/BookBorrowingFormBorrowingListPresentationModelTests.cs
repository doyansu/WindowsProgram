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
        Book _book;
        BookItem _bookItem;
        BookInformation _bookInformation;

        Library _model;
        BookBorrowingFormPresentationModel _presentationModel;

        const string CATEGORY = "6月暢銷書";
        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _privateObject = new PrivateObject(_model);
            _bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            _bookItem = _bookItems[0];
            _book = _bookItem.Book;
            _bookInformation = new BookInformation(_bookItem, CATEGORY);

            _presentationModel = new BookBorrowingFormPresentationModel(_model);

            _bookBorrowingFormBorrowingListPresentationModel = new BookBorrowingFormBorrowingListPresentationModel(_presentationModel);
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

        // TestGetBookQuantityCount
        [TestMethod()]
        public void TestGetBookQuantityCount()
        {
            Assert.AreEqual(0, _privateObject.Invoke("GetBookQuantityCount"));
            _borrowingList.Add(new BorrowingListRow(_bookInformation));
            Assert.AreEqual(1, _privateObject.Invoke("GetBookQuantityCount"));
            for(int i = 0; i < 3; i++)
            {
                BorrowingListRow borrowingListRow = new BorrowingListRow(_bookInformation);
                borrowingListRow.BorrowingCount = 2;
                _borrowingList.Add(borrowingListRow);
            }
            Assert.AreEqual(7, _privateObject.Invoke("GetBookQuantityCount"));
        }

        // TestRefreshBorrowingList
        [TestMethod()]
        public void TestRefreshBorrowingList()
        {
            const string NEW_NAME = "new name";
            BorrowingListRow borrowingListRow = new BorrowingListRow(_bookInformation);
            _borrowingList.Add(borrowingListRow);
            _book.Name = NEW_NAME;
            _privateObject.Invoke("RefreshBorrowingList");
            Assert.AreEqual(NEW_NAME, borrowingListRow.BookName);
        }

        // TestChangeBorrowingCount
        [TestMethod()]
        public void TestChangeBorrowingCount()
        {
            _borrowingList.Add(new BorrowingListRow(_bookInformation));
            Assert.AreEqual(-1, _privateObject.Invoke("ChangeBorrowingCount", new object[] { -1, 2 }));
            Assert.AreEqual(1, _borrowingList[0].BorrowingCount);
            Assert.AreEqual(-1, _privateObject.Invoke("ChangeBorrowingCount", new object[] { 20, 2 }));
            Assert.AreEqual(1, _borrowingList[0].BorrowingCount);
            Assert.AreEqual(-1, _privateObject.Invoke("ChangeBorrowingCount", new object[] { 0, -2 }));
            Assert.AreEqual(1, _borrowingList[0].BorrowingCount);
            Assert.AreEqual(2, _privateObject.Invoke("ChangeBorrowingCount", new object[] { 0, 2 }));
            Assert.AreEqual(2, _borrowingList[0].BorrowingCount);
            Assert.AreEqual(1, _privateObject.Invoke("ChangeBorrowingCount", new object[] { 0, 1 }));
            Assert.AreEqual(1, _borrowingList[0].BorrowingCount);
        }

        // TestClickAddBookButton
        [TestMethod()]
        public void TestClickAddBookButton()
        {
            Assert.AreEqual(false, _bookBorrowingFormBorrowingListPresentationModel.IsAddBookButtonEnabled);
            _presentationModel.SelectedBookInformation = _bookInformation;
            Assert.AreEqual(true, _bookBorrowingFormBorrowingListPresentationModel.IsAddBookButtonEnabled);

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, _borrowingList.Count);
                Assert.AreEqual("借書數量 : " + i, _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
                _bookBorrowingFormBorrowingListPresentationModel.ClickAddBookButton();
                Assert.AreEqual(i + 1, _borrowingList.Count);
                Assert.AreEqual("借書數量 : " + (i + 1), _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
                Assert.AreEqual(true, _bookBorrowingFormBorrowingListPresentationModel.IsConfirmBorrowingButtonEnabled);
            }
            _bookBorrowingFormBorrowingListPresentationModel.ClickAddBookButton();
            Assert.AreEqual(5, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 5", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(1, _receivedEvents.Count);
            Assert.AreEqual("每次借書限借五本，您的借書單已滿", _receivedEvents[0][0]);
            Assert.AreEqual("借書違規", _receivedEvents[0][1]);
            _bookBorrowingFormBorrowingListPresentationModel.ClickAddBookButton();
            Assert.AreEqual(5, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 5", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(2, _receivedEvents.Count);
            Assert.AreEqual("每次借書限借五本，您的借書單已滿", _receivedEvents[0][0]);
            Assert.AreEqual("借書違規", _receivedEvents[0][1]);
        }

        // TestClickDataGridView1CellContent
        [TestMethod()]
        public void TestClickDataGridView1CellContent()
        {
            BorrowingListRow borrowingListRow1 = new BorrowingListRow(_bookInformation);
            BorrowingListRow borrowingListRow2 = new BorrowingListRow(_bookInformation);
            _borrowingList.Add(borrowingListRow1);
            _borrowingList.Add(borrowingListRow2);
            Assert.AreEqual("借書數量 : 2", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            _bookBorrowingFormBorrowingListPresentationModel.ClickDataGridView1CellContent(-1);
            Assert.AreEqual(2, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 2", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            _bookBorrowingFormBorrowingListPresentationModel.ClickDataGridView1CellContent(20);
            Assert.AreEqual(2, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 2", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);

            _bookBorrowingFormBorrowingListPresentationModel.ClickDataGridView1CellContent(1);
            Assert.AreEqual(1, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 1", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(true, _borrowingList.Contains(borrowingListRow1));
            Assert.AreEqual(false, _borrowingList.Contains(borrowingListRow2));

            _borrowingList.Add(borrowingListRow2);
            _bookBorrowingFormBorrowingListPresentationModel.ClickDataGridView1CellContent(0);
            Assert.AreEqual(1, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 1", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(false, _borrowingList.Contains(borrowingListRow1));
            Assert.AreEqual(true, _borrowingList.Contains(borrowingListRow2));
        }

        // TestClickConfirmBorrowingButton
        [TestMethod()]
        public void TestClickConfirmBorrowingButton()
        {
            int messageIndex = 0;
            _bookBorrowingFormBorrowingListPresentationModel.ClickConfirmBorrowingButton();
            Assert.AreEqual(messageIndex + 1, _receivedEvents.Count);
            Assert.AreEqual("借書違規", _receivedEvents[messageIndex][0]);
            Assert.AreEqual("借書結果", _receivedEvents[messageIndex][1]);
            Assert.AreEqual(0, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 0", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(false, _bookBorrowingFormBorrowingListPresentationModel.IsConfirmBorrowingButtonEnabled);

            _borrowingList.Add(new BorrowingListRow(_bookInformation));
            messageIndex++;
            _bookBorrowingFormBorrowingListPresentationModel.ClickConfirmBorrowingButton();
            Assert.AreEqual(messageIndex + 1, _receivedEvents.Count);
            Assert.AreEqual("[微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書] 1本\n\n已成功借出!", _receivedEvents[messageIndex][0]);
            Assert.AreEqual("借書結果", _receivedEvents[messageIndex][1]);
            Assert.AreEqual(0, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 0", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(false, _bookBorrowingFormBorrowingListPresentationModel.IsConfirmBorrowingButtonEnabled);

            BorrowingListRow borrowingListRow = new BorrowingListRow(_bookInformation);
            borrowingListRow.BorrowingCount = 2;
            _borrowingList.Add(new BorrowingListRow(_bookInformation));
            _borrowingList.Add(borrowingListRow);
            messageIndex++;
            _bookBorrowingFormBorrowingListPresentationModel.ClickConfirmBorrowingButton();
            Assert.AreEqual(messageIndex + 1, _receivedEvents.Count);
            Assert.AreEqual("[微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書] 1本 、 [微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書] 2本\n\n已成功借出!", _receivedEvents[messageIndex][0]);
            Assert.AreEqual("借書結果", _receivedEvents[messageIndex][1]);
            Assert.AreEqual(0, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 0", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
            Assert.AreEqual(false, _bookBorrowingFormBorrowingListPresentationModel.IsConfirmBorrowingButtonEnabled);
        }

        // TestBookBorrowingFromClosing
        [TestMethod()]
        public void TestBookBorrowingFromClosing()
        {
            _borrowingList.Add(new BorrowingListRow(_bookInformation));
            _bookBorrowingFormBorrowingListPresentationModel.BookBorrowingFromClosing();
            Assert.AreEqual(0, _borrowingList.Count);
            Assert.AreEqual("借書數量 : 0", _bookBorrowingFormBorrowingListPresentationModel.BorrowingListQuantityString);
        }

        // TestChangeCellValue
        [TestMethod()]
        public void TestChangeCellValue()
        {
            int messageIndex = 0;
            for (int i = 0; i < 5; i++)
                _borrowingList.Add(new BorrowingListRow(_bookInformation));
            _bookBorrowingFormBorrowingListPresentationModel.ChangeCellValue(-1, 10);
            _bookBorrowingFormBorrowingListPresentationModel.ChangeCellValue(20, 10);
            Assert.AreEqual(0, _receivedEvents.Count);

            _bookBorrowingFormBorrowingListPresentationModel.ChangeCellValue(0, 10);
            Assert.AreEqual(3, _receivedEvents.Count);
            Assert.AreEqual("該書本剩餘數量不足", _receivedEvents[messageIndex][0]);
            Assert.AreEqual("庫存狀態", _receivedEvents[messageIndex][1]);
            messageIndex++;
            Assert.AreEqual("同一本書一次限借2本", _receivedEvents[messageIndex][0]);
            Assert.AreEqual("借書違規", _receivedEvents[messageIndex][1]);
            messageIndex++;
            Assert.AreEqual("每次借書限借五本，您的借書單已滿", _receivedEvents[messageIndex][0]);
            Assert.AreEqual("借書違規", _receivedEvents[messageIndex][1]);
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