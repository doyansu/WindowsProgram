using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TaskExample
{
    class JPGCounter
    {
        // 遞迴計算jpg檔案數量
        public int count(DirectoryInfo dirInfo)
        {
            try
            {
                int counter = dirInfo.GetFiles("*.jpg").Length;
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                    counter += count(subDir);
                return counter;
            }
            catch (Exception)
            {
                return 0;  // 無法access的目錄會出現exception，視為0
            }
        }

        public int countParallel(DirectoryInfo dirInfo)
        {
            try
            {
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();
                // 先啟動Task，每一個子目錄用一個Task
                List<Task<int>> tasks = new List<Task<int>>();
                foreach (DirectoryInfo subDir in subDirs)
                    tasks.Add(Task.Factory.StartNew(() => countParallel(subDir)));
                // 計算此目錄之JPG檔案數
                int counter = dirInfo.GetFiles("*.jpg").Length;
                // 等到所有的Task都完成
                Task.WaitAll(tasks.ToArray());
                // 累計JPG檔案數
                foreach (Task<int> task in tasks)
                    counter += task.Result;
                return counter;
            }
            catch (Exception)
            {
                return 0;  // 無法access的目錄會出現exception，視為0
            }
        }

        // 以下變數只有countParallelWithProgress用到
        double currentPercent;
        double previousPercent;
        object lockObject = new object();

        public int countParallelWithProgress(DirectoryInfo dirInfo, double percent, IProgress<int> progress)
        {
            currentPercent = 0;
            previousPercent = 0;
            return recursiveCountParallelWithProgress(dirInfo, percent, progress);
        }

        private int recursiveCountParallelWithProgress(DirectoryInfo dirInfo, double percent, IProgress<int> progress)
        {
            try
            {
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();
                // 如果是leaf的話，回報目前進度
                if (subDirs.Length == 0)
                    reportProgress(percent, progress);
                // 先啟動Task，每一個子目錄用一個Task
                List<Task<int>> tasks = new List<Task<int>>();
                foreach (DirectoryInfo subDir in subDirs)
                    tasks.Add(Task.Factory.StartNew(() => recursiveCountParallelWithProgress(subDir, percent / subDirs.Length, progress)));
                // 計算此目錄之JPG檔案數
                int counter = dirInfo.GetFiles("*.jpg").Length;
                // 等到所有的Task都完成
                Task.WaitAll(tasks.ToArray());
                // 累積計算JPG檔案數
                foreach (Task<int> task in tasks)
                    counter += task.Result;
                return counter;
            }
            catch (Exception)
            {
                reportProgress(percent, progress);
                return 0;
            }
        }

        private void reportProgress(double percent, IProgress<int> progress)
        {
            // Task同時共用currentPercent與previousPercent，因此必須Lock
            lock (lockObject) 
            { 
                currentPercent += percent;
                // 最少差1%才通知1次(避免通知太頻繁)
                if (currentPercent - previousPercent > 1)
                {
                    previousPercent = currentPercent;
                    progress.Report((int)currentPercent);
                }
            }
        }
    }
}
