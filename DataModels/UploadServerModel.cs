using Newtonsoft.Json;

namespace VK_API.DataModels
{
    public class ResponseUrl
    {
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }
        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }

    public class UploadServerModel
    {
        [JsonProperty("response")]
        public ResponseUrl Response { get; set; }
    }
}
