using NUnit.Framework;
using NUnit.Samples.Cash;
using System;
using Moq;


namespace ADMSZ
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("This is SetUp");
        }
        [Category("Smoke")]
        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("This is Teardown");
        }
        [Category("Sanity")]
        [Test]
        public void test1()
        {
            var x = 2;
            var y = 2;
            Assert.AreEqual(x, y);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ChangeCurrency(int value)
        {
           
            Cash c2CHF = new Cash(value, "CHF");
            Cash c2PLN = new Cash(value, "PLN");
            c2PLN.SetCurrency("CHF");
            Assert.AreEqual(c2CHF.Currency, c2CHF.Currency);
        }

        
        [Test]
        [Category("Unit")]
        public void TestMock()
        {
            //assert
            var Cash = new Cash(2, "PLN");
            var mockBag = new Mock<ICash>();
            mockBag.Setup(x => x.AddMoney(It.IsAny<Cash>())).Returns(new
           Cash(1, "CHF"));

            //act
            Cash.AddMoneyBag(mockBag.Object);


            //assert
        
            mockBag.Verify(mock => mock.AddMoney(It.IsAny<Cash>()), Times.Once());
        }

       
    }
}