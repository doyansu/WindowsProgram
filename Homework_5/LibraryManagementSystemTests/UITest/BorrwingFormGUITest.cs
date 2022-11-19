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
    public class BorrwingFormGUITest
    {
        private Robot _robot;

        private string targetAppPath;

        private const string MENU_FORM = "Menu";
        private const string BORROWING_FORM = "BookBorrowingFrom";
        private const string INVENTORY_FORM = "BookInventoryForm";
        private const string MANAGEREMENT_FORM = "BookManagementForm";
        private const string BACK_FORM = "BackPackForm";

        private const string BACK_BUTTON = "查看我的書包";
        private const string CONFIRM_BORROWING_BUTTON = "確認借書";
        private const string ADD_BOOK_BUTTON = "加入借書單";
        private const string LAST_PAGE_BUTTON = "上一頁";
        private const string NEXT_PAGE_BUTTON = "下一頁";

        private const string BOOK_INTRO_RICHTEXTBOX = "_bookIntroductionRichTextBox";
        private const string BORROWING_QUANTITY_LABEL = "_borrowingBookQuantityLabel";
        private const string REMAINING_QUANTITY_LABEL = "_remainingBookQuantityLabel";
        private const string PAGE_LABEL = "_pageLabel";


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

            _robot.ClickButtonByName("Book Borrowing System");
            _robot.SwitchTo(BORROWING_FORM);
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
        /// 測試 BackPackButton 點擊 enable 狀態
        /// </summary>
        [TestMethod]
        public void TestFormInitialize()
        {
            _robot.AssertEnableByName(BACK_BUTTON, true);
            _robot.AssertEnableByName(CONFIRM_BORROWING_BUTTON, false);
            _robot.AssertEnableByName(ADD_BOOK_BUTTON, false);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON, false);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON, true);
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX, "");
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL, "借書數量 : 0");
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL, "剩餘數量 : ");
            _robot.AssertTextById(PAGE_LABEL, "Page : 1 / 2");
        }

        /// <summary>
        /// 測試 BackPackButton 點擊 enable 狀態
        /// </summary>
        [TestMethod]
        public void TestBackPackButton()
        {
            _robot.AssertEnableByName(BACK_BUTTON, true);
            _robot.ClickButtonByName(BACK_BUTTON);
            _robot.AssertEnableByName(BACK_BUTTON, false);
            _robot.SwitchTo(BACK_FORM);
            _robot.CloseWindow();
            _robot.SwitchTo(BORROWING_FORM);
            _robot.AssertEnableByName(BACK_BUTTON, true);
        }
        
        /// <summary>
        /// 測試 BackPackButton 點擊 enable 狀態
        /// </summary>
        [TestMethod]
        public void TestBookButton()
        {
            string buttonId = "button0-0";
            _robot.AssertEnableById(buttonId, true);
            _robot.AssertVisibleById(buttonId, true);
            _robot.AssertEnableByName(ADD_BOOK_BUTTON, false);
            _robot.ClickButtonById(buttonId);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL, "剩餘數量 : 5");
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX, "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r編號 : 964 8394:2-5 2021\r作者 : ingectar-e\r原點出版 : 大雁發行, 2021[民110]");
            _robot.AssertEnableByName(ADD_BOOK_BUTTON, true);

            buttonId = "button0-1";
            _robot.AssertEnableById(buttonId, true);
            _robot.AssertVisibleById(buttonId, true);
            _robot.ClickButtonById(buttonId);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL, "剩餘數量 : 1");
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX, "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡\r編號 : 176.51 8564 2022\r作者 : 羅瑞塔.葛蕾吉亞諾.布魯\r閱樂國際文化出版");
            _robot.AssertEnableByName(ADD_BOOK_BUTTON, true);

            buttonId = "button0-2";
            _robot.AssertEnableById(buttonId, true);
            _robot.AssertVisibleById(buttonId, true);
            _robot.ClickButtonById(buttonId);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL, "剩餘數量 : 3");
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX, "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫\r編號 : 415.92 844 2021\r作者 : 艾德里安.雷恩\r遠流, 2021[民110]");
            _robot.AssertEnableByName(ADD_BOOK_BUTTON, true);
        }
    }
}
