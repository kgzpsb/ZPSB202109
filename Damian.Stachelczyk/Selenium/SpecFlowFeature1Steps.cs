using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumTests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverWait;
        private LoginEmailPage loginPage;

        public SpecFlowFeature1Steps(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver = driver;
            webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            loginPage = new LoginEmailPage(webdriver);
        }

        [Given(@"I enter wp\.pl")]
        public void GivenIEnterWp_Pl()
        {
            webdriver.Navigate().GoToUrl("http://www.wp.pl/");

            var cookiesPopupXPath = "/html/body//div/button[text()=\"AKCEPTUJĘ I PRZECHODZĘ DO SERWISU\"]";
            var element =
                webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(cookiesPopupXPath)));
            
            element.Click();
        }
        
        [Given(@"I click on (.*)")]
        public void GivenIClickOn(string p0)
        {
            var pocztaXPath = "//div[2]/div[3]/a[1]";
            var element = webdriver.FindElement(By.Id("site-header")).FindElement(By.XPath(pocztaXPath));
            element.Click();
        }
        
        [When(@"I fill wrong email login")]
        public void WhenIFillWrongEmailLogin()
        {
            loginPage.login.SendKeys("Test");
        }
        
        [When(@"I fill wrong password")]
        public void WhenIFillWrongPassword()
        {
            loginPage.pass.SendKeys("pomidor");
        }

        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            var loginXPath = "//button[text()=\"Zaloguj się\"]"; ;
            var loginButton = webdriver.FindElement(By.XPath(loginXPath));
            webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(loginButton));
            loginButton.Click();
        }
        
        [Then(@"I expect to see message as „Niestety podany login lub hasło jest błędne\.”")]
        public void ThenIExpectToSeeMessageAsNiestetyPodanyLoginLubHasloJestBledne_()
        {
            var errorMsgXPath = "//form/div[3]/span";
            webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(errorMsgXPath)));

            var errorMessage = webdriver.FindElement(By.XPath(errorMsgXPath)).GetAttribute("innerHTML");
            Assert.IsTrue(errorMessage.Equals("Podany login i/lub hasło są nieprawidłowe."));
        }
    }
}
