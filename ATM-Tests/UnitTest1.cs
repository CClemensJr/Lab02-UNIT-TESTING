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
            decimal balance = 0m;
            decimal withdrawal = -5.00m;

            Assert.Equal(0, Program.WithdrawCash(balance, withdrawal));
        }
    }
}
