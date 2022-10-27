using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Tests
{
    [TestClass()]
    public class AccountTests
    {
        const uint INIT_AMOUNT = 100;
        const uint DEPOSITED = 200;
        const uint BIG_WITHDRAW = 300;
        PrivateObject _accountPrivate;
        Account _account;
        [TestInitialize()]
        public void Initialize()
        {
            _account = new Account(INIT_AMOUNT);
            _accountPrivate = new PrivateObject(_account);
        }
        [TestMethod()]
        public void DepositTest()
        {
            Assert.AreEqual((double)INIT_AMOUNT, _accountPrivate.GetFieldOrProperty("Balance"));
            _account.Deposit(DEPOSITED);
            Assert.AreEqual((double)(INIT_AMOUNT + DEPOSITED),
            _accountPrivate.GetFieldOrProperty("Balance"));
        }
        [TestMethod()]
        public void WithdrawTest()
        {
            Assert.AreEqual((double)INIT_AMOUNT,  _accountPrivate.GetFieldOrProperty("Balance")); 
            _account.Withdraw(BIG_WITHDRAW);
            Assert.AreEqual((double)INIT_AMOUNT, _accountPrivate.GetFieldOrProperty("Balance"));
            _account.Deposit(DEPOSITED);
            Assert.AreEqual((double)(INIT_AMOUNT + DEPOSITED), _accountPrivate.GetFieldOrProperty("Balance"));
            _account.Withdraw(BIG_WITHDRAW);
            double expected = (double)(INIT_AMOUNT + DEPOSITED) - BIG_WITHDRAW;
            Assert.AreEqual(expected, _accountPrivate.GetFieldOrProperty("Balance"));
        }
        [TestMethod()]
        public void BalanceTest()
        {
            Assert.AreEqual((double)INIT_AMOUNT,
            _accountPrivate.GetFieldOrProperty("Balance"));
        }
    }
}