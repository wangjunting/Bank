using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System.Diagnostics.CodeAnalysis;

namespace BankTestT
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BankAccountTestsT
    {

        // unit test code 
        [TestMethod]
        public void Credit_WithValidAmount()
        {
            // arrange
            double beginningBalance = 10.00;
            double Amount = 4.55;
            double expected = 14.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // act
            account.Credit(Amount);
            // assert 
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
       
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double Amount = -10.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // act
            try
            {
                account.Credit(Amount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
