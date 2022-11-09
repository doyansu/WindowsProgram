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
    public class BookManagementFormPresentationModelTests
    {
        BookManagementFormPresentationModel _bookManagementFormPresentationModel;
        PrivateObject _privateObject;

        Library _model;
        List<BookItem> _bookItems;

        BindingList<ManagementListRow> _managementList;
        BindingList<ManagementCategory> _managementCategoryList;

        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";

        readonly string[] _notifyList = {
            "",
            "notify"
        };

        readonly string[] _bookInformationList = {
            "微調",
            "964",
            "e",
            "原點",
            "../../../image/2.jpg" };

        readonly string[] _bookCategoryList = {
            "6月暢銷書",
            "4月暢銷書",
            "英文學習",
            "職場必讀" };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _privateObject = new PrivateObject(_model);
            _bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            
            _bookManagementFormPresentationModel = new BookManagementFormPresentationModel(_model);
            _privateObject = new PrivateObject(_bookManagementFormPresentationModel);
            _managementList = (BindingList<ManagementListRow>)_bookManagementFormPresentationModel.ManagementList;
            _managementCategoryList = (BindingList<ManagementCategory>)_bookManagementFormPresentationModel.ManagementCategoryList;
        }

        // TestBookManagementFormPresentationModel
        [TestMethod()]
        public void TestBookManagementFormPresentationModel()
        {
            Assert.AreEqual(_model, (Library)_privateObject.GetFieldOrProperty("_model"));
            Assert.AreEqual(_model.GetCategoryList().Count, _managementCategoryList.Count);
            Assert.AreEqual(_model.GetBookItemsInformationList().Count, _managementList.Count);
            Assert.AreEqual(0, _bookManagementFormPresentationModel.SelectedIndex);
            Assert.AreEqual(_bookItems[0].Book.ImagePath, _bookManagementFormPresentationModel.SelectedBookImagePath);
            Assert.AreEqual(true, _bookManagementFormPresentationModel.IsSelected);
            Assert.AreEqual(false, _bookManagementFormPresentationModel.IsAddEnabled);
            Assert.AreEqual(false, _bookManagementFormPresentationModel.IsBrowseEnabled);
        }

        // TestSetProperty
        [TestMethod()]
        public void TestSetSelectedIndex()
        {
            _bookManagementFormPresentationModel.SelectedIndex = 0;
            Assert.AreEqual(0, _bookManagementFormPresentationModel.SelectedIndex);
            Assert.AreEqual(true, _bookManagementFormPresentationModel.IsBrowseEnabled);

            _bookManagementFormPresentationModel.SelectedIndex = 1;
            Assert.AreEqual(1, _bookManagementFormPresentationModel.SelectedIndex);
            Assert.AreEqual(true, _bookManagementFormPresentationModel.IsBrowseEnabled);

            _bookManagementFormPresentationModel.SelectedIndex = -1;
            Assert.AreEqual(-1, _bookManagementFormPresentationModel.SelectedIndex);
            Assert.AreEqual(false, _bookManagementFormPresentationModel.IsBrowseEnabled);
        }

        // TestSetProperty
        [TestMethod()]
        public void TestSetSelectedBookImagePath()
        {
            string imagePath = _bookManagementFormPresentationModel.SelectedBookImagePath;
            const string NEW_IMAGE_PATH = "test";
            _bookManagementFormPresentationModel.SelectedBookImagePath = NEW_IMAGE_PATH;
            Assert.AreEqual(NEW_IMAGE_PATH, _bookManagementFormPresentationModel.SelectedBookImagePath);
            Assert.AreEqual(true, _bookManagementFormPresentationModel.IsSelected);

            _bookManagementFormPresentationModel.SelectedIndex = -1;
            _bookManagementFormPresentationModel.SelectedBookImagePath = NEW_IMAGE_PATH;
            Assert.AreEqual(true, _bookManagementFormPresentationModel.SelectedBookImagePath != NEW_IMAGE_PATH);
            Assert.AreEqual(false, _bookManagementFormPresentationModel.IsSelected);
            Assert.AreEqual(false, _bookManagementFormPresentationModel.IsBrowseEnabled);
        }

        // TestAddBookButtonClick
        [TestMethod()]
        public void TestAddBookButtonClick()
        {
            _bookManagementFormPresentationModel.AddBookButtonClick();
            //  now do nothing 尚未有功能
        }

        // TestSaveBookButtonClick
        [TestMethod()]
        public void TestSaveBookButtonClick()
        {
            BookInformation bookInformation = _managementList[_bookManagementFormPresentationModel.SelectedIndex].BookInformationObject;
            bookInformation.BookName = _bookInformationList[0];
            bookInformation.BookNumber = _bookInformationList[1];
            bookInformation.BookAuthor = _bookInformationList[2];
            bookInformation.BookPublicationItem = _bookInformationList[3];
            bookInformation.BookImagePath = _bookInformationList[4];
            bookInformation.BookCategory = _bookCategoryList[3];
            _bookManagementFormPresentationModel.SaveBookButtonClick();

            _privateObject = new PrivateObject(bookInformation);
            Book book = ((BookItem)_privateObject.GetFieldOrProperty("_bookItem")).Book;
            _privateObject = new PrivateObject(_managementList[_bookManagementFormPresentationModel.SelectedIndex].BookInformationObject);
            string category = (string)(_privateObject.GetFieldOrProperty("_sourceCategory"));
            Assert.AreEqual(book.Name, bookInformation.BookName);
            Assert.AreEqual(book.InternationalStandardBookNumber, bookInformation.BookNumber);
            Assert.AreEqual(book.Author, bookInformation.BookAuthor);
            Assert.AreEqual(book.PublicationItem, bookInformation.BookPublicationItem);
            Assert.AreEqual(book.ImagePath, bookInformation.BookImagePath);
            Assert.AreEqual(category, bookInformation.BookCategory);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            _privateObject.Invoke("NotifyPropertyChanged", "");
            _bookManagementFormPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
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