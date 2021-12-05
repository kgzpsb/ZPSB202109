using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.Pages;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Features
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverWait;
        private LoginEmailPage loginPage;
        public SpecFlowFeature2Steps(IWebDriver driver)
        {
            
            webdriver = driver;
            webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginPage = new LoginEmailPage(webdriver);//Dodane

        }
        [Given(@"I enter wp\.pl")]
        public void GivenIEnterWp_Pl()
        {
            webdriver.Navigate().GoToUrl("http://www.wp.pl");
            //wait for load
            Thread.Sleep(1000);
            var popup = "/html/body/div[2]/div/div[2]/div[3]/div";
            var element = 
           webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(popup)));
            // bad practice
            Thread.Sleep(1000);
            element.Click();
        }
        [Given(@"I click on (.*)")]
        public void GivenIClickOn(string p0)
        {
            // bad practice   /html/body/div[3]/div[5]/div[2]/div[4]/a[1] (Good //a//span[text()='Poczta']  )
            Thread.Sleep(3000);
            //Tutaj zmieniłem Poczta 
            var firstXPath = "//a//span[text()='Pocza']";
            var elementPoczta = webdriver.FindElement(By.XPath(firstXPath));
            elementPoczta.Click();
        }
        [When(@"I fill wrong email login")]
        public void WhenIFillWrongEmailLogin()
        {
            //var login = webdriver.FindElement(By.Id("login"));
            //login.SendKeys("Test");
            loginPage.login.SendKeys("Test");
        }
        [When(@"I fill wrong password")]
        public void WhenIFillWrongPassword()
        {
            //var pass = webdriver.FindElement(By.Name("password"));
            //pass.SendKeys("pomidor");
            loginPage.pass.SendKeys("pomidor");
            Thread.Sleep(2000);
        }
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {

            ///html/body/div[4]/div/div[2]/div/div/div[1]/form/button  
            var submitBtnCssSelector = "html/body/div[4]/div/div[2]/div/div/div[1]/form/button";
            var submitBtn = webdriver.FindElement(By.XPath(submitBtnCssSelector));
            
            submitBtn.Click();
            Thread.Sleep(2000);
        }
        [Then(@"I expect to see message as „Niestety podany login lub hasło jest błędne\.”")]
        public void ThenIExpectToSeeMessageAsNiestetyPodanyLoginLubHasloJestBledne_()
        {
            ///html/body/div[4]/div/div[2]/div/div/div[1]/form/div[3]/span
            ///
            Thread.Sleep(3000);
            var FailXPath = "html/body/div[4]/div/div[2]/div/div/div[1]/form/div[3]/span";
            var elementFail = webdriver.FindElement(By.XPath(FailXPath));
         
            elementFail.Click();
        }

    }
}


