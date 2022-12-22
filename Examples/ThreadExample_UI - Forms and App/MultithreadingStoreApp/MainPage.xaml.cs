using Multithreading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace MultithreadingStoreApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Fibonacci fib_sync;
        FibonacciAsync fib_async;

        public MainPage()
        {
            this.InitializeComponent();

            fib_sync = new Fibonacci();
            fib_sync.Progress += ProgressHandler;

            fib_async = new FibonacciAsync(this);
            fib_async.Progress += ProgressHandler;
            fib_async.Result += EndCompute;
        }

        private void ClickComputeButton(object sender, RoutedEventArgs e)
        {
            BeginCompute();
            EndCompute(fib_sync.compute(n));
        }

        private void ClickAsyncComputeButton(object sender, RoutedEventArgs e)
        {
            BeginCompute();
            fib_async.AsyncCompute(n);
        }

        private void BeginCompute()
        {

            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);

            _textBox.IsEnabled = false;
            _computeButton.IsEnabled = false;
            _asyncComputeButton.IsEnabled = false;
            _textBlock.Text = "Computing...";
            InvalidateArrange();
        }

        private int n
        {
            get
            {
                try
                {
                    return int.Parse(_textBox.Text);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public void EndCompute(decimal result)
        {
            _textBlock.Text = "Fibonacci(" + n + ") = " + result.ToString();
            _progressBar.Value = 0;
            _textBox.IsEnabled = true;
            _computeButton.IsEnabled = true;
            _asyncComputeButton.IsEnabled = true;
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        public void ProgressHandler(int percent)
        {
            _progressBar.Value = percent;
        }

        private void Unload(object sender, RoutedEventArgs e)
        {
            fib_async.Stop();
        }
    }
}
