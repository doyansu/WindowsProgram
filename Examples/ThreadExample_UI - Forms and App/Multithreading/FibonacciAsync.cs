using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class FibonacciAsync
    {
        public delegate void ProgressHandler(int percent);
        public delegate void ResultHandler(decimal result);
        public event ProgressHandler Progress = null;
        public event ResultHandler Result = null;
        Thread worker = null;
        Form1 form; int n;
        public FibonacciAsync(Form1 form)
        {
            this.form = form;
        }
        public void AsyncCompute(int n)
        {
            this.n = n;
            worker = new Thread(AsyncComputeThread);
            worker.Start();
        }
        private void AsyncComputeThread()
        {
            Fibonacci f = new Fibonacci();
            f.Progress += progressHandler;
            if (Result != null) // if there's a Result handler
                form.Invoke(Result, f.compute(n)); // invoke is thread safe
            // Note: the following code does not work
            // Result(f.compute(n)); // This is NOT thread safe
            worker = null;
        }
        void progressHandler(int percent)
        {
            if (Progress != null) // if there's a Progrss handler
                form.Invoke(Progress, percent); // invoke is thread safe
            // Note: the following code does not work
            // Progress(percent); // This is NOT thread safe
        }
        public void Stop()
        {
            if (worker != null)
                worker.Abort();
        } 
    }
}
