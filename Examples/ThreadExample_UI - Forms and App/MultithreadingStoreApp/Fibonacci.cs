using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class Fibonacci
    {
        public delegate void ProgressHandler(int percent);
        public event ProgressHandler Progress = null;
        double acc_percent;
        double prev_percent;
        public decimal compute(int n)
        {
            acc_percent = prev_percent = 0;
            // Here, we don’t use iterative (for loop) method, why?
            return recursive_compute(n, 100);
        }
        private decimal recursive_compute(int n, double percent)
        {
            if (n <= 1)
            {
                acc_percent += percent;
                if (Progress != null && (acc_percent - prev_percent) > 1)
                {
                    prev_percent = acc_percent;
                    Progress((int)acc_percent);
                }
                return n;
            }
            return recursive_compute(n - 2, percent / 2) +
            recursive_compute(n - 1, percent / 2);
        }
    }
}
