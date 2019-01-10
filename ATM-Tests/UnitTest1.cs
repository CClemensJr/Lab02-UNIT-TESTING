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
        public void DepositsShouldAddToBalance()
        {
            decimal balance = 0.00m;
            decimal deposit = 5.00m;
            decimal newBalance = balance + deposit;

            Assert.Equal(newBalance, Program.DepositCash(balance, deposit));
        }
    }
}
