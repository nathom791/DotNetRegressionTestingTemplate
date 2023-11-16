namespace APITests.Tests
{
    public class BaseTest
    {
        protected HttpClient Client { get; private set; }
        protected IConfiguration Configuration { get; private set; }

        [SetUp]
        public void Setup()
        {
            var configPath = Path.Combine(FileManagement.ProjectDir, "appsettings.json");

            Configuration = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();

            Client = new HttpClient
            {
                BaseAddress = new Uri(Configuration["BaseUrl"])
            };
        }

        [TearDown]
        public void TearDown()
        {
            Client?.Dispose();
        }
    }
}