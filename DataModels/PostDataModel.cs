using Newtonsoft.Json;

namespace VK_API.DataModels
{
    public class ResponseBody
    {
        [JsonProperty("post_id")]
        public int PostId { get; set; }
    }

    public class PostDataModel
    {
        [JsonProperty("response")]
        public ResponseBody Response { get; set; }
    }
}
