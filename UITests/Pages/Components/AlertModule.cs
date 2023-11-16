namespace UITests.Pages.Components
{
    internal class AlertModule : BasePage
    {
        public AlertModule(IWebDriver Driver, WebDriverWait Wait) : base(Driver, Wait)
        {
            driver = Driver;
            wait = Wait;
        }

        public IWebElement AlertCloseButton => Find(By.CssSelector("button[title='Dismiss']"));
        public IList<IWebElement> AllAlertCloseButtons => driver.FindElements(By.CssSelector("button[title='Dismiss']"));
    }
}