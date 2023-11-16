namespace UITests
{
    public class SetupDriver
    {
        public IWebDriver StartDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "firefox":
                    FirefoxDriverService geckoService = FirefoxDriverService.CreateDefaultService();
                    return new FirefoxDriver(geckoService, FfOptions(), TimeSpan.FromSeconds(360));

                default:
                    return new ChromeDriver(ChromeDriverService.CreateDefaultService(), ChromeOptions(), TimeSpan.FromSeconds(360));
            }
        }

        private static ICapabilities ChromeCapabilities() => ChromeOptions().ToCapabilities();

        private static ICapabilities FFCapabilities() => FfOptions().ToCapabilities();

        //Leaving options here as they can be a little tricky to find on the web :) Pick your poison!
        private static ChromeOptions ChromeOptions(bool isSmoke = false)
        {
            ChromeOptions options = new();
            options.AddExcludedArgument("enable-automation");
            options.AddUserProfilePreference("download.default_directory", FileManagement.DownloadsDir);
            //options.AddArgument("--disable-dev-shm-usage");
            //options.AddUserProfilePreference("safebrowsing.enabled", true);
            //options.AddUserProfilePreference("disable-popup-blocking", true);
            //options.AddUserProfilePreference("chrome.switches", "--disable-extensions");
            //options.AddUserProfilePreference("chrome.switches", "--disable-web-security");
            //options.AddUserProfilePreference("chrome.switches", "--allow-running-insecure-content");
            //options.AddUserProfilePreference("download.prompt_for_download", false);
            //options.AddUserProfilePreference("download.directory_upgrade", true);
            //options.AddUserProfilePreference("credentials_enable_service", false);
            //options.AddUserProfilePreference("profile.password_manager_enabled", false);
            //options.AddAdditionalOption("useAutomationExtension", false);
            return options;
        }

        private static FirefoxOptions FfOptions()
        {
            FirefoxOptions options = new();
            options.AcceptInsecureCertificates = true;
            options.SetPreference("browser.download.dir", FileManagement.DownloadsDir);
            //options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            //options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            //options.SetPreference("browser.download.manager.focusWhenStarting", true);
            //options.SetPreference("browser.download.manager.useWindow", false);
            //options.SetPreference("browser.download.manager.showWhenStarting", false);
            //options.SetPreference("browser.download.manager.closeWhenDone", false);
            //options.SetPreference("browser.download.animateNotifications", false);
            //options.SetPreference("widget.windows.window_occlusion_tracking.enabled", false);
            //options.SetPreference("browser.download.folderList", 1);
            //options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            //options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
            //options.LogLevel = FirefoxDriverLogLevel.Trace;
            return options;
        }
    }
}