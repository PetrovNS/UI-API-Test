using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VK_API.TestData
{
    public static class APIDataManager
    {
        private static ISettingsFile APIData = new JsonSettingsFile("APIData.json");
        public static string MainAPIUrl => APIData.GetValue<string>("mainAPIUrl");
        public static string MakeNewPostOnTheWall => APIData.GetValue<string>("makeNewPostOnTheWall");
        public static string GetWallUploadServer => APIData.GetValue<string>("getWallUploadServer");
        public static string SaveUploadWallPhoto => APIData.GetValue<string>("saveUploadWallPhoto");
        public static string EditPostOnTheWall => APIData.GetValue<string>("editPostOnTheWall");
        public static string CreateCommentToThePost => APIData.GetValue<string>("createCommentToThePost");
        public static string PostIsLiked => APIData.GetValue<string>("postIsLiked");
        public static string GetListUsersWhoLikes => APIData.GetValue<string>("getListUsersWhoLikes");
        public static string DeletePostFromTheWall => APIData.GetValue<string>("deletePostFromTheWall");
    }
}