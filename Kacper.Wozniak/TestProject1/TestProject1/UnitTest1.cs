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
        public void SimpleAddMoney()
        {
            Cash expected = new Cash(28, "CHF");
            Cash add = new Cash(14, "CHF");
            Assert.AreEqual(expected, f14CHF.AddMoney(add));
        }

        [Test]
        [Category("Sanity")]
        public void Test1()
        {
            var x = 253;
            var y = 253;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Smoke")]
        public void Test2()
        {
            var x = 5 * 5;
            var y = 26;
            Assert.AreNotEqual(x, y);
        }

        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]

        public void SetCurrency_SwitchCurrencyAndValue_CashObjectsAreEqual(int value)
        {
            Cash cashCHF = new Cash(value, "CHF");
            Cash cashPLN = new Cash(value, "PLN");
            cashPLN.SetCurrency("CHF");
            Assert.AreEqual(cashCHF.Currency, cashPLN.Currency);
        }

        [Test]
        [Category("Unit")]
        public void TestMock()
        {
            //arrange
            var Cash = new Cash(2, "PLN");
            var mockBag = new Mock<ICash>();
            mockBag.Setup(x => x.AddMoney(It.IsAny<Cash>())).Returns(new Cash(1,"CHF"));
            
            //act
            Cash.AddMoneyBag(mockBag.Object);
 
            //assert
             Assert.IsTrue(true);
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Once());
 }
    }
}