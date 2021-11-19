using NUnit.Framework;
using System;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
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
        [Category("Smoke")]
        [Test]
        public void Test2()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }

    }
}