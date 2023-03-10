using Aquality.Selenium.Browsers;
using VK_API.PageObjects;
using VK_API.TestData;
using VK_API.Tests.TestSteps;
using VK_API.Utils;

namespace VK_API.Tests
{
    public class VKTests : BaseTest
    {
        private const int RandomStringLength = 8;
        private const int IndexOfUploadedImage = 0;
        private const int IsLikedResponse = 1;
        private const string UploadImagePath = "Resources\\photo123.jpg";
        private const string DownloadImagePath = "Resources\\img.jpg";
        private const float CustomThresholdValue = 0.1f;
        [Test]
        public void AddEditDeletePostUploadImageAddCommentAndLikeTest()
        {
            Authorization.AuthorizationStep();
            AqualityServices.Logger.Info("Pass the authorization");
            SideBarForm sideBar = new();
            Assert.IsTrue(sideBar.State.WaitForDisplayed(), "Authorization failed");
            AqualityServices.Logger.Info("Go to personal page");
            sideBar.GoToPersonalPage();
            PersonalPage personalPage = new();
            Assert.IsTrue(personalPage.State.WaitForDisplayed(), "Personal page is not open");
            var postMessage = RandomGenerator.RandomString(RandomStringLength);
            AqualityServices.Logger.Info("Add new post to the personal page");
            int postId = VkApiUtils.MakePostOnTheWallAndGetId(postMessage);
            Assert.AreEqual(postMessage, personalPage.GetPostText(postId), "Texts in post are different");
            StringAssert.Contains(TestDataManager.UserId.ToString(), personalPage.GetPostAuthorId(postId), "Authors are different");
            AqualityServices.Logger.Info("Upload image to the server");
            var uploadImageToServer = VkApiUtils.SendImageToServer(UploadImagePath);
            var saveUploadedWallPhoto = VkApiUtils.SaveUploadWallPhoto(uploadImageToServer.Photo, uploadImageToServer.Server, uploadImageToServer.Hash);
            var editPostMessage = RandomGenerator.RandomString(RandomStringLength);
            AqualityServices.Logger.Info("Edit post from the wall");
            VkApiUtils.EditPostOnTheWall(postId, editPostMessage, saveUploadedWallPhoto.Response[IndexOfUploadedImage].Id);
            Assert.AreNotEqual(postMessage, personalPage.GetPostText(postId), "Texts in new post and edited post are similar");
            personalPage.ClickPostImage(postId);
            ImageDownloadHelper.ImageDownloader(personalPage.GetPostImageUrl(), DownloadImagePath);
            personalPage.ClickCloseAlbum();
            Assert.IsTrue(ImagesComparator.CheckThatActualAndExpectedImagesAreTheSame(UploadImagePath, CustomThresholdValue, DownloadImagePath), "The images should be the same");
            var commentMessage = RandomGenerator.RandomString(RandomStringLength);
            AqualityServices.Logger.Info("Add comment to the post");
            var commentId = VkApiUtils.CreateCommentToThePostAndGetId(postId, commentMessage);
            personalPage.ClickShowComments(postId);
            Assert.AreEqual(commentMessage, personalPage.GetCommentText(commentId), "Texts in comment are different");
            StringAssert.Contains(TestDataManager.UserId.ToString(), personalPage.GetCommentAuthorId(commentId), "Comment authors are different");
            AqualityServices.Logger.Info("Click like on post and check it with API");
            personalPage.ClickLikeOnPost(postId);
            Assert.IsTrue(VkApiUtils.PostIsLiked(postId) == IsLikedResponse, "Post is not liked");
            var listOfUsersWhoLikes = VkApiUtils.GetListUsersWhoLikes(postId);
            Assert.IsTrue(ListHelper.CompareItemsInList(listOfUsersWhoLikes, TestDataManager.UserId), "The like is not from the right user");
            AqualityServices.Logger.Info("Delete post from the wall");
            VkApiUtils.DeletePostFromTheWall(postId);
            Assert.IsTrue(personalPage.IsPostNotDisplayed(TestDataManager.UserId, postId), "The post still exists");
        }
    }
}