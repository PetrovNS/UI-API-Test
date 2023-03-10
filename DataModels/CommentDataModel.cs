using Newtonsoft.Json;

namespace VK_API.DataModels
{
    public class CommentDataModel
    {
        [JsonProperty("response")]
        public CommentsId Response { get; set; }
    }
    public class CommentsId
    {
        [JsonProperty("comment_id")]
        public int CommentId { get; set; }
    }
}
