using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace TaskExample
{
    public partial class TaskExampleForm : Form
    {
        JPGCounter counter = new JPGCounter();
        Stopwatch stopWatch;
        DirectoryInfo dirInfo;

        public TaskExampleForm()
        {
            InitializeComponent();
            countButton.Font = SystemFonts.MenuFont;
            asyncCountButton.Font = SystemFonts.MenuFont;
            parallelCountButton.Font = SystemFonts.MenuFont;
            parallelProgressCountButton.Font = SystemFonts.MenuFont;
            demoButton.Font = SystemFonts.MenuFont;
            fileCountLabel.Font = SystemFonts.MenuFont;
            chooseDirectoryButton.Font = SystemFonts.MenuFont;
            directoryPathLabel.Font = SystemFonts.MenuFont;
            executionTimeLabel.Font = SystemFonts.MenuFont;
            dirInfo = new DirectoryInfo(directoryPathLabel.Text);
        }

        private void countButtonClicked(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            stopWatch = Stopwatch.StartNew();
            // 下一行程式必須等到counter.count()完成，才能繼續執行UI Thread
            int count = counter.count(dirInfo);
            stopWatch.Stop();
            fileCountLabel.Text = "There are " + count + " JPG files in " + directoryPathLabel.Text;
            executionTimeLabel.Text = "Execution time: " + stopWatch.Elapsed;
            Cursor = Cursors.Arrow;
        }

        async private void asyncCountButtonClicked(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            stopWatch = Stopwatch.StartNew();
            // 下一行程式使用 await，因此counter.count()完成前，就會繼續執行UI Thread
            int count = await Task.Factory.StartNew(() => counter.count(dirInfo));
            stopWatch.Stop();
            fileCountLabel.Text = "There are " + count + " JPG files in " + directoryPathLabel.Text;
            executionTimeLabel.Text = "Execution time: " + stopWatch.Elapsed;
            Cursor = Cursors.Arrow;
        }

        async private void parallelCountButtonClicked(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            stopWatch = Stopwatch.StartNew();
            // 下一行程式使用 await，因此counter.count()完成前，就會繼續執行UI Thread
            int count = await Task.Factory.StartNew(() => counter.countParallel(dirInfo));
            stopWatch.Stop();
            fileCountLabel.Text = "There are " + count + " JPG files in " + directoryPathLabel.Text;
            executionTimeLabel.Text = "Execution time: " + stopWatch.Elapsed;
            Cursor = Cursors.Arrow;
        }

        async private void parallelProgressCountButtonClicked(object sender, EventArgs e)
        {
            // 設定progressBar
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            // IProgress是回報progress的標準機制
            IProgress<int> progress = new Progress<int>((value) => { progressBar.Value = value; });
            // 開始計算
            Cursor = Cursors.WaitCursor;
            stopWatch = Stopwatch.StartNew();
            // 下一行程式使用 await，因此counter.count()完成前，就會繼續執行UI Thread
            int count = await Task.Factory.StartNew(() => counter.countParallelWithProgress(dirInfo, 100, progress));
            stopWatch.Stop();
            fileCountLabel.Text = "There are " + count + " JPG files in " + directoryPathLabel.Text;
            executionTimeLabel.Text = "Execution time: " + stopWatch.Elapsed;
            Cursor = Cursors.Arrow;
            progressBar.Value = 0;
        }

        private void exitToolStripMenuItemClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void chooseDirectoryButtonClicked(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                directoryPathLabel.Text = dialog.SelectedPath;
                dirInfo = new DirectoryInfo(directoryPathLabel.Text);
            }
        }
    }
}
