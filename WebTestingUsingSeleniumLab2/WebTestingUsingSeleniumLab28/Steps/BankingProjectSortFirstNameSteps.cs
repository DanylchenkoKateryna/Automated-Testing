namespace SpecFlowPageObjectWebDriver.Steps
{
    [Binding]
    public class BankingProjectSortFirstNameSteps : BaseSteps
    {
        private BankManagerLoginPage _bankManagerLoginPage;
        private HomePage _homePage;
        private CustomersPage _customersPage;
        public BankingProjectSortFirstNameSteps()
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login";
            _homePage = new HomePage(driver);
            _customersPage = new CustomersPage(driver);
            _bankManagerLoginPage= new BankManagerLoginPage(driver);
        }
        [BeforeScenario]
        public void Navigation()
        {
            _homePage.ClickBankManagerLogin();
            _bankManagerLoginPage.ClickCustomersButton();
        }

        [When(@"click on the First Name title")]
        public void WhenClickOnTheFirstNameTitle()
        {
            _customersPage.ClickFirstNameTitle();
        }
       
        [Then(@"the users should be sorted alphabetically by first name")]
        public void ThenTheUsersShouldBeSortedAlphabeticallyByFirstName()
        {
            
            var userNames = _customersPage.GeFirstNames();

            var isSorted = IsListSorted(userNames);

            Assert.IsTrue(isSorted, "Users are not sorted alphabetically by first name");
        }

        private bool IsListSorted(List<string> list)
        {

            return list.SequenceEqual(list.OrderByDescending(x => x, StringComparer.OrdinalIgnoreCase));
        }
    }
}
