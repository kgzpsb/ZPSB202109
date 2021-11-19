using NUnit.Framework;
using System;
using NUnit.Samples.Cash;

namespace TestProject1
{
    public class Tests
    {
        private Cash f14CHF;
        private CashBag f1to3PLN;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("This is Setup");
            f14CHF = new Cash(14, "CHF");
            f1to3PLN = new CashBag(
                new Cash[3] {
                    new Cash(1, "PLN"),
                    new Cash(2, "PLN"),
                    new Cash(3, "PLN")
                    }
                );
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("This is Teardown");
        }

        [Category("Smoke")]
        [Test]
        public void SimpleMultiplyCash()
        {
            Cash expected = new Cash(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }

        [Category("Smoke")]
        [Test]
        public void SimpleMultiplyCashBag()
        {
            CashBag expected = new CashBag(
                        new Cash[3] {
                        new Cash(2, "PLN"),
                        new Cash(4, "PLN"),
                        new Cash(6, "PLN")
                        }
                    );

            Assert.AreEqual(expected, f1to3PLN.Multiply(2));
        }

        [Category("Smoke")]
        [Test]
        public void SimpleAddCash()
        {
            Cash addedValue = new(6, "CHF");
            Cash expected = new(20, "CHF");
            Assert.AreEqual(expected, f14CHF.Add(addedValue));
        }

        [Category("Smoke")]
        [Test]
        public void MixedAddCash()
        {
            Cash addedValue1 = new(6, "PLN");
            Cash addedValue2 = new(20, "CHF");

            CashBag mockCashBag = new CashBag(
                    new Cash[2] {
                        new Cash(20, "CHF"),
                        new Cash(6, "PLN")
                    }
                   );
            Assert.AreEqual(mockCashBag, addedValue1.Add(addedValue2));
        }

        [Category("Smoke")]
        [Test]
        public void SimpleSubtractCash()
        {
            Cash subtractedValue = new(4, "CHF");
            Cash expected = new(10, "CHF");
            Assert.AreEqual(expected, f14CHF.Subtract(subtractedValue));
        }
        

        //to nie potrzebne
        [Category("Smoke")]
        [Test]
        public void SimpleNegateCash()
        {
            Cash expected = new(-14, "CHF");
            Assert.AreEqual(f14CHF.Negate(), expected);
        }

        [Category("Smoke")]
        [Test]
        public void SimpleChangeCurrency()
        {
            Cash currency1 = new(1, "USD");
            Cash currency2 = new(1, "EUR");

            currency2.SetCurrency("USD");

            Assert.AreEqual(currency1, currency2);
        }

        [Category("Sanity")]
        [Test]
        public void FalseEquityCheck()
        {
            Cash coin = new(1, "EUR");
            CashBag notACoin = null;
            Assert.IsFalse(coin.Equals(notACoin));
        }

        [Category("Sanity")]
        [Test]
        public void ZeroEquityCheck()
        {
            Cash zeroCash = new(0, "EUR");
            Assert.IsTrue(zeroCash.Equals(new Cash(0, "EUR")));
        }

        [Category("Sanity")]
        [Test]
        public void CorrectStrRep()
        {
            string expected = "[14 CHF]";
            Assert.AreEqual(f14CHF.ToString(), expected);
        }

        [Category("Sanity")]
        [Test]
        public void HashNotNull()
        {
            Assert.IsNotNull(f14CHF.GetHashCode());
        }

        [Category("Sanity")]
        [Test]
        public void AddCashBagToCash()
        {
            CashBag expected = new CashBag(
                    new Cash[4] {
                        new Cash(1, "PLN"),
                        new Cash(2, "PLN"),
                        new Cash(3, "PLN"),
                        new Cash(14, "CHF")
                    }
                );

            ICash combined = f14CHF.AddMoneyBag(f1to3PLN);

            Assert.AreEqual(expected, (CashBag)combined);
        }



    }
}