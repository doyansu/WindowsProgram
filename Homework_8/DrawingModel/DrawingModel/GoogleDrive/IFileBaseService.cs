using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.GoogleDrive
{
    public interface IFileBaseService
    {
        // 上傳檔案
        void UploadFile(string fileName, string content, string contentType);
        // 下載檔案
        string ReadFile(string fileName);

        // 包含檔案
        bool IsContain(string fileName);
    }
}
