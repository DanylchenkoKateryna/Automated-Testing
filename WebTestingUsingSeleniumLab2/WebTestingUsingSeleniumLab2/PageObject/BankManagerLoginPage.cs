using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PageObject
{
    public class BankManagerLoginPage : BasePage
    {
        private static WebDriverWait wait;
        private By CustomerButton = By.XPath("/html/body/div/div/div[2]/div/div[1]/button[3]");
        public BankManagerLoginPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }

        public void ClickCustomersButton() => wait.Until(ExpectedConditions.ElementToBeClickable(CustomerButton)).Click();
    }
}
