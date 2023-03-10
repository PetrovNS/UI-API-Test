using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API.PageObjects
{
    public class SideBarForm : Form
    {
        public SideBarForm() : base(By.XPath("//nav[@class='side_bar_nav']"), "Side bar form") { }

        private ILink MyPageButton => ElementFactory.GetLink(By.XPath("//li[@id='l_pr']"), "Link to personal page");

        public void GoToPersonalPage() => MyPageButton.WaitAndClick();
    }
}
