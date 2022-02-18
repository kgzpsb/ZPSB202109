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

        [Test]
        [Category("Smoke")]
        public void Test1()
        {
            
            var x = 1;
            var y = 1;
            Assert.AreEqual(x, y);
        }

        [Test]
        [Category("Sanity")]
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
    }
}