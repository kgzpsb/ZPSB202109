using NUnit.Framework;
using System;
using NUnit.Samples.Cash;

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

        [Category("Sanity")]
        [Test]
        public void Test1()
        {
            var x = 253;
            var y = 253;
            Assert.AreEqual(x, y);
        }

        [Category("Smoke")]
        [Test]
        public void Test2()
        {
            var x = 5 * 5;
            var y = 26;
            Assert.AreNotEqual(x, y);
        }
    }
}