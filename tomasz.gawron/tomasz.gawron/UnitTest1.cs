using NUnit.Framework;
using System;

namespace tomasz.gawron
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("This is setup");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1");
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("Test2");
        }

        [Test] 
        public void test3() 
        {
            var x = 1; 
            var y = 2; 
            Assert.AreEqual(x, y); 
        }
    }
}