namespace UITests
{
    [SetUpFixture]
    public class Config
    {
        public static string BaseUrl;
        public static string Browser;
        public static int DefaultWaitTime;
        public static bool CleanScreenshotsEveryRun;

        protected IConfiguration Configuration { get; private set; }

        public Config()
        {
            var configPath = Path.Combine(FileManagement.ProjectDir, "appsettings.json");

            Configuration = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();
        }

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            SetConfiguration();

            FileManagement.CleanDownloadsFolder();

            if (CleanScreenshotsEveryRun)
                FileManagement.CleanOnFailureFolder();
        }

        public static void SetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(FileManagement.ProjectDir, "appsettings.json"));
            var root = builder.Build();

            BaseUrl = root.GetSection("BaseUrl").Value;
            Browser = root.GetSection("Browser").Value;
            DefaultWaitTime = int.Parse(root.GetSection("DefaultWaitTime").Value);
            CleanScreenshotsEveryRun = bool.Parse(root.GetSection("CleanScreenshotsEveryRun").Value);
        }
    }
}