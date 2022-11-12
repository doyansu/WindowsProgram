using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels.Tests
{
    [TestClass()]
    public class BookBorrowingFormControlPresentationModelTests
    {
        BookBorrowingFormControlPresentationModel _bookBorrowingFormControlPresentationModel;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _bookBorrowingFormControlPresentationModel = new BookBorrowingFormControlPresentationModel();
        }

        // TestBookBorrowingFormControlPresentationModel
        [TestMethod()]
        public void TestBookBorrowingFormControlPresentationModel()
        {
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.TabPageWidth);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonIndex);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonHeight);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonWidth);
        }

        // TestSetButtonIndex
        [TestMethod()]
        public void TestSetButtonIndex()
        {
            _bookBorrowingFormControlPresentationModel.ButtonIndex = -1;
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonIndex);
            _bookBorrowingFormControlPresentationModel.ButtonIndex = 10;
            Assert.AreEqual(10, _bookBorrowingFormControlPresentationModel.ButtonIndex);
        }

        // TestSetButtonSize
        [TestMethod()]
        public void TestSetButtonSize()
        {
            _bookBorrowingFormControlPresentationModel.SetButtonSize(-1, 10);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.TabPageWidth);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonHeight);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonWidth);
            _bookBorrowingFormControlPresentationModel.SetButtonSize(10, -1);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.TabPageWidth);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonHeight);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonWidth);
            _bookBorrowingFormControlPresentationModel.SetButtonSize(-1, -1);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.TabPageWidth);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonHeight);
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.ButtonWidth);
            _bookBorrowingFormControlPresentationModel.SetButtonSize(20, 10);
            Assert.AreEqual(20, _bookBorrowingFormControlPresentationModel.TabPageWidth);
            Assert.AreEqual(8, _bookBorrowingFormControlPresentationModel.ButtonHeight);
            Assert.AreEqual(3, _bookBorrowingFormControlPresentationModel.ButtonWidth);
        }

        // TestGetButtonLocation
        [TestMethod()]
        public void TestGetButtonLocation()
        {
            const int BUTTONS_PER_PAGE = 3;
            Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.GetButtonLocation());
            _bookBorrowingFormControlPresentationModel.SetButtonSize(50, 40);
            for (int i = 0; i < 20; i++)
            {
                _bookBorrowingFormControlPresentationModel.ButtonIndex = i;
                if (i % BUTTONS_PER_PAGE == 0)
                    Assert.AreEqual(0, _bookBorrowingFormControlPresentationModel.GetButtonLocation());
                if (i % BUTTONS_PER_PAGE == 1)
                    Assert.AreEqual(13, _bookBorrowingFormControlPresentationModel.GetButtonLocation());
                if (i % BUTTONS_PER_PAGE == 2)
                    Assert.AreEqual(26, _bookBorrowingFormControlPresentationModel.GetButtonLocation());
            }
        }
    }
}