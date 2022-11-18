using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace LibraryManagementSystem.UITest.Tests
{
    [TestClass]
    public class MeunFormGUITest
    {
        private Robot _robot;

        private string targetAppPath;

        private const string MENU_FORM = "Menu";
        private const string BORROWING_FORM = "BookBorrowingFrom";
        private const string INVENTORY_FORM = "BookInventoryForm";
        private const string MANAGEREMENT_FORM = "BookManagementForm";

        // 取得目標應用路徑
        private string GetTargetPath(string projectName)
        {
            string appName = projectName + ".exe";
            string solutionPath = AppDomain.CurrentDomain.BaseDirectory;
            do
            {
                bool IsFindProject = false;
                foreach (var directory in Directory.GetParent(solutionPath).GetDirectories())
                    if (directory.Name == projectName)
                        IsFindProject = true;
                if (IsFindProject)
                    break;
                solutionPath = Path.GetFullPath(Path.Combine(solutionPath, "..\\"));
            } while (solutionPath != Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory));
            return Path.Combine(solutionPath, projectName, "bin", "Debug", appName);
        }

        // init 
        [TestInitialize]
        public void Initialize()
        {
            const string projectName = "LibraryManagementSystem";
            // 只是為了 coverage (projectName 錯誤情況)
            targetAppPath = this.GetTargetPath("");
            targetAppPath = this.GetTargetPath(projectName);
            _robot = new Robot(targetAppPath, MENU_FORM);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        /// <summary>
        /// 測試 BookBorrowingSystemButton 點擊 enable 狀態
        /// </summary>
        [TestMethod]
        public void TestBookBorrowingSystemButton()
        {
            string buttonName = "Book Borrowing System";
            _robot.AssertEnable(buttonName, true);
            _robot.ClickButton(buttonName);
            _robot.AssertEnable(buttonName, false);
            _robot.SwitchTo(BORROWING_FORM);
            _robot.CloseWindow();
            _robot.SwitchTo(MENU_FORM);
            _robot.AssertEnable(buttonName, true);
        }

        /// <summary>
        /// 測試 BookInventorySystemButton 點擊 enable 狀態
        /// </summary>
        [TestMethod]
        public void TestBookInventorySystemButton()
        {
            string buttonName = "Book Inventory System";
            _robot.AssertEnable(buttonName, true);
            _robot.ClickButton(buttonName);
            _robot.AssertEnable(buttonName, false);
            _robot.SwitchTo(INVENTORY_FORM);
            _robot.CloseWindow();
            _robot.SwitchTo(MENU_FORM);
            _robot.AssertEnable(buttonName, true);
        }

        /// <summary>
        /// 測試 BookManagementSystemButton 點擊 enable 狀態
        /// </summary>
        [TestMethod]
        public void TestBookManagementSystemButton()
        {
            string buttonName = "Book Management System";
            _robot.AssertEnable(buttonName, true);
            _robot.ClickButton(buttonName);
            _robot.AssertEnable(buttonName, false);
            _robot.SwitchTo(MANAGEREMENT_FORM);
            _robot.CloseWindow();
            _robot.SwitchTo(MENU_FORM);
            _robot.AssertEnable(buttonName, true);
        }
    }
}
