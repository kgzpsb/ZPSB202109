using NUnit.Framework;
using NUnit.Samples.Cash;
using System;

namespace TestProject1
{
    public class Tests
    {

        private Cash f14CHF;

        [SetUp]
        public void SetUp()
        {
            f14CHF = new Cash(14, "CHF");
            Console.WriteLine("This is SetUp");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }

        [Category("Sanity")]
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        
        [Test]
        public void IsZeroWorkingWhenSettingZero()
        {
            Cash zeroCash = new Cash(0, "PLN"); // wywo³anie konstruktora 
            bool expected = true;
            Assert.AreEqual(expected, zeroCash.IsZero); // porównanie wartoœci oczekiwanej z faktyczn¹ 
        }

        [Test]
        public void IsZeroWorkingWhenSettingFifty()
        {
            Cash fiftyCash = new Cash(50, "PLN"); // wywo³anie konstruktora 
            bool expected = false;
            Assert.AreEqual(expected, fiftyCash.IsZero); // porównanie wartoœci oczekiwanej z faktyczn¹ 
        }

        [Test]
        public void Negate()
        {
            Cash originalCash = new Cash(50, "PLN"); // wywo³anie konstruktora 
            Cash expected = new Cash(-50, "PLN");
            Assert.AreEqual(expected, originalCash.Negate()); // porównanie wartoœci oczekiwanej z faktyczn¹ 
            
        }





        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetCurrency_ChangeCurrencyAndValue_CashObjectsAreTheSame(int value)
        {
            Cash cashCHF = new Cash(value, "CHF");
            Cash cashPLN = new Cash(value, "PLN");
            cashPLN.SetCurrency("CHF");
            Assert.AreEqual(cashCHF.Currency, cashPLN.Currency);
        }


        [Test]
        
        // test sprawdzaj¹cy czy klasa cash jest zdolna do pomno¿enia siebie przez 2; 
        // porównanie 2 obiektów
        public void SimpleMultiply()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new Cash(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }


    }
}