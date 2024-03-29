﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model.Tests
{
    [TestClass()]
    public class BookTests
    {
        Book _book;
        PrivateObject _bookPrivate;
        readonly string[] bookInformationList = {
            "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書",
            "964 8394:2 - 5 2021",
            "ingectar - e",
            "原點出版: 大雁發行, 2021[民110]",
            "../../../image/1.jpg" };
        const string _formatInformatoin = "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書\n編號 : 964 8394:2 - 5 2021\n作者 : ingectar - e\n原點出版: 大雁發行, 2021[民110]";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book(bookInformationList[0], bookInformationList[1], bookInformationList[2], bookInformationList[3], bookInformationList[4]);
            _bookPrivate = new PrivateObject(_book);
        }

        // Cosntrctor
        [TestMethod()]
        public void TestBook()
        {
            Assert.AreEqual(bookInformationList[0], _book.Name);
            Assert.AreEqual(bookInformationList[1], _book.InternationalStandardBookNumber);
            Assert.AreEqual(bookInformationList[2], _book.Author);
            Assert.AreEqual(bookInformationList[3], _book.PublicationItem);
            Assert.AreEqual(bookInformationList[4], _book.ImagePath);
        }

        // Cosntrctor
        [TestMethod()]
        public void TestCopy()
        {
            Book copyBook = _book.Copy();
            Assert.AreNotEqual(copyBook, _book);
            Assert.AreEqual(copyBook.Name, _book.Name);
            Assert.AreEqual(copyBook.InternationalStandardBookNumber, _book.InternationalStandardBookNumber);
            Assert.AreEqual(copyBook.Author, _book.Author);
            Assert.AreEqual(copyBook.PublicationItem, _book.PublicationItem);
        }

        // TestCopyContent
        [TestMethod()]
        public void TestCopyContent()
        {
            Book copyBook = new Book("", "", "", "", "");
            copyBook.CopyContent(_book);
            Assert.AreEqual(copyBook.Name, _book.Name);
            Assert.AreEqual(copyBook.InternationalStandardBookNumber, _book.InternationalStandardBookNumber);
            Assert.AreEqual(copyBook.Author, _book.Author);
            Assert.AreEqual(copyBook.PublicationItem, _book.PublicationItem);
        }

        // TestGetFormatInformation
        [TestMethod()]
        public void TestGetFormatInformation()
        {
            string formatInformation = _book.GetFormatInformation();
            Assert.AreEqual(formatInformation, _formatInformatoin);
        }
    }
}