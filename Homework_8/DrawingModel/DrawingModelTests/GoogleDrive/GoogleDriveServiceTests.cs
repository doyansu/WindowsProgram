using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel.GoogleDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google;

namespace DrawingModel.GoogleDrive.Tests
{
    [TestClass()]
    public class GoogleDriveServiceTests
    {
        GoogleDriveService _googleDriveService;
        const string APPLICATION_NAME = "DrawingForm";
        const string CLIENT_SECRET_FILE_NAME = @"./GoogleDrive/clientSecret.json";
        const string TEMP_FILE_NAME = "DrawingShapes.txt";
        const string CONTENT_TYPE = "text/xml";
        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _googleDriveService = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        // TestGoogleDriveService
        [TestMethod()]
        public void TestGoogleDriveService()
        {
            
        }

        // TestListRootFileAndFolder
        [TestMethod()]
        public void TestListRootFileAndFolder()
        {
            _googleDriveService.ListRootFileAndFolder();
        }

        // TestDeleteFile
        [TestMethod()]
        public void TestDeleteFile()
        {
            Assert.ThrowsException<GoogleApiException>(() => _googleDriveService.DeleteFile(""));
        }

        // TestUploadFile
        [TestMethod()]
        public void TestUploadFile()
        {
            string content = "";
            _googleDriveService.UploadFile(TEMP_FILE_NAME, content, CONTENT_TYPE);
            _googleDriveService.UploadFile(TEMP_FILE_NAME, content, CONTENT_TYPE);
        }

        // TestReadFile
        [TestMethod()]
        public void TestReadFile()
        {
            _googleDriveService.ReadFile(TEMP_FILE_NAME);
        }

        // TestIsContain
        [TestMethod()]
        public void TestIsContain()
        {
            Assert.IsFalse(_googleDriveService.IsContain(""));
        }
    }
}