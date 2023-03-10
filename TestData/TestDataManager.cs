using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VK_API.TestData
{
    public static class TestDataManager
    {
        private static ISettingsFile testData = new JsonSettingsFile("TestData.json");
        public static string MainPageUrl => testData.GetValue<string>("mainPageUrl");
        public static string Login => testData.GetValue<string>("login");
        public static string Password => testData.GetValue<string>("password");
        public static int UserId => testData.GetValue<int>("userId");
        public static string Token => testData.GetValue<string>("access_token");
    }
}

