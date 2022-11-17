using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using System.ComponentModel;

namespace LibraryManagementSystem.PresentationModel.Tests
{
    [TestClass()]
    public class BookAddingFormPresentationModelTests
    {
        BookAddingFormPresentationModel _bookAddingFormPresentationModel;
        PrivateObject _privateObject;

        Library _model;

        const string DATA_FILE_NAME_FORMAT = "TestFile/hw{0}_books_source.txt";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Library(string.Format(DATA_FILE_NAME_FORMAT, 4));
            _bookAddingFormPresentationModel = new BookAddingFormPresentationModel(_model);
            _privateObject = new PrivateObject(_bookAddingFormPresentationModel);
        }

        // TestBookAddingFormPresentationModel
        [TestMethod()]
        public void TestBookAddingFormPresentationModel()
        {
            Assert.AreEqual(_model, (Library)_privateObject.GetFieldOrProperty("_model"));
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);
            Assert.AreEqual("", _bookAddingFormPresentationModel.BookInformation);
        }

        // TestSetBookInformation
        [TestMethod()]
        public void TestSetBookInformation()
        {
            const string NEW_INFO = "new";
            _bookAddingFormPresentationModel.BookInformation = NEW_INFO;
            Assert.AreEqual(NEW_INFO, _bookAddingFormPresentationModel.BookInformation);
        }

        // TestSetAddingQuantity
        [TestMethod()]
        public void TestSetAddingQuantity()
        {
            _bookAddingFormPresentationModel.SetAddingQuantity("");
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("fasfsaf");
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("-1");
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("9999999999999999");
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("*/*1/*/@!#!@$");
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("123a1");
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("0");
            Assert.AreEqual(0, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("1231");
            Assert.AreEqual(1231, _bookAddingFormPresentationModel.AddingQuantity);

            _bookAddingFormPresentationModel.SetAddingQuantity("7777777");
            Assert.AreEqual(7777777, _bookAddingFormPresentationModel.AddingQuantity);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string[] notifyList = (string[])_privateObject.GetFieldOrProperty("_notifyList");
            _privateObject.Invoke("NotifyPropertyChanged");
            _bookAddingFormPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged");
            foreach (string propertyName in notifyList)
                Assert.AreEqual(true, receivedEvents.Contains(propertyName));
        }
    }
}