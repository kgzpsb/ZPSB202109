using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private IWebDriver webdriver;
        private readonly IObjectContainer _objectContainer;

        public Hooks1(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            //webdriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            webdriver = DriverFactory.GetDriver(TypeDriver.Chrome);

            _objectContainer.RegisterInstanceAs<IWebDriver>(webdriver);


        }




        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            var errorClass = new SaveErrorDetails(webdriver);
            errorClass.SaveScreenshotAndLogsOnError();

            webdriver.Close();
            webdriver.Dispose();
        }
    }
}
