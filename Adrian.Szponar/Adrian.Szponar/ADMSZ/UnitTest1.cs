using NUnit.Framework;
using System;

namespace ADMSZ
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

        [Test]
        public void test1()
        {
            var x = 1;
            var y = 2;
            Assert.AreEqual(x, y);
        }

    }
}