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
        private string currentImageDirPath;

        private const string MENU_FORM = "Menu";
        private const string BORROWING_FORM = "BookBorrowingFrom";
        private const string INVENTORY_FORM = "BookInventoryForm";
        private const string MANAGEREMENT_FORM = "BookManagementForm";
        private const string BACK_FORM = "BackPackForm";
        private const string ADDING_FORM = "BookAddingForm";

        private const string SAVE_BUTTON_NAME = "儲存";
        private const string BROWSE_BUTTON_NAME = "瀏覽";
        private const string NEW_BOOK_BUTTON_NAME = "新增書籍";

        private const string BOOK_LISTBOX_ID = "_bookListBox";
        private const string BOOK_NAME_TEXTBOX_ID = "_bookNameTextBox";
        private const string BOOK_ISBN_TEXTBOX_ID = "_bookNumberTextBox";
        private const string BOOK_AUTHOR_TEXTBOX_ID = "_bookAuthorTextBox";
        private const string BOOK_CATEGORY_COMBOBOX_ID = "_bookCategoryComboBox";
        private const string BOOK_PUBLICATION_TEXTBOX_ID = "_bookPublicationItemTextBox";
        private const string BOOK_IMAGE_PATH_TEXTBOX_ID = "_bookImagePathTextBox";

        private const string INVENTORY_DGV_ID = "_bookInformationDataGridView";
        private const string INFORMATION_RICH_TEXTBOX_ID = "_bookInformationRichTextBox";

        private const string BACK_BUTTON_NAME = "查看我的書包";
        private const string CONFIRM_BORROWING_BUTTON_NAME = "確認借書";
        private const string ADD_BOOK_BUTTON_NAME = "加入借書單";
        private const string LAST_PAGE_BUTTON_NAME = "上一頁";
        private const string NEXT_PAGE_BUTTON_NAME = "下一頁";
        private const string BOOK_INTRO_RICHTEXTBOX_ID = "_bookIntroductionRichTextBox";
        private const string BORROWING_LIST_DGV_ID = "_bookInformationDataGridView";
        private const string BACKPACK_DGV_ID = "_backPackDataGridView";

        readonly string[] _bookCategoryList = {
            "6月暢銷書",
            "4月暢銷書",
            "英文學習",
            "職場必讀" };

        // 取得
        private string GetSolutionPath(string projectName)
        {
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
            return solutionPath;
        }

        // 取得目標應用路徑
        private string GetTargetPath(string projectName)
        {
            string appName = projectName + ".exe";
            string solutionPath = this.GetSolutionPath(projectName);
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

            currentImageDirPath = Path.Combine(this.GetSolutionPath(projectName), "image"); 
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
            _robot.AssertDataGridViewRowCountBy(BOOK_LISTBOX_ID, 20);
            _robot.AssertEnableById(BOOK_NAME_TEXTBOX_ID, false);
            _robot.AssertEnableById(BOOK_ISBN_TEXTBOX_ID, false);
            _robot.AssertEnableById(BOOK_AUTHOR_TEXTBOX_ID, false);
            _robot.AssertEnableById(BOOK_CATEGORY_COMBOBOX_ID, false);
            _robot.AssertEnableById(BOOK_PUBLICATION_TEXTBOX_ID, false);
            _robot.AssertEnableById(BOOK_IMAGE_PATH_TEXTBOX_ID, false);

            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);
            _robot.AssertEnableByName(BROWSE_BUTTON_NAME, false);
            _robot.AssertEnableByName(NEW_BOOK_BUTTON_NAME, false);

            _robot.AssertTextById(BOOK_NAME_TEXTBOX_ID, "");
            _robot.AssertTextById(BOOK_ISBN_TEXTBOX_ID, "");
            _robot.AssertTextById(BOOK_AUTHOR_TEXTBOX_ID, "");
            _robot.AssertTextById(BOOK_CATEGORY_COMBOBOX_ID, "");
            _robot.AssertTextById(BOOK_PUBLICATION_TEXTBOX_ID, "");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, "");
        }

        /// <summary>
        /// 測試 點擊清單內容
        /// </summary>
        [TestMethod]
        public void TestClickListBox()
        {
            _robot.ClickButtonByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.AssertEnableById(BOOK_NAME_TEXTBOX_ID, true);
            _robot.AssertEnableById(BOOK_ISBN_TEXTBOX_ID, true);
            _robot.AssertEnableById(BOOK_AUTHOR_TEXTBOX_ID, true);
            _robot.AssertEnableById(BOOK_CATEGORY_COMBOBOX_ID, true);
            _robot.AssertEnableById(BOOK_PUBLICATION_TEXTBOX_ID, true);
            _robot.AssertEnableById(BOOK_IMAGE_PATH_TEXTBOX_ID, true);

            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);
            _robot.AssertEnableByName(BROWSE_BUTTON_NAME, true);
            _robot.AssertEnableByName(NEW_BOOK_BUTTON_NAME, false);

            _robot.AssertTextById(BOOK_NAME_TEXTBOX_ID, "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.AssertTextById(BOOK_ISBN_TEXTBOX_ID, "964 8394:2-5 2021");
            _robot.AssertTextById(BOOK_AUTHOR_TEXTBOX_ID, "ingectar-e");
            _robot.AssertTextById(BOOK_CATEGORY_COMBOBOX_ID, "6月暢銷書");
            _robot.AssertTextById(BOOK_PUBLICATION_TEXTBOX_ID, "原點出版 : 大雁發行, 2021[民110]");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "1.jpg"));

            _robot.ClickButtonByName("煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊");
            _robot.AssertTextById(BOOK_NAME_TEXTBOX_ID, "煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊");
            _robot.AssertTextById(BOOK_ISBN_TEXTBOX_ID, "177.3 8333:3 2022");
            _robot.AssertTextById(BOOK_AUTHOR_TEXTBOX_ID, "艾米.馬洛-麥柯");
            _robot.AssertTextById(BOOK_CATEGORY_COMBOBOX_ID, "4月暢銷書");
            _robot.AssertTextById(BOOK_PUBLICATION_TEXTBOX_ID, "麥田出版 : 家庭傳媒城邦分公司發行, 2022[民111]");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "5.jpg"));

            _robot.ClickButtonByName("常識...常錯! : 破除二十種對英文學習的大迷思");
            _robot.AssertTextById(BOOK_NAME_TEXTBOX_ID, "常識...常錯! : 破除二十種對英文學習的大迷思");
            _robot.AssertTextById(BOOK_ISBN_TEXTBOX_ID, "813.52 F553g 1991");
            _robot.AssertTextById(BOOK_AUTHOR_TEXTBOX_ID, "宋敏");
            _robot.AssertTextById(BOOK_CATEGORY_COMBOBOX_ID, "英文學習");
            _robot.AssertTextById(BOOK_PUBLICATION_TEXTBOX_ID, "漩渦文化, 2000[民89]");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "10.jpg"));

            _robot.ClickButtonByName("關於工作的9大謊言");
            _robot.AssertTextById(BOOK_NAME_TEXTBOX_ID, "關於工作的9大謊言");
            _robot.AssertTextById(BOOK_ISBN_TEXTBOX_ID, "494.01 8566 2019 c.2");
            _robot.AssertTextById(BOOK_AUTHOR_TEXTBOX_ID, "巴金漢 (Buckingham, Marcus)");
            _robot.AssertTextById(BOOK_CATEGORY_COMBOBOX_ID, "職場必讀");
            _robot.AssertTextById(BOOK_PUBLICATION_TEXTBOX_ID, "星出版, 2019[民108]");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "18.jpg"));
        }

        /// <summary>
        /// 測試 瀏覽按鈕點擊功能
        /// </summary>
        [TestMethod]
        public void TestClickBrowseButton()
        {
            _robot.ClickButtonByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.ClickButtonByName(BROWSE_BUTTON_NAME);
            _robot.ClickButtonByName("2.jpg");
            _robot.ClickButtonByName("取消");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "1.jpg"));

            _robot.ClickButtonByName(BROWSE_BUTTON_NAME);
            _robot.ClickButtonByName("2.jpg");
            _robot.ClickButtonByName("開啟(O)");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "2.jpg"));

            _robot.ClickButtonByName(BROWSE_BUTTON_NAME);
            _robot.ClickButtonByName("20.jpg");
            _robot.ClickButtonByName("開啟(O)");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "20.jpg"));

            _robot.ClickButtonByName(BROWSE_BUTTON_NAME);
            _robot.ClickButtonByName("NewBook.jpg");
            _robot.ClickButtonByName("開啟(O)");
            _robot.AssertTextById(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "NewBook.jpg"));
        }

        /// <summary>
        /// 測試 儲存按鈕 狀態
        /// </summary>
        [TestMethod]
        public void TestSaveButton()
        {
            const string NEW_INFO = "new info";
            _robot.ClickButtonByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            EditInfoScript(BOOK_NAME_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);
            EditInfoScript(BOOK_NAME_TEXTBOX_ID, "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);

            EditInfoScript(BOOK_ISBN_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);
            EditInfoScript(BOOK_ISBN_TEXTBOX_ID, "964 8394:2-5 2021");
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);

            EditInfoScript(BOOK_AUTHOR_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);
            EditInfoScript(BOOK_AUTHOR_TEXTBOX_ID, "ingectar-e");
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);

            _robot.ClickButtonById(BOOK_CATEGORY_COMBOBOX_ID);
            _robot.ClickButtonByName(_bookCategoryList[1]);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);
            _robot.ClickButtonById(BOOK_CATEGORY_COMBOBOX_ID);
            _robot.ClickButtonByName(_bookCategoryList[0]);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);

            EditInfoScript(BOOK_PUBLICATION_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);
            EditInfoScript(BOOK_PUBLICATION_TEXTBOX_ID, "原點出版 : 大雁發行, 2021[民110]");
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);

            EditInfoScript(BOOK_IMAGE_PATH_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);
            EditInfoScript(BOOK_IMAGE_PATH_TEXTBOX_ID, Path.Combine(currentImageDirPath, "1.jpg"));
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);

            _robot.ClickButtonById(BOOK_CATEGORY_COMBOBOX_ID);
            _robot.ClickButtonByName(_bookCategoryList[1]);

            EditInfoScript(BOOK_NAME_TEXTBOX_ID, null);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);
            EditInfoScript(BOOK_NAME_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);

            EditInfoScript(BOOK_ISBN_TEXTBOX_ID, null);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);
            EditInfoScript(BOOK_ISBN_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);

            EditInfoScript(BOOK_AUTHOR_TEXTBOX_ID, null);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);
            EditInfoScript(BOOK_AUTHOR_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);

            EditInfoScript(BOOK_PUBLICATION_TEXTBOX_ID, null);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);
            EditInfoScript(BOOK_PUBLICATION_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);

            EditInfoScript(BOOK_IMAGE_PATH_TEXTBOX_ID, null);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, false);
            EditInfoScript(BOOK_IMAGE_PATH_TEXTBOX_ID, NEW_INFO);
            _robot.AssertEnableByName(SAVE_BUTTON_NAME, true);
        }

        /// <summary>
        /// 測試 儲存編輯資訊同步更新到借書視窗
        /// </summary>
        [TestMethod]
        public void TestSaveUpdateToBorrowingForm()
        {
            DateTime dateTime = DateTime.Now;
            string borrowingDate = dateTime.ToShortDateString();
            string Due = dateTime.AddDays(30).ToShortDateString();

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
            _robot.ClickButtonById("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.ClickButtonByName(ADD_BOOK_BUTTON_NAME);
            _robot.SwitchTo(MANAGEREMENT_FORM);
            EditInfoForSaveScript();
            _robot.AssertTextByName("原子習慣", "原子習慣");

            _robot.SwitchTo(BACK_FORM);
            _robot.AssertDataGridViewRowDataBy(BACKPACK_DGV_ID, 0, new string[] { "歸還", "1", "原子習慣", "1", borrowingDate, Due, "1234567", "James Clear", "原點出版 : 大雁發行, 2021[民110]" });

            _robot.SwitchTo(BORROWING_FORM);
            _robot.AssertVisibleById("創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", true);
            _robot.AssertVisibleById("暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", true);
            _robot.AssertVisibleById("零零落落", true);
            _robot.AssertEnableByName(NEXT_PAGE_BUTTON_NAME, false);
            _robot.AssertDataGridViewRowDataBy(BORROWING_LIST_DGV_ID, 0, new string[] { "", "原子習慣", "1", "1234567", "James Clear", "原點出版 : 大雁發行, 2021[民110]" });

            _robot.ClickTabControl("職場必讀");
            _robot.ClickButtonById("原子習慣");
            _robot.AssertTextById(BOOK_INTRO_RICHTEXTBOX_ID, "原子習慣\r編號 : 1234567\r作者 : James Clear\r原點出版 : 大雁發行, 2021[民110]");
        }

        /// <summary>
        /// 測試 儲存編輯資訊同步更新到庫存視窗
        /// </summary>
        [TestMethod]
        public void TestSaveUpdateToInventoryForm()
        {
            _robot.SwitchTo(MENU_FORM);
            _robot.ClickButtonByName("Book Inventory System");
            _robot.SwitchTo(INVENTORY_FORM);
            _robot.SwitchTo(MANAGEREMENT_FORM);
            EditInfoForSaveScript();
            _robot.AssertTextByName("原子習慣", "原子習慣");

            _robot.SwitchTo(INVENTORY_FORM);
            _robot.ClickDataGridViewCellBy(INVENTORY_DGV_ID, 0, "書籍名稱");
            _robot.AssertDataGridViewRowDataBy(INVENTORY_DGV_ID, 0, new string[] { "原子習慣", "職場必讀", "5", "" });
            _robot.AssertTextById(INFORMATION_RICH_TEXTBOX_ID, "原子習慣\r編號 : 1234567\r作者 : James Clear\r原點出版 : 大雁發行, 2021[民110]");
        }

        // 編輯資料腳本
        private void EditInfoForSaveScript()
        {
            _robot.ClickButtonByName("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            EditInfoScript(BOOK_ISBN_TEXTBOX_ID, "1234567");
            EditInfoScript(BOOK_NAME_TEXTBOX_ID, "原子習慣");
            EditInfoScript(BOOK_AUTHOR_TEXTBOX_ID, "James Clear");
            _robot.ClickButtonById(BOOK_CATEGORY_COMBOBOX_ID);
            _robot.ClickButtonByName(_bookCategoryList[3]);
            _robot.ClickButtonByName(SAVE_BUTTON_NAME);
        }

        // 編輯資料腳本
        private void EditInfoScript(string contrlId, string editContent)
        {
            const string SELECT_ALL = "^a";
            const string DELETE = "{DELETE}";
            _robot.ClickButtonById(contrlId);
            _robot.PressKey(SELECT_ALL);
            if (editContent != null)
                _robot.PressKey(editContent);
            else
                _robot.PressKey(DELETE);
        }
    }
}
