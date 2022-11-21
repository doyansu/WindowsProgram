using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private const string BACK_BUTTON_NAME = "查看我的書包";
        private const string CONFIRM_BORROWING_BUTTON_NAME = "確認借書";
        private const string ADD_BOOK_BUTTON_NAME = "加入借書單";
        private const string LAST_PAGE_BUTTON_NAME = "上一頁";
        private const string NEXT_PAGE_BUTTON_NAME = "下一頁";

        private const string BOOK_INTRO_RICHTEXTBOX_ID = "_bookIntroductionRichTextBox";
        private const string BORROWING_QUANTITY_LABEL_ID = "_borrowingBookQuantityLabel";
        private const string REMAINING_QUANTITY_LABEL_ID = "_remainingBookQuantityLabel";
        private const string PAGE_LABEL_ID = "_pageLabel";
        private const string BORROWING_LIST_DGV_ID = "_bookInformationDataGridView"; 
        private const string BACKPACK_DGV_ID = "_backPackDataGridView"; 

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
        /// 測試 Borrowing Form 初始化狀態
        /// </summary>
        [TestMethod]
        public void TestFormInitialize()
        {
            _robot.AssertEnableByName(BACK_BUTTON_NAME, true);
            _robot.AssertEnableByName(CONFIRM_BORROWING_BUTTON_NAME, false);
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, false);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, false);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX_ID, "");
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 0");
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : ");
            _robot.AssertTextById(PAGE_LABEL_ID, "Page : 1 / 2");
        }

        /// <summary>
        /// 測試 BackPackButton 點擊 enable 狀態
        /// </summary>
        [TestMethod]
        public void TestBackPackButton()
        {
            _robot.AssertEnableByName(BACK_BUTTON_NAME, true);

            _robot.ClickButtonByName(BACK_BUTTON_NAME);
            _robot.AssertEnableByName(BACK_BUTTON_NAME, false);

            _robot.SwitchTo(BACK_FORM);
            _robot.CloseWindow();
            _robot.SwitchTo(BORROWING_FORM);
            _robot.AssertEnableByName(BACK_BUTTON_NAME, true);
        }

        /// <summary>
        /// 測試 BookButton 點擊 狀態
        /// </summary>
        [TestMethod]
        public void TestBookButton()
        {
            string buttonId = "bookButton0-0";
            _robot.AssertEnableById(buttonId, true);
            _robot.AssertVisibleById(buttonId, true);
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, false);

            _robot.ClickButtonById(buttonId);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 5");
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX_ID, "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r編號 : 964 8394:2-5 2021\r作者 : ingectar-e\r原點出版 : 大雁發行, 2021[民110]");
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, true);

            buttonId = "bookButton0-1";
            _robot.AssertEnableById(buttonId, true);
            _robot.AssertVisibleById(buttonId, true);

            _robot.ClickButtonById(buttonId);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 1");
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX_ID, "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡\r編號 : 176.51 8564 2022\r作者 : 羅瑞塔.葛蕾吉亞諾.布魯\r閱樂國際文化出版");
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, true);

            buttonId = "bookButton0-2";
            _robot.AssertEnableById(buttonId, true);
            _robot.AssertVisibleById(buttonId, true);

            _robot.ClickButtonById(buttonId);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 3");
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX_ID, "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫\r編號 : 415.92 844 2021\r作者 : 艾德里安.雷恩\r遠流, 2021[民110]");
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, true);
        }

        /// <summary>
        /// 測試 書籍分類 TabControl 點擊 狀態
        /// </summary>
        [TestMethod]
        public void TestTabControl()
        {
            _robot.ClickTabControl(_bookCategoryList[0]);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, false);
            _robot.AssertVisibleById("bookButton0-0", true);
            _robot.AssertVisibleById("bookButton0-1", true);
            _robot.AssertVisibleById("bookButton0-2", true);

            _robot.ClickTabControl(_bookCategoryList[1]);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, false);
            _robot.AssertVisibleById("bookButton1-0", true);
            _robot.AssertVisibleById("bookButton1-1", true);
            _robot.AssertVisibleById("bookButton1-2", true);

            _robot.ClickTabControl(_bookCategoryList[2]);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, false);
            _robot.AssertVisibleById("bookButton2-0", true);
            _robot.AssertVisibleById("bookButton2-1", true);
            _robot.AssertVisibleById("bookButton2-2", true);

            _robot.ClickTabControl(_bookCategoryList[3]);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, false);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, false);
            _robot.AssertVisibleById("bookButton3-0", true);
            _robot.AssertVisibleById("bookButton3-1", true);
            _robot.AssertVisibleById("bookButton3-2", true);
        }

        /// <summary>
        /// 測試 PageButton 點擊 狀態
        /// </summary>
        [TestMethod]
        public void TestPageButton()
        {
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, false);
            _robot.AssertVisibleById("bookButton0-0", true);
            _robot.AssertVisibleById("bookButton0-1", true);
            _robot.AssertVisibleById("bookButton0-2", true);

            _robot.ClickButtonByName(NEXT_PAGE_BUTTON_NAME);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, false);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, true);
            _robot.AssertVisibleById("bookButton0-3", true);

            _robot.ClickButtonByName(LAST_PAGE_BUTTON_NAME);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, false);
            _robot.AssertVisibleById("bookButton0-0", true);
            _robot.AssertVisibleById("bookButton0-1", true);
            _robot.AssertVisibleById("bookButton0-2", true);

            _robot.ClickTabControl(_bookCategoryList[2]);
            _robot.ClickButtonByName(NEXT_PAGE_BUTTON_NAME);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, true);
            _robot.AssertVisibleById("bookButton2-3", true);
            _robot.AssertVisibleById("bookButton2-4", true);
            _robot.AssertVisibleById("bookButton2-5", true);

            _robot.ClickButtonByName(NEXT_PAGE_BUTTON_NAME);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, false);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, true);
            _robot.AssertVisibleById("bookButton2-6", true);
            _robot.AssertVisibleById("bookButton2-7", true);

            _robot.ClickButtonByName(LAST_PAGE_BUTTON_NAME);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LAST_PAGE_BUTTON_NAME, true);
            _robot.AssertVisibleById("bookButton2-3", true);
            _robot.AssertVisibleById("bookButton2-4", true);
            _robot.AssertVisibleById("bookButton2-5", true);
        }

        /// <summary>
        /// 測試 加入借書單按鈕 點擊 狀態
        /// </summary>
        [TestMethod]
        public void TestAddButton()
        {
            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 1");
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 1);
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 0, new string[] { "", "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "1", "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]" });
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, false);

            _robot.ClickButtonById("bookButton0-1");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 2");
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 2);
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 1, new string[] { "", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" });
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, false);

            _robot.ClickButtonById("bookButton0-2");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 3");
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 3);
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 2, new string[] { "", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" });
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, false);
        }

        /// <summary>
        /// 測試 借書單刪除按鈕 點擊 狀態
        /// </summary>
        [TestMethod]
        public void TestDeleteButton()
        {
            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonById("bookButton0-1");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonById("bookButton0-2");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);

            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 0, "刪除");
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 2);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 2");
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 0, new string[] { "", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" });
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 1, new string[] { "", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" });
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, true);

            _robot.ClickButtonById("bookButton0-2");
            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 1, "刪除");
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 1);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 1");
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 0, new string[] { "", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" });
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, true);

            _robot.ClickButtonById("bookButton0-1");
            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 0, "刪除");
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 0);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 0");
            _robot.AssertEnableByName(ADD_BOOK_BUTTON_NAME, true);
            _robot.AssertEnableByName(CONFIRM_BORROWING_BUTTON_NAME, false);
        }

        /// <summary>
        /// 測試 使用者改變借書數量
        /// </summary>
        [TestMethod]
        public void TestUserCaseChangeBorrowingCount()
        {
            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonById("bookButton0-1");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonById("bookButton0-2");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickTabControl(_bookCategoryList[1]);
            _robot.ClickButtonById("bookButton1-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);

            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 0, "數量", 2);
            _robot.ClickButtonByName("Up", 2);
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 0, new string[] { "", "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "3", "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]" });
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 6");
            _robot.AssertMessageBoxTitle("借書違規");
            _robot.AssertMessageBoxText("同一本書一次限借2本");
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 0, new string[] { "", "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "2", "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]" });
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 5");

            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 1, "數量", 2);
            _robot.ClickButtonByName("Up", 1);
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 1, new string[] { "", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "2", "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" });
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 6");
            _robot.AssertMessageBoxTitle("庫存狀態");
            _robot.AssertMessageBoxText("該書本剩餘數量不足");
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 1, new string[] { "", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" });
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 5");

            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 2, "數量", 2);
            _robot.ClickButtonByName("Up", 1);
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 2, new string[] { "", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "2", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" });
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 6");
            _robot.AssertMessageBoxTitle("借書違規");
            _robot.AssertMessageBoxText("每次借書限借五本，您的借書單已滿");
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 2, new string[] { "", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" });
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 5");

            _robot.ClickButtonById("bookButton1-1");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.AssertMessageBoxTitle("借書違規");
            _robot.AssertMessageBoxText("每次借書限借五本，您的借書單已滿");
            _robot.CloseMessageBox();
        }

        /// <summary>
        /// 測試 使用者確認借書
        /// </summary>
        [TestMethod]
        public void TestUserCaseConfirmBorrowing()
        {
            DateTime dateTime = DateTime.Now;
            string borrowingDate = dateTime.ToShortDateString(); 
            string Due = dateTime.AddDays(30).ToShortDateString();

            _robot.ClickButtonByName(BACK_BUTTON_NAME);
            _robot.SwitchTo(BACK_FORM);
            _robot.SwitchTo(BORROWING_FORM);
            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);

            _robot.ClickButtonByName(CONFIRM_BORROWING_BUTTON_NAME);
            _robot.AssertMessageBoxTitle("借書結果");
            _robot.AssertMessageBoxText("[微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書] 1本\n\n已成功借出!");
            
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 0);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 0");
            
            _robot.ClickButtonById("bookButton0-0");
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 4");
            
            _robot.SwitchTo(BACK_FORM);
            _robot.AssertDataGridViewRowCountBy(BACKPACK_DGV_ID, 1);
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 0, new string[] { "歸還", "1", "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "1", borrowingDate, Due, "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]" });

            _robot.SwitchTo(BORROWING_FORM);
            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonById("bookButton0-1");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonById("bookButton0-2");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 0, "數量", 2);
            _robot.ClickButtonByName("Up", 1);
            _robot.ClickButtonByName(CONFIRM_BORROWING_BUTTON_NAME);
            _robot.AssertMessageBoxTitle("借書結果");
            _robot.AssertMessageBoxText("[微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書] 2本 、 [創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡] 1本 、 [暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫] 1本\n\n已成功借出!");
            
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowCountBy(BORROWING_LIST_DGV_ID, 0);
            _robot.AssertTextById(BORROWING_QUANTITY_LABEL_ID, "借書數量 : 0");
            _robot.ClickButtonById("bookButton0-0");
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 2");
            _robot.ClickButtonById("bookButton0-1");
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 0");
            _robot.ClickButtonById("bookButton0-2");
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 2");

            _robot.SwitchTo(BACK_FORM);
            _robot.AssertDataGridViewRowCountBy(BACKPACK_DGV_ID, 4);
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 0, new string[] { "歸還", "1", "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "1", borrowingDate, Due, "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]" });
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 1, new string[] { "歸還", "1", "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "2", borrowingDate, Due, "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]" });
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 2, new string[] { "歸還", "1", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", borrowingDate, Due, "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" });
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 3, new string[] { "歸還", "1", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", borrowingDate, Due, "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" });
        }

        /// <summary>
        /// 測試 使用者變更歸還書籍數量
        /// </summary>
        [TestMethod]
        public void TestUserCaseChangeReturnCount()
        {
            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 0, "數量", 2);
            _robot.ClickButtonByName("Up", 1);
            _robot.ClickButtonByName(CONFIRM_BORROWING_BUTTON_NAME);
            _robot.CloseMessageBox();
            _robot.ClickButtonByName(BACK_BUTTON_NAME);
            _robot.SwitchTo(BACK_FORM);
            _robot.ClickDataGridViewCellBy(BACKPACK_DGV_ID, 0, "歸還數量", 2);

            _robot.ClickButtonByName("Down", 1);
            _robot.AssertDataGridViewCellValueBy(BACKPACK_DGV_ID, 0, 1, "0");
            _robot.AssertMessageBoxTitle("還書錯誤");
            _robot.AssertMessageBoxText("您至少要歸還1本書");

            _robot.CloseMessageBox();
            _robot.AssertDataGridViewCellValueBy(BACKPACK_DGV_ID, 0, 1, "1");

            _robot.ClickButtonByName("Up", 2);
            _robot.AssertDataGridViewCellValueBy(BACKPACK_DGV_ID, 0, 1, "3");
            _robot.AssertMessageBoxTitle("還書錯誤");
            _robot.AssertMessageBoxText("還書數量不能超過已借數量");

            _robot.CloseMessageBox();
            _robot.AssertDataGridViewCellValueBy(BACKPACK_DGV_ID, 0, 1, "2");
        }

        /// <summary>
        /// 測試 使用者歸還書籍
        /// </summary>
        [TestMethod]
        public void TestUserCaseReturnBook()
        {
            DateTime dateTime = DateTime.Now;
            string borrowingDate = dateTime.ToShortDateString();
            string Due = dateTime.AddDays(30).ToShortDateString();

            _robot.ClickButtonById("bookButton0-0");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonById("bookButton0-2");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 0, "數量", 2);
            _robot.ClickButtonByName("Up", 1);
            _robot.ClickDataGridViewCellBy(BORROWING_LIST_DGV_ID, 1, "數量", 2);
            _robot.ClickButtonByName("Up", 1);
            _robot.ClickButtonByName(CONFIRM_BORROWING_BUTTON_NAME);
            _robot.CloseMessageBox();
            _robot.ClickButtonByName(BACK_BUTTON_NAME);
            _robot.SwitchTo(BACK_FORM);

            _robot.ClickDataGridViewCellBy(BACKPACK_DGV_ID, 1, "還書");
            _robot.AssertMessageBoxTitle("歸還結果");
            _robot.AssertMessageBoxText("[暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫] 已成功歸還1本");
            
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowCountBy(BACKPACK_DGV_ID, 2);
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 0, new string[] { "歸還", "1", "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "2", borrowingDate, Due, "964 8394:2-5 2021", "ingectar-e", "原點出版 : 大雁發行, 2021[民110]" });
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 1, new string[] { "歸還", "1", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", borrowingDate, Due, "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" });

            _robot.SwitchTo(BORROWING_FORM);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 2");

            _robot.ClickButtonById("bookButton0-0");
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 3");

            _robot.SwitchTo(BACK_FORM);
            _robot.ClickDataGridViewCellBy(BACKPACK_DGV_ID, 0, "歸還數量", 2);
            _robot.ClickButtonByName("Up", 1);
            _robot.ClickDataGridViewCellBy(BACKPACK_DGV_ID, 0, "還書");
            _robot.AssertMessageBoxTitle("歸還結果");
            _robot.AssertMessageBoxText("[微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書] 已成功歸還2本");

            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowCountBy(BACKPACK_DGV_ID, 1);
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 0, new string[] { "歸還", "1", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", borrowingDate, Due, "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" });

            _robot.SwitchTo(BORROWING_FORM);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 5");
        }
    }
}
