using OpenQA.Selenium;

namespace SpecFlowProject1.Pages
{
    public class LoginEmailPage
    {
        IWebDriver webdriver;
        public LoginEmailPage(IWebDriver driver)
        {
            webdriver = driver;
            
        }

        By loginBy = By.Id("login");
        By passBy = By.Id("password");

        public IWebElement login => webdriver.FindElement(loginBy);
        public IWebElement pass => webdriver.FindElement(passBy);


        //[FindsBy(How = How.Id, Using = "login")]
        //public IWebElement login { get; set; }

        //[FindsBy(How = How.Name, Using = "password")]
        //public IWebElement pass { get; set; }
    }
}
