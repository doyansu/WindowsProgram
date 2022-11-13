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
    public class BookBorrowingFormButtonPresentationModelTests
    {
        BookBorrowingFormButtonPresentationModel _borrowingFormButtonPresentationModel;
        PrivateObject _privateObject;

        List<BookItem> _bookItems;
        List<List<TabPageButton>> _bookButtonList;
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

            _borrowingFormButtonPresentationModel = new BookBorrowingFormButtonPresentationModel(_presentationModel);
            _privateObject = new PrivateObject(_borrowingFormButtonPresentationModel);
            _bookButtonList = (List<List<TabPageButton>>)_privateObject.GetFieldOrProperty("_bookButtonList");
        }

        // TestBookBorrowingFormButtonPresentationModel
        [TestMethod()]
        public void TestBookBorrowingFormButtonPresentationModel()
        {
            Assert.AreEqual(true, _borrowingFormButtonPresentationModel.IsBackPackButtonEnabled);
            Assert.AreEqual(false, _borrowingFormButtonPresentationModel.IsLastButtonButtonEnabled);
            Assert.AreEqual(false, _borrowingFormButtonPresentationModel.IsNextButtonButtonEnabled); 
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(-1, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual("Page : 1 / 1", _borrowingFormButtonPresentationModel.PageLabelString);
        }

        // TestGetMaxTabPageIndex
        [TestMethod()]
        public void TestUpdateButtonsVisible()
        {
            const int TABPAGE_COUNT = 2;
            const int PER_PAGE_COUNT = 3;
            for (int i = 0; i < TABPAGE_COUNT; i++)
            {
                _bookButtonList.Add(new List<TabPageButton>());
                for (int j = 0; j < PER_PAGE_COUNT * i + 1; j++)
                    _bookButtonList[i].Add(new TabPageButton(_bookInformation));
            }

            _borrowingFormButtonPresentationModel.SelectedTabPageIndex = -1;
            _privateObject.Invoke("UpdateButtonsVisible");
            for (int i = 0; i < TABPAGE_COUNT; i++)
                for (int j = 0; j < PER_PAGE_COUNT * i + 1; j++)
                    Assert.AreEqual(false, _bookButtonList[i][j].IsVisible);

            _borrowingFormButtonPresentationModel.SelectedTabPageIndex = 1;
            _privateObject.Invoke("UpdateButtonsVisible");

            Assert.AreEqual(true, _bookButtonList[1][0].IsVisible);
            Assert.AreEqual(true, _bookButtonList[1][1].IsVisible);
            Assert.AreEqual(true, _bookButtonList[1][2].IsVisible);
        }

        // TestGetMaxTabPageIndex
        [TestMethod()]
        public void TestGetMaxTabPageIndex()
        {
            const int TABPAGE_COUNT = 2;
            const int PER_PAGE_COUNT = 3;
            for (int i = 0; i < TABPAGE_COUNT; i++)
            {
                _bookButtonList.Add(new List<TabPageButton>());
                for (int j = 0; j < PER_PAGE_COUNT * i + 1; j++)
                    _bookButtonList[i].Add(new TabPageButton(_bookInformation));
            }

            _borrowingFormButtonPresentationModel.SelectedTabPageIndex = -1;
            int result = (int)_privateObject.Invoke("GetMaxTabPageIndex");
            Assert.AreEqual(0, result);

            _borrowingFormButtonPresentationModel.SelectedTabPageIndex = 0;
            result = (int)_privateObject.Invoke("GetMaxTabPageIndex");
            Assert.AreEqual(0, result);

            _borrowingFormButtonPresentationModel.SelectedTabPageIndex = 1;
            result = (int)_privateObject.Invoke("GetMaxTabPageIndex");
            Assert.AreEqual(1, result);
        }

        // TestUpdateBookButtonList
        [TestMethod()]
        public void TestUpdateBookButtonList()
        {
            _borrowingFormButtonPresentationModel.UpdateBookButtonList();
            Assert.AreEqual(true, _borrowingFormButtonPresentationModel.IsBackPackButtonEnabled);
            Assert.AreEqual(false, _borrowingFormButtonPresentationModel.IsLastButtonButtonEnabled);
            Assert.AreEqual(true, _borrowingFormButtonPresentationModel.IsNextButtonButtonEnabled);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(0, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual("Page : 1 / 2", _borrowingFormButtonPresentationModel.PageLabelString);
        }

        // TestSelectBookButton
        [TestMethod()]
        public void TestSelectBookButton()
        {
            _bookButtonList.Add(new List<TabPageButton>());
            TabPageButton tabPageButton = new TabPageButton(_bookInformation);
            _bookButtonList[0].Add(tabPageButton);

            _borrowingFormButtonPresentationModel.SelectBookButton(-1, 0);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            _borrowingFormButtonPresentationModel.SelectBookButton(0, -1);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            _borrowingFormButtonPresentationModel.SelectBookButton(-1, -1);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            _borrowingFormButtonPresentationModel.SelectBookButton(10, 0);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            _borrowingFormButtonPresentationModel.SelectBookButton(0, 10);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            _borrowingFormButtonPresentationModel.SelectBookButton(10, 10);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(null, _borrowingFormButtonPresentationModel.BookButtonImage);
            _borrowingFormButtonPresentationModel.SelectBookButton(0, 0);
            Assert.AreEqual(tabPageButton, _borrowingFormButtonPresentationModel.BookButtonObject);
            Assert.AreEqual(tabPageButton.BookImagePath, _borrowingFormButtonPresentationModel.BookButtonImage);
        }

        // TestSelectBook
        [TestMethod()]
        public void TestSelectBook()
        {
            _bookButtonList.Add(new List<TabPageButton>());
            _bookButtonList[0].Add(new TabPageButton(_bookInformation));

            _borrowingFormButtonPresentationModel.SelectBook(-1, 0);
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
            _borrowingFormButtonPresentationModel.SelectBook(0, -1);
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
            _borrowingFormButtonPresentationModel.SelectBook(-1, -1);
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
            _borrowingFormButtonPresentationModel.SelectBook(10, 0);
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
            _borrowingFormButtonPresentationModel.SelectBook(0, 10);
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
            _borrowingFormButtonPresentationModel.SelectBook(10, 10);
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
            _borrowingFormButtonPresentationModel.SelectBook(0, 0);
            Assert.AreEqual(_bookInformation, _presentationModel.SelectedBookInformation);
        }

        // TestBookCategoryTabControlSelectedIndexChanged
        [TestMethod()]
        public void TestBookCategoryTabControlSelectedIndexChanged()
        {
            _bookButtonList.Add(new List<TabPageButton>());

            _borrowingFormButtonPresentationModel.BookCategoryTabControlSelectedIndexChanged(-1);
            Assert.AreEqual(-1, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);

            _borrowingFormButtonPresentationModel.BookCategoryTabControlSelectedIndexChanged(0);
            Assert.AreEqual(0, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);

            _borrowingFormButtonPresentationModel.BookCategoryTabControlSelectedIndexChanged(-2);
            Assert.AreEqual(-1, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);

            _borrowingFormButtonPresentationModel.BookCategoryTabControlSelectedIndexChanged(0);
            Assert.AreEqual(0, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);

            _borrowingFormButtonPresentationModel.BookCategoryTabControlSelectedIndexChanged(10);
            Assert.AreEqual(-1, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);

            _borrowingFormButtonPresentationModel.BookCategoryTabControlSelectedIndexChanged(0);
            Assert.AreEqual(0, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);

            _borrowingFormButtonPresentationModel.BookCategoryTabControlSelectedIndexChanged(-1);
            Assert.AreEqual(-1, _borrowingFormButtonPresentationModel.SelectedTabPageIndex);
            Assert.AreEqual(0, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
        }

        // TestClickNextPageButton
        [TestMethod()]
        public void TestClickNextPageButton()
        {
            _borrowingFormButtonPresentationModel.ClickNextPageButton();
            Assert.AreEqual(1, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
        }

        // TestClickLastPageButton
        [TestMethod()]
        public void TestClickLastPageButton()
        {
            _borrowingFormButtonPresentationModel.ClickLastPageButton();
            Assert.AreEqual(-1, _privateObject.GetFieldOrProperty("ButtonPageIndex"));
            Assert.AreEqual(null, _presentationModel.SelectedBookInformation);
        }

        // TestClickBackPackButton
        [TestMethod()]
        public void TestClickBackPackButton()
        {
            _borrowingFormButtonPresentationModel.ClickBackPackButton();
            Assert.AreEqual(false, _borrowingFormButtonPresentationModel.IsBackPackButtonEnabled);
        }

        // TestBackPackFormClosing
        [TestMethod()]
        public void TestBackPackFormClosing()
        {
            _borrowingFormButtonPresentationModel.BackPackFormClosing();
            Assert.AreEqual(true, _borrowingFormButtonPresentationModel.IsBackPackButtonEnabled);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string[] notifyList = (string[])_privateObject.GetFieldOrProperty("_notifyList");
            _privateObject.Invoke("NotifyPropertyChanged");
            Assert.AreEqual(0, receivedEvents.Count);
            _borrowingFormButtonPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged");
            foreach (string propertyName in notifyList)
                Assert.AreEqual(true, receivedEvents.Contains(propertyName));
        }
    }
}