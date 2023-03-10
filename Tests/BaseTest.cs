using Aquality.Selenium.Browsers;
using VK_API.TestData;

namespace VK_API.Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.GoTo(TestDataManager.MainPageUrl);
            AqualityServices.Browser.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}