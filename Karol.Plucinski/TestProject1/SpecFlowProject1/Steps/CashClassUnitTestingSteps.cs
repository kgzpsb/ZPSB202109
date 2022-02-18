using System;
using TechTalk.SpecFlow;
using NUnit.Samples.Cash;
using NUnit.Framework;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class CashClassUnitTestingSteps
    {
        Cash oldCash;
        Cash newCash;


        [Given(@"Cash CHF (.*)")]
        public void GivenCashCHF(int value)
        {
            oldCash = new Cash(value, "XXX");
        }
        
        [When(@"Multipy by (.*)")]
        public void WhenMultipyBy(int multiply)
        {
            newCash = (Cash)oldCash.Multiply(multiply);
        }
        
        [Then(@"Cash Value is (.*)")]
        public void ThenCashValueIs(int newValue)
        {
            Assert.AreEqual(newValue, newCash.Amount);
        }
    }
}
