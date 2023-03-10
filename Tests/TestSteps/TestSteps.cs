using Aquality.Selenium.Browsers;
using VK_API.PageObjects;
using VK_API.TestData;

namespace VK_API.Tests.TestSteps
{
    public static class Authorization
    {
        public static void AuthorizationStep()
        {
            AqualityServices.Logger.Info("Go to login page");
            LoginPage loginPage = new();
            Assert.IsTrue(loginPage.State.WaitForDisplayed(), "Login page is not open");
            loginPage.InputLogin(TestDataManager.Login);
            AqualityServices.Logger.Info("Go to password page");
            loginPage.ClickSubmit();
            PasswordPage passwordPage = new();
            Assert.IsTrue(passwordPage.State.WaitForDisplayed(), "Password page is not open");
            passwordPage.InputPassword(TestDataManager.Password);
            passwordPage.ClickSubmit();
        }
    }
}
