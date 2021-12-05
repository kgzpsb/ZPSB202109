using NUnit.Framework;
using System;
using NUnit.Samples.Cash;

namespace TestProjectPS
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
        [Category("Smoke")]
        public void Test1()
        {
            var x = 2;
            var y = 2;
            Assert.AreEqual(x, y);
        }
        [Test]
        [Category("Sanity")]
        public void Test2()
        {
            var x = 5 * 5;
            var y = 26;
            Assert.AreNotEqual(x, y);
        }
    }
}