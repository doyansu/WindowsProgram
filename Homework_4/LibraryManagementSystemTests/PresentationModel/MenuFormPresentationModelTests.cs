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
    public class MenuFormPresentationModelTests
    {
        MenuFormPresentationModel _menuFormPresentationModel;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _menuFormPresentationModel = new MenuFormPresentationModel();
            _privateObject = new PrivateObject(_menuFormPresentationModel);
        }

        // TestMenuFormPresentationModel
        [TestMethod()]
        public void TestMenuFormPresentationModel()
        {
            Assert.AreEqual(true, _menuFormPresentationModel.IsBorrowingEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsInventoryEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsManagementEnabled);
        }

        // TestShowBorrowingForm
        [TestMethod()]
        public void TestShowBorrowingForm()
        {
            _menuFormPresentationModel.ShowBorrowingForm();
            Assert.AreEqual(false, _menuFormPresentationModel.IsBorrowingEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsInventoryEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsManagementEnabled);
        }

        // TestCloseBorrowingForm
        [TestMethod()]
        public void TestCloseBorrowingForm()
        {
            _menuFormPresentationModel.CloseBorrowingForm();
            Assert.AreEqual(true, _menuFormPresentationModel.IsBorrowingEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsInventoryEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsManagementEnabled);
        }

        // TestShowInventoryForm
        [TestMethod()]
        public void TestShowInventoryForm()
        {
            _menuFormPresentationModel.ShowInventoryForm();
            Assert.AreEqual(true, _menuFormPresentationModel.IsBorrowingEnabled);
            Assert.AreEqual(false, _menuFormPresentationModel.IsInventoryEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsManagementEnabled);
        }

        // TestCloseInventoryForm
        [TestMethod()]
        public void TestCloseInventoryForm()
        {
            _menuFormPresentationModel.CloseInventoryForm();
            Assert.AreEqual(true, _menuFormPresentationModel.IsBorrowingEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsInventoryEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsManagementEnabled);
        }

        // TestShowManagementForm
        [TestMethod()]
        public void TestShowManagementForm()
        {
            _menuFormPresentationModel.ShowManagementForm();
            Assert.AreEqual(true, _menuFormPresentationModel.IsBorrowingEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsInventoryEnabled);
            Assert.AreEqual(false, _menuFormPresentationModel.IsManagementEnabled);
        }

        // TestCloseManagementForm
        [TestMethod()]
        public void TestCloseManagementForm()
        {
            _menuFormPresentationModel.CloseManagementForm();
            Assert.AreEqual(true, _menuFormPresentationModel.IsBorrowingEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsInventoryEnabled);
            Assert.AreEqual(true, _menuFormPresentationModel.IsManagementEnabled);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string[] notifyList = (string[])_privateObject.GetFieldOrProperty("_notifyList");
            _privateObject.Invoke("NotifyPropertyChanged");
            _menuFormPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged");
            foreach (string propertyName in notifyList)
                Assert.AreEqual(true, receivedEvents.Contains(propertyName));
        }
    }
}