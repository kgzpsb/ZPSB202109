using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2
{
    public class LoginEmailPage
    {
        IWebDriver webDriver;
        By loginBy = By.Id("login");

        public LoginEmailPage(IWebDriver driver)
        {
            webDriver = driver;
        }

        public IWebElement login => webDriver.FindElement(loginBy);
        public IWebElement pass => webDriver.FindElement(By.Name("password"));
    }

}
