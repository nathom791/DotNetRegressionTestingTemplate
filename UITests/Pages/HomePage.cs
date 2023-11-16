namespace UITests.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver Driver, WebDriverWait Wait) : base(Driver, Wait)
        {
            driver = Driver;
            wait = Wait;
        }

        public IWebElement CheckOutTheDocsLink => Find(By.LinkText("Check out the docs!"));
    }
}