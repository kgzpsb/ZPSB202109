using NUnit.Framework;
using System;
using NUnit.Samples.Cash;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("This is SetUp");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("This is TearDown");
        }


        [Test]

        [Category("Smoke")]
        public void Test1()
        {
            var x = 1;
            var y = 1;
            Assert.AreEqual(x, y);
        }
        
        [Test
            ]
        [Category("Sanity")]
        public void Test2()
        {
            var a = 2;
            var b = 2;
            Assert.AreSame(a, b);
        }
        
      
    }
}