using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.PresentationModel.BindingListObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LibraryManagementSystem.PresentationModel.BindingListObject.Tests
{
    [TestClass()]
    public class ManagementCategoryTests
    {
        ManagementCategory _management;
        PrivateObject _privateObject;

        const string CATEGORY = "4月暢銷書";
        const string NEW_CATEGORY = "6月暢銷書";

        readonly string[] _notifyList = {
            "",
            "notify"
        };

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _management = new ManagementCategory(CATEGORY);
            _privateObject = new PrivateObject(_management);
        }

        // TestManagementCategory
        [TestMethod()]
        public void TestManagementCategory()
        {
            Assert.AreEqual(CATEGORY, _management.Category);
        }

        // TestSetCategory
        [TestMethod()]
        public void TestSetCategory()
        {
            _management.Category = NEW_CATEGORY;
            Assert.AreEqual(NEW_CATEGORY, _management.Category);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            _privateObject.Invoke("NotifyPropertyChanged", "");
            _management.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
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