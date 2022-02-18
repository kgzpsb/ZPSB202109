using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumTests
{
    public enum TypeDriver
    {
        Chrome,
        Firefox,
        Edge,
        Safari,
        InternetExplorer
    }

    class DriverFactory
    {
        public static IWebDriver GetDriver(TypeDriver type)
        {
            IWebDriver webdriver;
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch (type)
            {
                case TypeDriver.Chrome:
                    webdriver = new ChromeDriver(path);
                    break;
                case TypeDriver.Firefox:
                    webdriver = new FirefoxDriver(path);
                    break;
                case TypeDriver.Edge:
                    webdriver = new EdgeDriver(path);
                    break;
                case TypeDriver.InternetExplorer:
                    webdriver = new InternetExplorerDriver(path);
                    break;
                case TypeDriver.Safari:
                    webdriver = new SafariDriver(path);
                    break;
                default:
                    throw new ArgumentException("Wrong driver type");
            }

            return webdriver;
        }
    }
}
