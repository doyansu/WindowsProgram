using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.IO;
using OpenQA.Selenium.Appium.Windows.Enums;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;

namespace DrawingFormTests.UITest
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("appWorkingDir", Directory.GetParent(targetAppPath).FullName);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickButtonByName(string name, int times = 1)
        {
            while (times-- > 0)
                _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickButtonById(string id, int times = 1)
        {
            while (times-- > 0)
                _driver.FindElementByAccessibilityId(id).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }
        
        /// <summary>
        /// 以元件中心為基準，拖曳滑鼠並放開
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="name"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DragAndDrop(string name, int x1, int y1, int x2, int y2)
        {
            Actions action = new Actions(_driver);
            var element = _driver.FindElementByName(name);
            Point center = new Point(element.Size.Width / 2, element.Size.Height / 2);
            action.MoveToElement(element).Perform();
            action.MoveByOffset(x1 - (int)center.X, y1 - (int)center.Y).ClickAndHold().Perform();
            action.MoveByOffset(x2 - x1, y2 - y1).Release().Perform();
        }

        // test
        public void PressKey(string key)
        {
            SendKeys.SendWait(key);
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName, int times = 1)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            //_driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
            const string STRING_FORMAT = "{0} 資料列 {1}";
            WindowsElement windowsElement = _driver.FindElementByName(String.Format(STRING_FORMAT, columnName, rowIndex));
            while(times-- > 0)
                windowsElement.Click();
        }

        // test
        public void AssertEnableByName(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertEnableById(string id, bool state)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(id);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertVisibleById(string id, bool state)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(id);
            Assert.AreEqual(state, element.Displayed);
        }

        // test
        public void AssertTextByName(string name, string text)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertTextById(string id, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(id);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertMessageBoxTitle(string expected)
        {
            const string MESSAGEBOX_CLASSNAME = "#32770";
            string messageTitle = _driver.FindElementByClassName(MESSAGEBOX_CLASSNAME).Text;
            Assert.AreEqual(expected, messageTitle.Replace("\r\n", "\n"));
        }

        // test
        public void AssertMessageBoxText(string expected)
        {
            const string MESSAGEBOX_CLASSNAME = "#32770";
            const string XPATH_FORMAT = "//Text[@Name='{0}']";
            string messageText = _driver.FindElementByClassName(MESSAGEBOX_CLASSNAME).FindElementByXPath(string.Format(XPATH_FORMAT, expected)).Text;
            Assert.AreEqual(expected, messageText.Replace("\r\n", "\n"));
        }

        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            const string STRING_FORMAT = "資料列 {0}";
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            //var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            var rowDatas = dataGridView.FindElementByName(string.Format(STRING_FORMAT, rowIndex)).FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // test
        public void AssertDataGridViewCellValueBy(string name, int rowIndex, int columnIndex, string value)
        {
            const string STRING_FORMAT = "資料列 {0}";
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName(string.Format(STRING_FORMAT, rowIndex)).FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            Assert.AreEqual(value, rowDatas[columnIndex + 1].Text.Replace("(null)", ""));
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
    }
}
