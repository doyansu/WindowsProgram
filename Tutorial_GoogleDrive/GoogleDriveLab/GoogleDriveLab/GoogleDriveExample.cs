using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleDriveUploader.GoogleDrive;
using System.IO;

namespace GoogleDriveUploader.View
{
    public partial class GoogleDriveExample : Form
    {
        private string _uploadFileName;
        private string _downloadPath;
        GoogleDriveService _service;

        public GoogleDriveExample()
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            InitializeComponent();

            _uploadButton.Enabled = false;
            _downloadButton.Enabled = false;
            _downloadBrowseButton.Enabled = false;
            _uploadFileOpenFileDialog.FileName = "";
            _uploadFileOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            _downloadFolderBrowserDialog.SelectedPath = Directory.GetCurrentDirectory();
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        private void ClickBrowseUploadFileButton(object sender, EventArgs e)
        {
            DialogResult result = _uploadFileOpenFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                _uploadButton.Enabled = true;
                _uploadFilePathTextBox.Text = _uploadFileOpenFileDialog.FileName;
                _uploadFileName = _uploadFileOpenFileDialog.FileName;
            }
        }

        private void ClickUploadButton(object sender, EventArgs e)
        {
            const string CONTENT_TYPE = "image/jpeg";
            _service.UploadFile(_uploadFileName, CONTENT_TYPE);
        }

        private void ClickListFileOnRootButton(object sender, EventArgs e)
        {
            const string DISPLAY_MEMBER = "Title";
            const string VALUE_MEMBER = "Id";
            const string FOLDER_MINE_TYPE = @"application/vnd.google-apps.folder";
            List<Google.Apis.Drive.v2.Data.File> rootFoldersFiles = _service.ListRootFileAndFolder();
            rootFoldersFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == FOLDER_MINE_TYPE;
            });

            _fileListBox.DisplayMember = DISPLAY_MEMBER;
            _fileListBox.ValueMember = VALUE_MEMBER;
            _fileListBox.DataSource = rootFoldersFiles;

            _downloadBrowseButton.Enabled = true;
        }

        private void ClickDownloadBrowseButton(object sender, EventArgs e)
        {
            DialogResult result = _downloadFolderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                _downloadPath = _downloadFolderBrowserDialog.SelectedPath;
                _downloadToTextBox.Text = _downloadPath;
                _downloadButton.Enabled = true;
            }
        }

        private void ClickDownloadButton(object sender, EventArgs e)
        {
            Google.Apis.Drive.v2.Data.File selectedFile = _fileListBox.SelectedItem as Google.Apis.Drive.v2.Data.File;
            _service.DownloadFile(selectedFile, _downloadPath);
        }

        private void ClickUpdateButton(object sender, EventArgs e)
        {
            const string UPDATE_FILE_NAME = "updateSample.jpeg";
            const string CONTENT_TYPE = "image/jpeg";
            const string FILE_TITLE_ON_DRIVE = "Sample.jpeg";

            List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => { return item.Title == FILE_TITLE_ON_DRIVE; });
            _service.UpdateFile(UPDATE_FILE_NAME, foundFile.Id, CONTENT_TYPE);
        }

        private void ClickDeleteButton(object sender, EventArgs e)
        {
            const string DELETE_FILE_ON_DRIVE_NAME = "Sample.jpeg";

            List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => { return item.Title == DELETE_FILE_ON_DRIVE_NAME; });

            _service.DeleteFile(foundFile.Id);
        }
    }
}
