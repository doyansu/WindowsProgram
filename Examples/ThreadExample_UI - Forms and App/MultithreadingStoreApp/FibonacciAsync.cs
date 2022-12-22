using Multithreading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.System.Threading;
using Windows.UI.Core;

namespace MultithreadingStoreApp
{
    class FibonacciAsync
    {
        public delegate void ProgressHandler(int percent);
        public delegate void ResultHandler(decimal result);
        public event ProgressHandler Progress = null;
        public event ResultHandler Result = null;
        MainPage mainPage; int n;
        IAsyncAction _asyncAction;
        public FibonacciAsync(MainPage mainPage)
        {
            this.mainPage = mainPage;
        }
        public void AsyncCompute(int n)
        {
            this.n = n;
            Fibonacci f = new Fibonacci();
            f.Progress += progressHandler;
            decimal result=0;
            // 執行非同步的運算
            _asyncAction = ThreadPool.RunAsync(delegate {
                result = f.compute(n);
            });
            // 這是一個Callback function，當上面的運算做完的時候會被呼叫
            _asyncAction.Completed = delegate(IAsyncAction asyncAction, AsyncStatus asyncStatus)
            {
                mainPage.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
                {
                    Result.Invoke(result);
                });
            };
        }

        void progressHandler(int percent)
        {
            if (Progress != null) // if there's a Progrss handler
            {
                mainPage.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
                {
                    Progress.Invoke(percent);
                });
            }
            //Progress.Invoke(percent); // invoke is thread safe
            // Note: the following code does not work
            // Progress(percent); // This is NOT thread safe
        }

        public void Stop()
        {
            if (_asyncAction != null)
                _asyncAction.Cancel();
        }
    }
}
