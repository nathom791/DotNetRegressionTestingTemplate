namespace UITests.Pages
{
    internal class DocsPage : BasePage
    {
        public DocsPage(IWebDriver Driver, WebDriverWait Wait) : base(Driver, Wait)
        {
            driver = Driver;
            wait = Wait;
        }

        public IWebElement ResourceListPaginationLink => Find(By.LinkText("Resource Lists/Pagination"));
    }
}