using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithreading
{
    public partial class Form1 : Form
    {
        Fibonacci fib_sync;
        FibonacciAsync fib_async; 

        public Form1()
        {
            InitializeComponent();
            fib_sync = new Fibonacci();
            fib_sync.Progress+=ProgressHandler;

            fib_async = new FibonacciAsync(this);
            fib_async.Progress += ProgressHandler;
            fib_async.Result += EndCompute; 
        }

        private void ClickComputeButton(object sender, EventArgs e)
        {
            BeginCompute();
            EndCompute(fib_sync.compute(n));
        }

        private void ClickAsyncComputeButton(object sender, EventArgs e)
        {
            BeginCompute();
            fib_async.AsyncCompute(n); 
        }

        private void BeginCompute()
        {
            Cursor = Cursors.WaitCursor;
            numericUpDown1.Enabled = false;
            ComputeButton.Enabled = false;
            AsyncComputeButton.Enabled = false;
            label1.Text = "Computing...";
            Update();
        }

        private void EndCompute(decimal result)
        {
            label1.Text = "Fibonacci(" + n + ") = " + result.ToString();
            progressBar1.Value = 0;
            numericUpDown1.Enabled = true;
            ComputeButton.Enabled = true;
            AsyncComputeButton.Enabled = true;
            Cursor = Cursors.Default;
        }

        private int n
        {
            get { return (int)numericUpDown1.Value; }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            fib_async.Stop();
            base.OnClosing(e);
        }

        private void ProgressHandler(int percent)
        {
            progressBar1.Value = percent;
        }
    }
}
