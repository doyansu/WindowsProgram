using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        const string ERROR_MSG = "Sorry, you don't have so much money!!";
        private List<double> _records;
        public Account(uint initAmount)
        {
            _records = new List<double>();
            Deposit(initAmount);
        }
        // Note: we make Balance private to demonstrate the testing of private members.
        private double Balance
        {
            get
            {
                double balance = 0;
                foreach (double record in _records)
                {
                    balance += record;
                }
                return balance;
            }
        }
        public void Deposit(uint amount)
        {
            _records.Add(Decimal.ToDouble(amount));
        }
        public void Withdraw(uint amount)
        {
            if (amount > Balance)
                Console.WriteLine(ERROR_MSG);
            else
                _records.Add(Decimal.ToDouble(-amount));
        }
    }
}
