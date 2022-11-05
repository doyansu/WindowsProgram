using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tests
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
            "原點出版: 大雁發行, 2021[民110]" };

        const string _formatInformatoin = "微調有差の日系新版面設計: 一本前所未有、聚焦於「微調細節差很大」的設計參考書\n編號 : 964 8394:2 - 5 2021\n作者 : ingectar - e\n原點出版: 大雁發行, 2021[民110]";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book(bookInformationList[0], bookInformationList[1], bookInformationList[2], bookInformationList[3]);
            _bookPrivate = new PrivateObject(_book);
        }

        // Cosntrctor
        [TestMethod()]
        public void TestBook()
        {
            Assert.AreEqual(bookInformationList[0], _bookPrivate.GetFieldOrProperty("Name"));
            Assert.AreEqual(bookInformationList[1], _bookPrivate.GetFieldOrProperty("InternationalStandardBookNumber"));
            Assert.AreEqual(bookInformationList[2], _bookPrivate.GetFieldOrProperty("Author"));
            Assert.AreEqual(bookInformationList[3], _bookPrivate.GetFieldOrProperty("PublicationItem"));
        }

        // TestGetInformationList
        [TestMethod()]
        public void TestGetInformationList()
        {
            List<string> InformationList = _book.GetInformationList();
            Assert.AreEqual(InformationList[0], _bookPrivate.GetFieldOrProperty("Name"));
            Assert.AreEqual(InformationList[1], _bookPrivate.GetFieldOrProperty("InternationalStandardBookNumber"));
            Assert.AreEqual(InformationList[2], _bookPrivate.GetFieldOrProperty("Author"));
            Assert.AreEqual(InformationList[3], _bookPrivate.GetFieldOrProperty("PublicationItem"));
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