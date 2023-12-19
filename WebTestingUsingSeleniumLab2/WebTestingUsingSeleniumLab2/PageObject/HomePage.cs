using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObject
{
    public class HomePage : BasePage
    {
        private static WebDriverWait wait;
        private By BankManagerLoginButton = By.XPath("/html/body/div/div/div[2]/div/div[1]/div[2]/button");
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }
        public void ClickBankManagerLogin() => wait.Until(ExpectedConditions.ElementToBeClickable(BankManagerLoginButton)).Click();  
    }
}
