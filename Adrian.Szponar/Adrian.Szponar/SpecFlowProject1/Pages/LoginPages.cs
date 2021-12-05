using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class LoginEmailPage
    {
        public LoginEmailPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement login { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement pass { get; set; }
    }
}
