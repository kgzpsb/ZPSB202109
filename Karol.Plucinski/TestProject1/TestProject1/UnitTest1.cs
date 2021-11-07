using NUnit.Framework;
using System;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
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
    }
}