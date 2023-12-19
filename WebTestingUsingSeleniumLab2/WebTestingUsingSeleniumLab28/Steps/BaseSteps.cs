
namespace SpecFlowPageObjectWebDriver.Steps
{
    [Binding]
    public class BaseSteps
    {
        protected static WebDriverWait wait;
        protected static IWebDriver driver;
        [BeforeFeature]
        public static void BeforeFeauture()
        {
            driver = new ChromeDriver(@".\");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            driver.Close();
        }
    }
}
