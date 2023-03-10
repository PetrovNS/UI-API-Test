using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VK_API.PageObjects
{
    public class PersonalPage : Form
    {
        public PersonalPage() : base(By.XPath("//h2[@id='owner_page_name']"), "Personal page") { }

        private ILink PostAuthor(int Id) => ElementFactory.GetLink(By.XPath($"//div[contains(@id,'{Id}')]//a[@class='author']"), "Post author");
        private ILabel PostText(int Id) => ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{Id}')]//div[contains(@class,'wall_post_text')]"), "Text from the post");
        private ILabel ImageInAlbum => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'pv_img')]//img"), "Image in the album");
        private ILabel PostImage(int postId) => ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{postId}')]//a[contains(@class,'page_post')]"), "Image from the wall");
        private ILink ShowCommentsLink(int Id) => ElementFactory.GetLink(By.XPath($"//a[contains(@href,'{Id}')]//span[contains(@class,'replies_next_label')]"), "Show comments link");
        private ILabel CommentText(int Id) => ElementFactory.GetLabel(By.XPath($"//div[contains(@id,'{Id}')]//div[@class='wall_reply_text']"), "Text from the comment");
        private ILink CommentAuthor(int Id) => ElementFactory.GetLink(By.XPath($"//div[contains(@id,'{Id}')]//a[@class='author']"), "Comment author");
        private IButton CloseAlbumButton => ElementFactory.GetButton(By.XPath($"//div[@class='pv_close_btn']"), "Close Album button");
        private IButton LikeButton(int Id) => ElementFactory.GetButton(By.XPath($"//div[contains(@data-reaction-target-object,'{Id}')]"), "Like reaction button");
        private ILabel PostOnTheWall(int userId, int postId) => ElementFactory.GetLabel(By.XPath($"//div[@id='page_wall_posts']//div[contains(@id,'post{userId}_{postId}')]"), "Post on the wall");

        public string GetPostAuthorId(int postId) => PostAuthor(postId).GetAttribute("href");
        public string GetPostImageUrl() => ImageInAlbum.GetAttribute("src");
        public string GetPostText(int postId) => PostText(postId).GetText();
        public string GetCommentText(int commentId) => CommentText(commentId).GetText();
        public string GetCommentAuthorId(int commentId) => CommentAuthor(commentId).GetAttribute("href");
        public void ClickShowComments(int postId) => ShowCommentsLink(postId).Click();
        public void ClickPostImage(int postId) => PostImage(postId).Click();
        public void ClickCloseAlbum() => CloseAlbumButton.Click();
        public void ClickLikeOnPost(int postId) => LikeButton(postId).ClickAndWait();
        public bool IsPostNotDisplayed(int userId, int postId) => PostOnTheWall(userId, postId).State.WaitForNotDisplayed();
    }
}