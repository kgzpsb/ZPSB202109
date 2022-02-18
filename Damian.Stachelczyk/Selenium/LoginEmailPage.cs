using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests
{
    class LoginEmailPage
    {
        private IWebDriver webdriver;

        public LoginEmailPage(IWebDriver driver)
        {
            webdriver = driver;
        }

        public IWebElement login => webdriver.FindElement(By.Id("login"));

        public IWebElement pass => webdriver.FindElement(By.Name("password"));
    }
}
