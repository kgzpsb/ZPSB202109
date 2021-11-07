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
            Console.WriteLine("This is Setup");
            f14CHF = new (14, "CHF");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("This is Teardown");
        }

        [Category("Sanity")]
        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1");
            string x = null;
            Assert.IsNull(x);
        }

        [Category("Smoke")]
        [Test]
        public void Test2()
        {
            var x = 1;
            var y = 1;
            Assert.AreEqual(x, y);
        }

        /// <summary>
        /// Assert that multiplying currency in Cash happens correctly
        /// </summary>
        ///
        [Test]
        public void SimpleMultiply()
        {
            // [14 CHF] *2 == [28 CHF]
            Cash expected = new (28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }


    }
}