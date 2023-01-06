using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Download;
using Google.Apis.Drive.v2.Data;
using System.Net;

namespace DrawingModel.GoogleDrive
{
    public class GoogleDriveService : IFileBaseService
    {
        private readonly string[] _scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService _service;
        private const int KB = 0x400;
        private const int DOWNLOAD_CHUNK_SIZE = 256 * KB;
        private int _timeStamp;
        private string _applicationName;
        private string _clientSecretFileName;
        private UserCredential _credential;

        /// <summary>
        /// 創造一個Google Drive Service
        /// </summary>
        /// <param name="applicationName">應用程式名稱</param>
        /// <param name="clientSecretFileName">ClientSecret檔案名稱</param>
        public GoogleDriveService(string applicationName, string clientSecretFileName)
        {
            _applicationName = applicationName;
            _clientSecretFileName = clientSecretFileName;
            this.CreateNewService(applicationName, clientSecretFileName);
        }

        // CreateNewService
        private void CreateNewService(string applicationName, string clientSecretFileName)
        {
            const string USER = "user";
            const string CREDENTIAL_FOLDER = ".credential/";
            UserCredential credential;
            using (FileStream stream = new FileStream(clientSecretFileName, FileMode.Open, FileAccess.Read))
            {
                string credentialPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credentialPath = Path.Combine(credentialPath, CREDENTIAL_FOLDER + applicationName);
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, _scopes, USER, CancellationToken.None, new FileDataStore(credentialPath, true)).Result;
            }
            DriveService service = new DriveService(new BaseClientService.Initializer() 
            { 
                HttpClientInitializer = credential,
                ApplicationName = applicationName });
            _credential = credential;
            DateTime now = DateTime.Now;
            _timeStamp = UNIXNowTimeStamp;
            _service = service;
        }

        private int UNIXNowTimeStamp
        {
            get
            {
                const int UNIX_START_YEAR = 1970;
                DateTime unixStartTime = new DateTime(UNIX_START_YEAR, 1, 1);
                return Convert.ToInt32((DateTime.Now.Subtract(unixStartTime).TotalSeconds));
            }
        }

        //Check and refresh the credential if credential is out-of-date
        private void CheckCredentialTimeStamp()
        {
            const int ONE_HOUR_SECOND = 3600;
            int nowTimeStamp = UNIXNowTimeStamp;

            if ((nowTimeStamp - _timeStamp) > ONE_HOUR_SECOND)
                this.CreateNewService(_applicationName, _clientSecretFileName);
        }

        /// <summary>
        /// 查詢Google Drive 根目錄的檔案
        /// </summary>
        /// <returns>Google Drive File List</returns>
        public List<Google.Apis.Drive.v2.Data.File> ListRootFileAndFolder()
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            const string ROOT_QUERY_STRING = "'root' in parents";

            try
            {
                returnList = ListFileAndFolderWithQueryString(ROOT_QUERY_STRING);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return returnList;
        }

        /// <summary>
        /// 使用QueryString 查詢檔案 回傳一List
        /// </summary>
        /// <param name="queryString">QueryString，使用方法: https://developers.google.com/drive/web/search-parameters </param>
        /// <returns>含有Google Drive File 格式的 List</returns>
        private List<Google.Apis.Drive.v2.Data.File> ListFileAndFolderWithQueryString(string queryString)
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            this.CheckCredentialTimeStamp();
            FilesResource.ListRequest listRequest = _service.Files.List();
            listRequest.Q = queryString;
            do
            {
                try
                {
                    FileList fileList = listRequest.Execute();
                    returnList.AddRange(fileList.Items);
                    listRequest.PageToken = fileList.NextPageToken;
                }
                catch (Exception exception)
                {
                    listRequest.PageToken = null;
                    throw exception;
                }
            } while (!String.IsNullOrEmpty(listRequest.PageToken));
            return returnList;
        }

        /// <summary>
        /// 刪除符合FileID的檔案
        /// </summary>
        /// <param name="fileId">欲刪除檔案的FileID</param>
        public void DeleteFile(string fileId)
        {
            CheckCredentialTimeStamp();
            try
            {
                _service.Files.Delete(fileId).Execute();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // CreateFile
        private void CreateFile(string fileName, string content, string contentType)
        {
            CheckCredentialTimeStamp();
            try
            {
                MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(content));
                Google.Apis.Drive.v2.Data.File fileToInsert = new Google.Apis.Drive.v2.Data.File 
                { 
                    Title = fileName };
                FilesResource.InsertMediaUpload insertRequest = _service.Files.Insert(fileToInsert, stream, contentType);
                insertRequest.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize << 1;
                insertRequest.Upload();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // UploadFile
        public void UploadFile(string fileName, string content, string contentType)
        {
            var fileList = this.ListRootFileAndFolder();
            var foundFiles = fileList.FindAll(item =>
            {
                return item.Title == fileName;
            });
            if (foundFiles.Count > 0)
            {
                foreach (var file in foundFiles)
                    DeleteFile(file.Id);
            }
            CreateFile(fileName, content, contentType);
        }

        // DownloadFile
        public string ReadFile(string fileName)
        {
            const string EXCEPTION_MESSAGE = "file not found";
            var foundFiles = this.ListRootFileAndFolder().FindAll(item => 
            { 
                return item.Title == fileName; 
            });
            if (foundFiles.Count != 1)
                throw new Exception(EXCEPTION_MESSAGE);
            var fileToDownload = foundFiles[0];
            try
            {
                Task<byte[]> downloadByte = _service.HttpClient.GetByteArrayAsync(fileToDownload.DownloadUrl);
                return Encoding.Default.GetString(downloadByte.Result);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // IsContain
        public bool IsContain(string fileName)
        {
            var foundFile = this.ListRootFileAndFolder().Find(item =>
            {
                return item.Title == fileName;
            });
            return foundFile != null;
        }
    }
}
