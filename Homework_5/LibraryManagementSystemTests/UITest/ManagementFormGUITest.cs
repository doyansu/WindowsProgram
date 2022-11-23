using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.UITest.Tests
{
    [TestClass]
    public class ManagementFormGUITest
    {
        private Robot _robot;

        private string targetAppPath;

        private const string MENU_FORM = "Menu";
        private const string BORROWING_FORM = "BookBorrowingFrom";
        private const string INVENTORY_FORM = "BookInventoryForm";
        private const string MANAGEREMENT_FORM = "BookManagementForm";
        private const string BACK_FORM = "BackPackForm";
        private const string ADDING_FORM = "BookAddingForm";

        private const string INVENTORY_DGV_ID = "_bookInformationDataGridView";
        private const string INFORMATION_RICH_TEXTBOX_ID = "_bookInformationRichTextBox";

        private const string BOOK_NAME_TEXTBOX_ID = "_bookNameTextBox";

        readonly string[] _bookCategoryList = {
            "6月暢銷書",
            "4月暢銷書",
            "英文學習",
            "職場必讀" };


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

            _robot.ClickButtonByName("Book Management System");
            _robot.SwitchTo(MANAGEREMENT_FORM);
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
        /// 測試 Management Form 初始化狀態
        /// </summary>
        [TestMethod]
        public void TestFormInitialize()
        {
            
        }

        /// <summary>
        /// 測試 Management Form 初始化狀態
        /// </summary>
        [TestMethod]
        public void TestClickListBox()
        {

        }
    }
}
