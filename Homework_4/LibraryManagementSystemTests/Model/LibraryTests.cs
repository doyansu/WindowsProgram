using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model.Tests
{
    [TestClass()]
    public class LibraryTests
    {
        Library _library;
        PrivateObject _privateObject;

        Book _book;
        BookItem _bookItem;
        List<BookItem> _bookItems;
        BorrowedList _borrowedList;

        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";
        const string CATEGORY = "category";
        const int BOOK_COUNT = 20;
        const int CATEGORY_COUNT = 4;

        readonly string[] _bookInformationList = {
            "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]",
            "../../../image/1.jpg" };

        readonly string[] _bookCategoryList = {
            "6月暢銷書",
            "4月暢銷書",
            "英文學習",
            "職場必讀" };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _library = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _privateObject = new PrivateObject(_library);

            _book = new Book(_bookInformationList[0], _bookInformationList[1], _bookInformationList[2], _bookInformationList[3], _bookInformationList[4]);

            _bookItem = new BookItem(_book, 0);

            _bookItems = new List<BookItem>();
            _bookItems.Add(_bookItem);

            _borrowedList = new BorrowedList();
            _borrowedList.Add(new BorrowedItem(_bookItem));
        }

        // TestLibrary
        [TestMethod()]
        public void TestLibrary()
        {
            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));
            Assert.AreEqual(BOOK_COUNT, ((List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList")).Count);
            Assert.AreEqual(CATEGORY_COUNT, ((List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList")).Count);
            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);
        }

        // TestSaveBook
        [TestMethod()]
        public void TestSaveBook()
        {
            List<string> bookData = new List<string>();
            const int BOOK_QUANTITY = 1;
            bookData.Add(BOOK_QUANTITY.ToString());
            bookData.Add(CATEGORY);
            foreach (string data in _bookInformationList)
                bookData.Add(data);
            ////
            _privateObject.Invoke("SaveBook", new object[] { bookData });
            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));

            List<BookItem> bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            Assert.AreEqual(BOOK_COUNT + 1, bookItems.Count);
            Assert.AreEqual(BOOK_QUANTITY, bookItems[BOOK_COUNT].Quantity);

            List<BookCategory> bookCategories = (List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList");
            Assert.AreEqual(CATEGORY_COUNT + 1, bookCategories.Count);
            Assert.AreEqual(CATEGORY, bookCategories[CATEGORY_COUNT].Category);

            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);
            ////
            ////
            _privateObject.Invoke("SaveBook", new object[] { bookData });
            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));

            bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            Assert.AreEqual(BOOK_COUNT + 2, bookItems.Count);
            Assert.AreEqual(BOOK_QUANTITY, bookItems[BOOK_COUNT].Quantity);

            bookCategories = (List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList");
            Assert.AreEqual(CATEGORY_COUNT + 1, bookCategories.Count);
            Assert.AreEqual(CATEGORY, bookCategories[CATEGORY_COUNT].Category);
            Assert.AreEqual(2, bookCategories[CATEGORY_COUNT].GetBookCount());

            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);
            ////
        }

        // TestSaveBookDataError
        [TestMethod()]
        public void TestSaveBookDataError()
        {
            List<string> bookData = new List<string>();
            bookData.Add(CATEGORY);
            foreach (string data in _bookInformationList)
                bookData.Add(data);

            _privateObject.Invoke("SaveBook", new object[] { bookData });

            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));
            Assert.AreEqual(BOOK_COUNT, ((List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList")).Count);
            Assert.AreEqual(CATEGORY_COUNT, ((List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList")).Count);
            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);

            bookData.Add(CATEGORY);

            _privateObject.Invoke("SaveBook", new object[] { bookData });

            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));
            Assert.AreEqual(BOOK_COUNT, ((List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList")).Count);
            Assert.AreEqual(CATEGORY_COUNT, ((List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList")).Count);
            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);
        }

        // TestLoadBooksData
        [TestMethod()]
        public void TestReset()
        {
            List<string> bookData = new List<string>();
            const int BOOK_QUANTITY = 1;
            bookData.Add(BOOK_QUANTITY.ToString());
            bookData.Add(CATEGORY);
            foreach (string data in _bookInformationList)
                bookData.Add(data);

            _privateObject.Invoke("SaveBook", new object[] { bookData });
            _privateObject.Invoke("SaveBook", new object[] { bookData });
            _privateObject.Invoke("Reset");

            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));
            Assert.AreEqual(0, ((List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList")).Count);
            Assert.AreEqual(0, ((List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList")).Count);
            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);
        }

        // TestLoadBooksData
        [TestMethod()]
        public void TestLoadBooksData()
        {
            ////
            _privateObject.Invoke("LoadBooksData", new object[] { string.Format(DATA_FILE_NAME_FORMAT, 1) });
            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));

            List<BookItem> bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            Assert.AreEqual(6, bookItems.Count);

            List<BookCategory> bookCategories = (List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList");
            Assert.AreEqual(2, bookCategories.Count);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(_bookCategoryList[i], bookCategories[i].Category);
                Assert.AreEqual(3, bookCategories[i].GetBookCount());
            }

            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);
            ////
            ////
            _privateObject.Invoke("LoadBooksData", new object[] { string.Format(DATA_FILE_NAME_FORMAT, 4) });

            Assert.AreEqual(null, _privateObject.GetFieldOrProperty("_selectedBook"));

            bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            Assert.AreEqual(20, bookItems.Count);

            bookCategories = (List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList");
            Assert.AreEqual(4, bookCategories.Count);
            int[] categotyBookCount = { 4, 5, 8, 3 };
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(_bookCategoryList[i], bookCategories[i].Category);
                Assert.AreEqual(categotyBookCount[i], bookCategories[i].GetBookCount());
            }

            Assert.AreEqual(0, ((BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList")).Count);
            ////
        }

        // TestSelectBook
        [TestMethod()]
        public void TestSelectBook()
        {
            Book selecedBook;
            _library.SelectBook("");
            selecedBook = (Book)_privateObject.GetFieldOrProperty("_selectedBook");
            Assert.AreEqual(null, selecedBook);

            _privateObject.SetFieldOrProperty("_bookItemList", _bookItems);

            _library.SelectBook(_book.Name);
            selecedBook = (Book)_privateObject.GetFieldOrProperty("_selectedBook");
            Assert.AreEqual(true, selecedBook != null);
            Assert.AreEqual(_book.Name, selecedBook.Name);
            Assert.AreEqual(_book.Author, selecedBook.Author);
            Assert.AreEqual(_book.PublicationItem, selecedBook.PublicationItem);
            Assert.AreEqual(_book.ImagePath, selecedBook.ImagePath);
            Assert.AreEqual(_book.InternationalStandardBookNumber, selecedBook.InternationalStandardBookNumber);
        }

        // TestBorrowSelectedBook
        [TestMethod()]
        public void TestBorrowSelectedBook()
        {
            const int BORROW_QUANTITY = 1;
            Book bookNotIn = _book.Copy();
            bookNotIn.Name = "";
            _bookItem.Quantity = 1;
            BorrowedList borrowedList = (BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList");

            _privateObject.SetFieldOrProperty("_selectedBook", bookNotIn);
            _privateObject.SetFieldOrProperty("_bookItemList", _bookItems);
            _library.BorrowSelectedBook(BORROW_QUANTITY);
            Assert.AreEqual(0, borrowedList.Count);

            _privateObject.SetFieldOrProperty("_selectedBook", _book);
            _library.BorrowSelectedBook(BORROW_QUANTITY);
            Assert.AreEqual(1, borrowedList.Count);
            Assert.AreEqual(_book, borrowedList.GetBookItemAt(0).Book);
            Assert.AreEqual(BORROW_QUANTITY, borrowedList.GetBookItemAt(0).Quantity);
        }

        // TestReturnBorrowedListItem
        [TestMethod()]
        public void TestReturnBorrowedListItem()
        {
            BorrowedList borrowedList = (BorrowedList)_privateObject.GetFieldOrProperty("_borrowedList");
            List<BookItem> bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            BookItem bookItem = bookItems[0];
            int borrowCount = 2;
            int sourseQuantity = bookItem.Quantity;
            BorrowedItem borrowedItem = new BorrowedItem(bookItem.Take(borrowCount));
            borrowedList.Add(borrowedItem);

            _library.ReturnBorrowedListItem(-1, 0);
            Assert.AreEqual(1, borrowedList.Count);
            Assert.AreEqual(borrowCount, borrowedItem.BookItem.Quantity);
            Assert.AreEqual(sourseQuantity - borrowCount, bookItem.Quantity);

            _library.ReturnBorrowedListItem(borrowedList.Count + 1, 0);
            Assert.AreEqual(1, borrowedList.Count);
            Assert.AreEqual(borrowCount, borrowedItem.BookItem.Quantity);
            Assert.AreEqual(sourseQuantity - borrowCount, bookItem.Quantity);

            _library.ReturnBorrowedListItem(0, 1);
            borrowCount -= 1;
            Assert.AreEqual(1, borrowedList.Count);
            Assert.AreEqual(borrowCount, borrowedItem.BookItem.Quantity);
            Assert.AreEqual(sourseQuantity - borrowCount, bookItem.Quantity);

            _library.ReturnBorrowedListItem(0, 2);
            borrowCount -= 1;
            Assert.AreEqual(0, borrowedList.Count);
            Assert.AreEqual(borrowCount, borrowedItem.BookItem.Quantity);
            Assert.AreEqual(sourseQuantity - borrowCount, bookItem.Quantity);
        }

        // TestAddBookQuantity
        [TestMethod()]
        public void TestAddBookQuantity()
        {
            List<BookItem> bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            BookItem bookItem = bookItems[0];
            int quantity = bookItem.Quantity;
            int addingQuantity = 1;
            string bookName = bookItem.Book.Name;

            _library.AddBookQuantity("", addingQuantity);
            _library.AddBookQuantity(bookName, -1);
            Assert.AreEqual(quantity, bookItem.Quantity);

            _library.AddBookQuantity(bookName, addingQuantity);
            Assert.AreEqual(quantity + addingQuantity, bookItem.Quantity);
        }

        // TestChangeBookInformation
        [TestMethod()]
        public void TestChangeBookInformation()
        {
            List<BookItem> bookItems = (List<BookItem>)_privateObject.GetFieldOrProperty("_bookItemList");
            BookItem bookItem = bookItems[0];
            Book sourceBook = bookItem.Book;
            Book copySourceBook = sourceBook.Copy();
            Book changeBook = bookItems[10].Book.Copy();
            List<BookCategory> bookCategories = (List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList");
            BookInformation bookInformation = new BookInformation(bookItem, bookCategories[0].Category);

            _library.ChangeBookInformation(null);
            Assert.AreEqual(copySourceBook.Name, sourceBook.Name);
            Assert.AreEqual(copySourceBook.InternationalStandardBookNumber, sourceBook.InternationalStandardBookNumber);
            Assert.AreEqual(copySourceBook.Author, sourceBook.Author);
            Assert.AreEqual(copySourceBook.PublicationItem, sourceBook.PublicationItem);
            Assert.AreEqual(copySourceBook.ImagePath, sourceBook.ImagePath);
            Assert.AreEqual(true, bookCategories[0].ContainBook(sourceBook));

            bookInformation.BookName = changeBook.Name;
            bookInformation.BookNumber = changeBook.InternationalStandardBookNumber;
            bookInformation.BookPublicationItem = changeBook.PublicationItem;
            bookInformation.BookAuthor = changeBook.Author;
            bookInformation.BookImagePath = changeBook.ImagePath;
            _library.ChangeBookInformation(bookInformation);
            Assert.AreEqual(changeBook.Name, sourceBook.Name);
            Assert.AreEqual(changeBook.InternationalStandardBookNumber, sourceBook.InternationalStandardBookNumber);
            Assert.AreEqual(changeBook.Author, sourceBook.Author);
            Assert.AreEqual(changeBook.PublicationItem, sourceBook.PublicationItem);
            Assert.AreEqual(changeBook.ImagePath, sourceBook.ImagePath);
            Assert.AreEqual(true, bookCategories[0].ContainBook(sourceBook));

            bookInformation.BookCategory = bookCategories[1].Category;
            _library.ChangeBookInformation(bookInformation);
            Assert.AreEqual(changeBook.Name, sourceBook.Name);
            Assert.AreEqual(changeBook.InternationalStandardBookNumber, sourceBook.InternationalStandardBookNumber);
            Assert.AreEqual(changeBook.Author, sourceBook.Author);
            Assert.AreEqual(changeBook.PublicationItem, sourceBook.PublicationItem);
            Assert.AreEqual(changeBook.ImagePath, sourceBook.ImagePath);
            Assert.AreEqual(false, bookCategories[0].ContainBook(sourceBook));
            Assert.AreEqual(true, bookCategories[1].ContainBook(sourceBook));
        }

        // TestGetCategoryList
        [TestMethod()]
        public void TestGetCategoryList()
        {
            List<BookCategory> bookCategories = (List<BookCategory>)_privateObject.GetFieldOrProperty("_bookCategoryList");
            List<string> categoryList = _library.GetCategoryList();
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(bookCategories[i].Category, categoryList[i]);
                Assert.AreEqual(_bookCategoryList[i], categoryList[i]);
            }
        }

        [TestMethod()]
        public void GetCategoryQuantityPairTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCategoryBookInformationPairTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSelectedBookQuantityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSelectedBookInformationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBookItemsInformationListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowedListInformationListTest()
        {
            Assert.Fail();
        }
    }
}