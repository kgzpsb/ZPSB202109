using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumTests
{
    [Binding]
    public class SpecFlowZpsbSteps
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverWait;

        public SpecFlowZpsbSteps(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver = driver;
            webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Given(@"I enter dziekanat\.zpsb\.pl and I click on students")]
        public void GivenIEnterDziekanat_Zpsb_PlAndIClickOnStudents()
        {
            webdriver.Navigate().GoToUrl("https://dziekanat.zpsb.pl/Index/Index");
            var elementXPath = "//td[@id='td_menu']/ul/li[2]/a";
            var element =
                webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(elementXPath)));

            element.Click();
        }
        
        [When(@"I click on reset password, provide wrong email and I click reset")]
        public void WhenIClickOnResetPasswordProvideWrongEmailAndIClickReset()
        {
            var resetPwButton =
                webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("Przypomnienie-Hasla-Student")));
            resetPwButton.Click();

            var email =
                webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("haslo")));
            email.SendKeys("test@test.pl");

            webdriver.FindElement(By.CssSelector("a.przycisk")).Click();
            Thread.Sleep(5000);
        }
        
        [Then(@"An error message appears")]
        public void ThenAnErrorMessageAppears()
        {
            var errorMsgCssSelector = "#td_tresc p.komunikat";
            webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(errorMsgCssSelector)));

            var errorMessage = webdriver.FindElement(By.CssSelector(errorMsgCssSelector)).GetAttribute("innerHTML");
            Assert.IsTrue(errorMessage.Contains("Requested E-mail address not found"));
        }
    }
}
