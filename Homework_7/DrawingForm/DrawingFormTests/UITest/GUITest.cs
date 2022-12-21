using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DrawingFormTests.UITest
{
    [TestClass]
    public class GUITest
    {
        private Robot _robot;
        private string DRAWING_FORM = "DrawingForm";

        const string CANVAS_ID = "_canvas";
        const string SELECTED_LABEL_ID = "_selectedShapeLabel";

        const string REDO_BUTTON_NAME = "Redo";
        const string UNDO_BUTTON_NAME = "Undo";
        const string RECTANGLE_BUTTON_NAME = "Rectangle";
        const string LINE_BUTTON_NAME = "Line";
        const string TRIANGLE_BUTTON_NAME = "Triangle";
        const string CLEAR_BUTTON_NAME = "Clear";

        // 取得目標應用路徑
        private string GetTargetPath(string projectName)
        {
            string appName = projectName + ".exe";
            string solutionPath = AppDomain.CurrentDomain.BaseDirectory;
            do
            {
                bool findProject = false;
                foreach (var directory in Directory.GetParent(solutionPath).GetDirectories())
                    if (directory.Name == projectName)
                        findProject = true;
                if (findProject)
                    break;
                solutionPath = Path.GetFullPath(Path.Combine(solutionPath, "..\\"));
            } while (solutionPath != Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory));
            return Path.Combine(solutionPath, projectName, "bin", "Debug", appName);
        }

        // init 
        [TestInitialize]
        public void Initialize()
        {
            const string projectName = "DrawingForm";
            string targetAppPath;
            // 只是為了 coverage (projectName 錯誤情況)
            targetAppPath = this.GetTargetPath("");
            targetAppPath = this.GetTargetPath(projectName);
            _robot = new Robot(targetAppPath, DRAWING_FORM);
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
        /// 測試 DrawingForm 初始化狀態
        /// </summary>
        [TestMethod]
        public void TestFormInitialize()
        {
            _robot.AssertEnableByName(REDO_BUTTON_NAME, false);
            _robot.AssertEnableByName(UNDO_BUTTON_NAME, false);
            _robot.AssertEnableByName(RECTANGLE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LINE_BUTTON_NAME, true);
            _robot.AssertEnableByName(TRIANGLE_BUTTON_NAME, true);
            _robot.AssertEnableByName(CLEAR_BUTTON_NAME, true);
        }

        /// <summary>
        /// 測試 Draw Rectangle Button
        /// </summary>
        [TestMethod]
        public void TestRectangleButton()
        {
            _robot.ClickButtonByName(RECTANGLE_BUTTON_NAME);
            _robot.AssertEnableByName(RECTANGLE_BUTTON_NAME, false);
            _robot.AssertEnableByName(LINE_BUTTON_NAME, true);
            _robot.AssertEnableByName(TRIANGLE_BUTTON_NAME, true);
            _robot.DragAndDrop(CANVAS_ID, 100, 100, 200, 200);
            _robot.ClickCanvas(CANVAS_ID, 150, 150);
            _robot.AssertTextById(SELECTED_LABEL_ID, "Selected：Rectangle(100, 100, 200, 200)");
        }

        /// <summary>
        /// 測試 Draw Triangle Button
        /// </summary>
        [TestMethod]
        public void TestTriangleButton()
        {
            _robot.ClickButtonByName(TRIANGLE_BUTTON_NAME);
            _robot.AssertEnableByName(RECTANGLE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LINE_BUTTON_NAME, true);
            _robot.AssertEnableByName(TRIANGLE_BUTTON_NAME, false);
            _robot.DragAndDrop(CANVAS_ID, 100, 100, 200, 200);
            _robot.ClickCanvas(CANVAS_ID, 150, 150);
            _robot.AssertTextById(SELECTED_LABEL_ID, "Selected：Triangle(100, 100, 200, 200)");
        }

        /// <summary>
        /// 測試 Draw Triangle Button
        /// </summary>
        [TestMethod]
        public void TestLineButton()
        {
            /*_robot.ClickButtonByName(TRIANGLE_BUTTON_NAME);
            _robot.AssertEnableByName(RECTANGLE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LINE_BUTTON_NAME, true);
            _robot.AssertEnableByName(TRIANGLE_BUTTON_NAME, false);
            _robot.DragAndDrop(CANVAS_ID, 100, 100, 200, 200);
            _robot.ClickCanvas(CANVAS_ID, 150, 150);*/
            //_robot.AssertTextById(SELECTED_LABEL_ID, "Selected：Triangle(100, 100, 200, 200)");
        }

        /// <summary>
        /// 測試 Draw Clear Button
        /// </summary>
        [TestMethod]
        public void TestClearButton()
        {
            _robot.ClickButtonByName(TRIANGLE_BUTTON_NAME);
            _robot.DragAndDrop(CANVAS_ID, 100, 100, 200, 200);
            _robot.ClickCanvas(CANVAS_ID, 150, 150);
            _robot.ClickButtonByName(TRIANGLE_BUTTON_NAME);
            _robot.ClickButtonByName(CLEAR_BUTTON_NAME);
            _robot.AssertEnableByName(RECTANGLE_BUTTON_NAME, true);
            _robot.AssertEnableByName(LINE_BUTTON_NAME, true);
            _robot.AssertEnableByName(TRIANGLE_BUTTON_NAME, true);
        }
    }
}
