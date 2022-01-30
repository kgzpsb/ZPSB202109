using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Features
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I enter wp\.pl")]
        public void GivenIEnterWp_Pl()
        {
            webdriver.Navigate().GoToUrl("http://www.wp.pl");
            //    ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click on (.*)")]
        public void GivenIClickOn(string p0)
        {
      //      ScenarioContext.Current.Pending();
        }
        
        [When(@"I fill wrong email login")]
        public void WhenIFillWrongEmailLogin()
        {
        //    ScenarioContext.Current.Pending();
        }
        
        [When(@"I fill wrong password")]
        public void WhenIFillWrongPassword()
        {
       //     ScenarioContext.Current.Pending();
        }
        
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
       //     ScenarioContext.Current.Pending();
        }
        
        [Then(@"I expect to see message as „Niestety podany login lub hasło jest błędne\.”")]
        public void ThenIExpectToSeeMessageAsNiestetyPodanyLoginLubHasloJestBledne_()
        {
       //     ScenarioContext.Current.Pending();
        }

        private IWebDriver webdriver;
        public SpecFlowFeature1Steps(IWebDriver driver)
        {
            webdriver = driver;
        }





    }

   
}
