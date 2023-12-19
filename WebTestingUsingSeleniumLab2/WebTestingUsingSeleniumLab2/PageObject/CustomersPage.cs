using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PageObject
{
    public class CustomersPage : BasePage
    {
        private static WebDriverWait wait;
        private By FirstNameTitle = By.XPath("/html/body/div/div/div[2]/div/div[2]/div/div/table/thead/tr/td[1]/a");
        private By FindTable = By.TagName("tbody");
        private By FindRows = By.TagName("tr");
        private By FindCells = By.XPath("td");
        public CustomersPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }

        public void ClickFirstNameTitle() => wait.Until(ExpectedConditions.ElementToBeClickable(FirstNameTitle)).Click();
        private IWebElement table => driver.FindElement(FindTable);
        private IList<IWebElement> rows => table.FindElements(FindRows);
        public List<string> GeFirstNames()
        {
            List<string> list = new List<string>();
            int columnIndex = 0;
            foreach (var row in rows)
            {
                IList<IWebElement> cells = row.FindElements(FindCells);
                if (columnIndex < cells.Count)
                {
                    string cellValue = cells[columnIndex].Text;
                    list.Add(cellValue);
                }
            }
            return list;
        }
    }
}
