using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace VK_API.DataModels
{
    public class IsLikedResponseDataModel
    {
        [JsonProperty("response")]
        public IsLiked Response { get; set; }
    }
    public class IsLiked
    {
        [JsonProperty("liked")]
        public int Liked { get; set; }
        [JsonPropertyName("copied")]
        public int Copied { get; set; }
    }
}
