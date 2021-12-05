using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps
{
    [Binding]
    public class WPPLSteps
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverWait;
        private LoginEmailPage loginPage;

        public WPPLSteps(IWebDriver driver)
        {
            loginPage = new LoginEmailPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver = driver;
            webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Given(@"I enter wp\.pl")]
        public void GivenIEnterWp_Pl()
        {
            webdriver.Navigate().GoToUrl("http://www.wp.pl");
            //wait for load
            Thread.Sleep(5000);
            var popup = "/html/body/div[2]/div/div[2]/div[3]/div/button[2]";
            var element = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(popup)));
            // bad practice
            Thread.Sleep(5000);
            element.Click();
        }

        [Given(@"I click on (.*)")]
        public void GivenIClickOn(string p0)
        {
            // bad practice
            Thread.Sleep(5000);
            var firstXPath = "//a//span[text()='Poczta']";
            var elementPoczta = webdriver.FindElement(By.XPath(firstXPath));
            elementPoczta.Click();
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
            var submitBtnCssSelector = "#btnSubmit";
            var submitBtn = webdriver.FindElement(By.CssSelector("sc-bdvvtL sc-gsDKAQ styled__SubmitButton-sc-1bs2nwv-2 ekJwFE hIxhWw jyhBDA"));
            Thread.Sleep(5000);
            submitBtn.Click();
            Thread.Sleep(5000);
        }

        [Then(@"I expect to see message as „Niestety podany login lub hasło jest błędne\.”")]
        public void ThenIExpectToSeeMessageAsNiestetyPodanyLoginLubHasloJestBledne_()
        {
            //Zaimplementowac
        }
    }
}
