namespace UITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }

        [SetUp]
        public void Setup()
        {
            SetupDriver setupDriver = new();
            Driver = setupDriver.StartDriver(Config.Browser);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Config.DefaultWaitTime));
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }
    }
}