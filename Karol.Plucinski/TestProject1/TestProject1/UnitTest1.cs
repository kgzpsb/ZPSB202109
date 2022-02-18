using NUnit.Framework;
using System;
using NUnit.Samples.Cash;
using Moq;

namespace TestProject1
{
    public class Tests
    {
        private Cash f14CHF;
        [SetUp]
        public void Setup()
        {
            f14CHF = new Cash(14, "CHF");
            Console.WriteLine("This is SetUp");
        }
        [Category("Smoke")]
        [Test]
        
        public void Test1()
        {
            
            var x = 1;
            var y = 1;
            Assert.AreEqual(x, y);
        }
        [Category("Sanity")]
        [Test]
        
        public void Test2()
        {
            
            
            var x = 2;
            var y = 3;
            Assert.AreNotEqual(x, y);
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }

        /// <summary>
        /// Assert that multiplying currency in Cash happens correctly
        /// </summary>
        ///
        [Test]
        public void SimpleMultiply()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new Cash(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }

        [Test]
        public void SimpleNegate()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new Cash(-14, "CHF");
            Assert.AreEqual(expected, f14CHF.Negate());
        }

        [Test]
        public void MoneyBag()
        {
            Cash start = new Cash(5, "CHF");
            Cash add = new Cash(5, "USD");
            CashBag test = new CashBag(start, add);

            Assert.AreEqual(start.AddMoneyBag(test), test.Multiply(2).Subtract(add));
        }

        /// <summary>
        /// Test set Currency , Data-Driven Testing
        /// </summary>
        [TestCase( "14")]
        [TestCase("1")]
        [TestCase( "2")]
        public void SetCurrency(int value)
        {
           
            
            Cash cashCHF = new Cash(value, "CHF");
            Cash cashPLN = new Cash(value, "PLN");
            cashPLN.SetCurrency("CHF");
            Assert.AreEqual(cashPLN.Currency, cashCHF.Currency);
        }
        [Test]
        [Category("Unit")]
        public void TestMock()
        {
            //assert
            var Cash = new Cash(2, "PLN");
            var mockBag = new Mock<ICash>();
            mockBag.Setup(x => x.AddMoney(It.IsAny<Cash>())).Returns(new
            Cash(1, "CHF"));

            //act
            Cash.AddMoneyBag(mockBag.Object);
            //assert

            
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Once);
        }


    }
}