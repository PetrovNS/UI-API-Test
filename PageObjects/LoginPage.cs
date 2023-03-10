using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API.PageObjects
{
    public class LoginPage : Form
    {
        public LoginPage() : base(By.XPath("//input[@id='index_email']"), "Login Page") { }

        private ITextBox LoginBox => ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), "Login input");
        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'signInButton')]"), "Submit button");

        public void InputLogin(string login) => LoginBox.SendKeys(login);
        public void ClickSubmit() => SubmitButton.Click();
    }
}
