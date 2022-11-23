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
    public class InventoryFormGUITest
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
        private const string BACKPACK_DGV_ID = "_backPackDataGridView";

        private const string REMAINING_QUANTITY_LABEL_ID = "_remainingBookQuantityLabel";
        private const string ADDING_TEXTBOX_ID = "_addingQuantityTextBox";
        private const string CONFIRM_BUTTON_ID = "_confirmButton";
        private const string ADDINGBOOK_INFORMATION_RICHTEXTBOX_ID = "_addingBookInformationRichTextBox";

        private const string BACK_BUTTON_NAME = "查看我的書包";
        private const string CONFIRM_BORROWING_BUTTON_NAME = "確認借書";
        private const string ADD_BOOK_BUTTON_NAME = "加入借書單";



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

            _robot.ClickButtonByName("Book Inventory System");
            _robot.SwitchTo(INVENTORY_FORM);
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
        /// 測試 Inventory Form 初始化狀態
        /// </summary>
        [TestMethod]
        public void TestFormInitialize()
        {
            _robot.AssertDataGridViewRowCountBy(INVENTORY_DGV_ID, 20);
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 0, new string[] { "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "6月暢銷書", "5", "" });
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 4, new string[] { "煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊", "4月暢銷書", "4", "" });
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 9, new string[] { "常識...常錯! : 破除二十種對英文學習的大迷思", "英文學習", "3", "" });
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 17, new string[] { "關於工作的9大謊言", "職場必讀", "3", "" });
        }

        /// <summary>
        /// 測試書籍清單點擊
        /// </summary>
        [TestMethod]
        public void TestClickDGV()
        {
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 0, "書籍名稱");
            _robot.AssertTextById(INFORMATION_RICH_TEXTBOX_ID, "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r編號 : 964 8394:2-5 2021\r作者 : ingectar-e\r原點出版 : 大雁發行, 2021[民110]");
            
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 1, "書籍名稱");
            _robot.AssertTextById(INFORMATION_RICH_TEXTBOX_ID, "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡\r編號 : 176.51 8564 2022\r作者 : 羅瑞塔.葛蕾吉亞諾.布魯\r閱樂國際文化出版");
            
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 2, "書籍名稱");
            _robot.AssertTextById(INFORMATION_RICH_TEXTBOX_ID, "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫\r編號 : 415.92 844 2021\r作者 : 艾德里安.雷恩\r遠流, 2021[民110]");
        }

        /// <summary>
        /// 測試 Adding Form 書籍資訊
        /// </summary>
        [TestMethod]
        public void TestAddingFormBookInformation()
        {
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 0, "補貨");
            _robot.AssertTextById(ADDINGBOOK_INFORMATION_RICHTEXTBOX_ID, "書籍名稱 : 微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r\r書籍類別 : 6月暢銷書\r庫存數量 : 5");
            _robot.ClickButtonByName("取消");

            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 4, "補貨");
            _robot.AssertTextById(ADDINGBOOK_INFORMATION_RICHTEXTBOX_ID, "書籍名稱 : 煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊\r\r書籍類別 : 4月暢銷書\r庫存數量 : 4");
            _robot.ClickButtonByName("取消");

            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 9, "補貨");
            _robot.AssertTextById(ADDINGBOOK_INFORMATION_RICHTEXTBOX_ID, "書籍名稱 : 常識...常錯! : 破除二十種對英文學習的大迷思\r\r書籍類別 : 英文學習\r庫存數量 : 3");
            _robot.ClickButtonByName("取消");

            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 17, "補貨");
            _robot.AssertTextById(ADDINGBOOK_INFORMATION_RICHTEXTBOX_ID, "書籍名稱 : 關於工作的9大謊言\r\r書籍類別 : 職場必讀\r庫存數量 : 3");
            _robot.ClickButtonByName("取消");
        }

        /// <summary>
        /// 測試 取消補貨
        /// </summary>
        [TestMethod]
        public void TestUserCaseCancelAddingBook()
        {
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 1, "書籍名稱");
            _robot.AssertTextById(INFORMATION_RICH_TEXTBOX_ID, "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡\r編號 : 176.51 8564 2022\r作者 : 羅瑞塔.葛蕾吉亞諾.布魯\r閱樂國際文化出版");
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 1, new string[] { "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "6月暢銷書", "1", "" });
           
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 1, "補貨");
            _robot.AssertTextById(ADDINGBOOK_INFORMATION_RICHTEXTBOX_ID, "書籍名稱 : 創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡\r\r書籍類別 : 6月暢銷書\r庫存數量 : 1");
            _robot.ClickButtonByName("取消");
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 1, new string[] { "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "6月暢銷書", "1", "" });
        }

        /// <summary>
        /// 測試 完成補貨
        /// </summary>
        [TestMethod]
        public void TestUserCaseCompleteAddingBook()
        {
            _robot.SwitchTo(MENU_FORM);
            _robot.ClickButtonByName("Book Borrowing System");
            _robot.SwitchTo(BORROWING_FORM);
            _robot.ClickButtonById("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.SwitchTo(INVENTORY_FORM);
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 0, "補貨");
            _robot.SwitchTo(ADDING_FORM);
            _robot.ClickButtonById(ADDING_TEXTBOX_ID);
            _robot.PressKey("2");
            _robot.ClickButtonById(CONFIRM_BUTTON_ID);
            _robot.SwitchTo(INVENTORY_FORM);
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 0, new string[] { "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "6月暢銷書", "7", "" });
            _robot.SwitchTo(BORROWING_FORM);
            _robot.AssertTextById(REMAINING_QUANTITY_LABEL_ID, "剩餘數量 : 7");
        }

        /// <summary>
        /// 測試 借書還書更新庫存剩餘數量
        /// </summary>
        [TestMethod]
        public void TestUserCaseBorrowAndReturnBook()
        {
            _robot.SwitchTo(MENU_FORM);
            _robot.ClickButtonByName("Book Borrowing System");
            _robot.SwitchTo(BORROWING_FORM);
            _robot.ClickButtonByName(BACK_BUTTON_NAME);
            _robot.SwitchTo(BACK_FORM);
            _robot.SwitchTo(BORROWING_FORM);
            _robot.ClickButtonById("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.ClickButtonByName(CONFIRM_BORROWING_BUTTON_NAME);
            _robot.CloseMessageBox();
            _robot.SwitchTo(INVENTORY_FORM);
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 0, new string[] { "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "6月暢銷書", "4", "" });

            _robot.SwitchTo(BACK_FORM);
            _robot.ClickDataGridViewCellBy(BACKPACK_DGV_ID, 0, "還書");
            _robot.CloseMessageBox();
            _robot.SwitchTo(INVENTORY_FORM);
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 0, new string[] { "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "6月暢銷書", "5", "" });
        }
    }
}
