using Aquality.Selenium.Browsers;
using Newtonsoft.Json;
using RestSharp;
using VK_API.DataModels;
using VK_API.TestData;

namespace VK_API.Utils
{
    public static class VkApiUtils
    {
        private static IRestClient restClient = new RestClient(APIDataManager.MainAPIUrl);
        public static int MakePostOnTheWallAndGetId(string message)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.MakeNewPostOnTheWall, TestDataManager.UserId, message, TestDataManager.Token));
            return JsonConvert.DeserializeObject<PostDataModel>(restClient.Post(restRequest).Content).Response.PostId;
        }
        private static string WallUploadServerUrl()
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.GetWallUploadServer, TestDataManager.UserId, TestDataManager.Token));
            return JsonConvert.DeserializeObject<UploadServerModel>(restClient.Get(restRequest).Content).Response.UploadUrl;
        }
        public static UploadedPhotoDataModel SendImageToServer(string imagePath)
        {
            AqualityServices.Logger.Info("Get upload server Url");
            IRestRequest restRequest = new RestRequest(WallUploadServerUrl(), DataFormat.Json);
            restRequest.AddFile("photo", imagePath, "multipart/form-data");
            return JsonConvert.DeserializeObject<UploadedPhotoDataModel>(restClient.Post(restRequest).Content);
        }
        public static SavedPhotoModel SaveUploadWallPhoto(string photo, int server, string hash)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.SaveUploadWallPhoto, TestDataManager.UserId, photo, server, hash, TestDataManager.Token));
            return JsonConvert.DeserializeObject<SavedPhotoModel>(restClient.Post(restRequest).Content);
        }
        public static IRestResponse EditPostOnTheWall(int postId, string message, int imageId)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.EditPostOnTheWall, TestDataManager.UserId, postId, message,
            TestDataManager.UserId, imageId, TestDataManager.Token));
            return restClient.Post(restRequest);
        }
        public static int CreateCommentToThePostAndGetId(int postId, string message)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.CreateCommentToThePost, TestDataManager.UserId, postId, message, TestDataManager.Token));
            return JsonConvert.DeserializeObject<CommentDataModel>(restClient.Post(restRequest).Content).Response.CommentId;
        }
        public static int PostIsLiked(int postId)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.PostIsLiked, TestDataManager.UserId, postId, TestDataManager.Token));
            return JsonConvert.DeserializeObject<IsLikedResponseDataModel>(restClient.Get(restRequest).Content).Response.Liked;
        }
        public static List<int> GetListUsersWhoLikes(int postId)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.GetListUsersWhoLikes, TestDataManager.UserId, postId, TestDataManager.Token));
            return JsonConvert.DeserializeObject<WhoLikesPostDataModel>(restClient.Get(restRequest).Content).Response.Items;
        }
        public static IRestResponse DeletePostFromTheWall(int postId)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.DeletePostFromTheWall, TestDataManager.UserId, postId, TestDataManager.Token));
            return restClient.Get(restRequest);
        }
    }
}