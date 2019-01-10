using System;
using Xunit;
using ATM;

namespace ATM_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BalanceShouldNotBeLessThanZero()
        {
            decimal balance = 0.00m;
            decimal withdrawal = 5.00m;

            Assert.Equal(0.00m, Program.WithdrawCash(balance, withdrawal));
        }

        [Fact]
        public void WithdrawalsShouldSubtractFromBalance()
        {
            decimal balance = 10.00m;
            decimal withdrawal = 5.00m;
            decimal newBalance = balance - withdrawal;

            Assert.Equal(newBalance, Program.WithdrawCash(balance, withdrawal));
        }

        [Fact]
        public void WithdrawalsShouldNotAddToBalance()
        {
            decimal balance = 10.00m;
            decimal withdrawal = 5.00m;
            decimal newBalance = balance + withdrawal;

            Assert.NotEqual(newBalance, Program.WithdrawCash(balance, withdrawal));
        }

        [Fact]
        public void DepositsShouldAddToBalance()
        {
            decimal balance = 0.00m;
            decimal deposit = 5.00m;
            decimal newBalance = balance + deposit;

            Assert.Equal(newBalance, Program.DepositCash(balance, deposit));
        }

        [Fact]
        public void DepositsShouldNotSubtractFromBalance()
        {
            decimal balance = 0.00m;
            decimal deposit = 5.00m;
            decimal newBalance = balance - deposit;

            Assert.NotEqual(newBalance, Program.DepositCash(balance, deposit));
        }
    }
}
