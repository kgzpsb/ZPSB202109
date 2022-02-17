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
        public void SimpleTostring()
        {
            string expected = "[14 CHF]";
            Assert.AreEqual(expected, f14CHF.ToString());
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
           
            currencyPLN.SetCurrency("CHF");

            Assert.AreEqual(currencyPLN.Currency, currencyPLN.Currency);
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CashBagWithCashObjectEqualsTests(int currency)
        {
            Cash testCasch = new Cash(currency, "PLN");

            CashBag test = new CashBag(testCasch, new Cash(3, "CHF"));
            bool testEquals = testCasch.Equals(test);

            Assert.AreEqual(false, testEquals);
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
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Once());
        }
    }
}