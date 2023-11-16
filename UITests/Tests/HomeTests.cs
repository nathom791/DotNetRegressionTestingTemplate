using UITests.Pages;
using UITests.Pages.Components;
using UITests.Pages.Constants;

namespace UITests.Tests
{
    internal class HomeTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl(Config.BaseUrl);
        }

        [Test]
        public void ClickingCheckOutTheDocsNavigatesToDocs()
        {
            HomePage home = new(Driver, Wait);
            home.CheckOutTheDocsLink.Click();

            DocsPage docs = new(Driver, Wait);
            Assert.That(docs.ResourceListPaginationLink.Displayed, Is.True);
            Assert.That(Driver.Url, Is.EqualTo(Config.BaseUrl + RelativePaths.Docs));
        }

        [Test]
        public void ClickDismissOnAlertClosesAlert()
        {
            AlertModule alert = new(Driver, Wait);
            int alertCount = alert.AllAlertCloseButtons.Count;

            alert.AllAlertCloseButtons[0].Click();

            alert = new(Driver, Wait);
            Assert.That(alert.AllAlertCloseButtons.Count, Is.EqualTo(1));
        }
    }
}