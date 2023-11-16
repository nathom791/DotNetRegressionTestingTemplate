namespace UITests.Pages
{
    internal class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        private BaseTest baseTest = new();

        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            driver = baseTest.Driver;
            wait = baseTest.Wait;
        }

        /// <summary>
        /// Wrapped find method, includes wait where the maxTimeout is an optional parameter
        /// Note: This is not required to use, and in some cases is not desirable to use.
        /// </summary>
        public IWebElement Find(By by, int maxTimeOut = 0)
        {
            WaitFor(by, maxTimeOut);

            //Set the timeout back to default if custom
            if (maxTimeOut != 0)
            {
                wait.Timeout = TimeSpan.FromSeconds(Config.DefaultWaitTime);
            }

            return driver.FindElement(by);
        }

        /// <summary>
        /// Automatic retry when wait condition fails
        /// </summary>
        public virtual void WaitFor(By by, int maxTimeout = 0)
        {
            //If the max timeout is not passed, then take the value from the appsettings.config
            if (maxTimeout == 0)
            {
                wait.Timeout = TimeSpan.FromSeconds(Config.DefaultWaitTime);
            }
            else
            {
                wait.Timeout = TimeSpan.FromSeconds(maxTimeout);
            }

            IWebElement elementToBeDisplayed;
            var element = wait.Until(condition =>
            {
                try
                {
                    elementToBeDisplayed = driver.FindElement(by);
                    return elementToBeDisplayed.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotInteractableException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });

            if (maxTimeout != Config.DefaultWaitTime)
            {
                wait.Timeout = TimeSpan.FromSeconds(Config.DefaultWaitTime);
            }
        }

        //Actions based Methods
        public void ManualClearField()
        {
            Actions actions = new(driver);
            actions.KeyDown(Keys.Control).Build().Perform();
            actions.SendKeys("a").Build().Perform();
            actions.KeyUp(Keys.Control).Build().Perform();
            actions.SendKeys(Keys.Delete).Build().Perform();
        }

        //Javascript methods
        public void SetAttribute(IWebElement element, string attributeName, string attributeValue)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);",
                    element, attributeName, attributeValue);
        }

        public void JsClickBy(By ele)
        {
            WaitFor(ele);
            IWebElement element = driver.FindElement(ele);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public void JsClickElement(IWebElement ele)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", ele);
        }

        public string JsGetSelection()
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return window.getSelection().toString();").ToString();
        }

        /// <summary>
        /// Switch to the new tab.
        /// </summary>
        /// <param name="driver"></param>
        public void SwitchLastWindow()
        {
            wait.Until(condition => driver.WindowHandles.Count > 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        /// <summary>
        /// Close last open tab
        /// </summary>
        /// <param name="driver"></param>
        public void CloseLastWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
        }

        /// <summary>
        /// Switch to the first tab.
        /// </summary>
        /// <param name="driver"></param>
        public void SwitchFirstWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        /// <summary>
        /// Scroll to the top of the page
        /// </summary>
        public void ScrollToTop()
        {
            Actions actions = new(driver);
            actions.SendKeys(Keys.Home).Build().Perform();
        }

        /// <summary>
        /// Scroll to the bottom of the page
        /// </summary>
        public void ScrollToBottom()
        {
            Actions actions = new(driver);
            actions.SendKeys(Keys.End).Build().Perform();
        }
    }
}