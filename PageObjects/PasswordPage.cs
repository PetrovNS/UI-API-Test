using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API.PageObjects
{
    public class PasswordPage : Form
    {
        public PasswordPage() : base(By.XPath("//input[contains(@type,'password')]"), "Login Page") { }

        private ITextBox PasswordBox => ElementFactory.GetTextBox(By.XPath("//input[contains(@type,'password')]"), "Password input");
        private IButton SubmitButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Submit button");

        public void InputPassword(string password) => PasswordBox.SendKeys(password);
        public void ClickSubmit() => SubmitButton.Click();
    }
}
