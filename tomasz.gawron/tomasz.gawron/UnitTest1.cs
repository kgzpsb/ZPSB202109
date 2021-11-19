using NUnit.Framework;
using System;
using NUnit.Samples.Cash;
using Moq;

namespace tomasz.gawron
{
    public class Tests
    {
        private Cash f14CHF;
        [SetUp]
        public void Setup()
        {
            f14CHF = new Cash(14, "CHF");
            Console.WriteLine("This is setup");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }
        [Category("unit")]
        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1");
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("Test2");
        }

        [Test] 
        public void test3() 
        {
            var x = 1; 
            var y = 2; 
            Assert.AreNotEqual(x, y); 
        }

        [Test]
        public void test_4()
        {
            bool x = true;
            Assert.IsTrue(x);
        }
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
            Cash expected = new Cash(-14, "CHF");
            Assert.AreEqual(expected, f14CHF.Negate());
        }
        [Test]
        public void SimpleSubstract()
        {
            Cash expected = new Cash(0, "CHF");
            Cash sub = new Cash(14, "CHF");

            Assert.AreEqual(expected, f14CHF.Subtract(sub));
        }

        [Test]
        public void SimpleAddMoney()
        {
            Cash expected = new Cash(28, "CHF");
            Cash add = new Cash(14, "CHF");

            Assert.AreEqual(expected, f14CHF.AddMoney(add));
        }

        [Test]
        public void SimpleAddMoneyBag() {
            Cash expected = new Cash(28, "CHF");
            Cash add = new Cash(14, "CHF");
            CashBag bag_big = new CashBag(expected, expected);
            CashBag bag2 = new CashBag(add, add);


            Assert.AreEqual(bag_big, bag2.AddMoneyBag(bag2));

        }

        /// <summary> 
        /// Test set Currency , Data-Driven Testing 
        /// </summary> 
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetCurrency_ChangeCurrencyAndValue_CashObjAreTheSame(int value)
        {
            Cash currencyCHF = new Cash(value, "CHF");
            Cash currencyPLN = new Cash(value, "PLN");
            currencyCHF.SetCurrency("CHF");
            Assert.AreEqual(currencyPLN.Currency, currencyPLN.Currency);
        }




        [Test]
        [Category("Unit")]
        public void TestMock()
        {
            //assert 
            var Cash = new Cash(2, "PLN");
            var mockBag = new Mock<ICash>();
            mockBag.Setup(x => x.AddMoney(It.IsAny<Cash>())).Returns(new Cash(1, "CHF"));

            //act 
            Cash.AddMoneyBag(mockBag.Object);


            //assert 
            Assert.IsTrue(true);
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Never());
        }
    }
}