using Newtonsoft.Json;

namespace VK_API.DataModels
{
    public class WhoLikesPostDataModel
    {
        [JsonProperty("response")]
        public UsersWhoLikes Response { get; set; }
    }
    public class UsersWhoLikes
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("items")]
        public List<int> Items { get; set; }
    }
}
