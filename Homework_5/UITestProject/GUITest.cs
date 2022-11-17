using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UITestProject
{
    [TestClass]
    public class GUITest
    {
        private Robot _robot;
        private const string APP_NAME =
       "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string CALCULATOR_TITLE = "小算盤";
        private const string EXPECTED_VALUE = "顯示是 444";
        private const string RESULT_CONTROL_NAME = "CalculatorResults";

        private string targetAppPath;
        private const string START_UP_FORM = "StartUpForm";

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        // init 
        [TestInitialize]
        public void Initialize()
        {
            _robot = new Robot(APP_NAME, CALCULATOR_TITLE);

            /*var projectName = "LibraryManagementSystem";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "LibraryManagementSystem.exe");
            _robot = new Robot(targetAppPath, START_UP_FORM);*/
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
        /// Tests that the result of 123 + 321 should be 444
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            RunScriptAdd();
            _robot.AssertText(RESULT_CONTROL_NAME, EXPECTED_VALUE);
        }

        /// <summary>
        /// Runs the script: 123 + 321 =
        /// </summary>
        private void RunScriptAdd()
        {
            _robot.ClickButton("清除");
            _robot.ClickButton("一");
            _robot.ClickButton("二");
            _robot.ClickButton("三");
            _robot.ClickButton("加");
            _robot.ClickButton("三");
            _robot.ClickButton("二");
            _robot.ClickButton("一");
            _robot.ClickButton("等於");
        }
    }
}
