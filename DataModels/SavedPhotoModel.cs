using Newtonsoft.Json;

namespace VK_API.DataModels
{
    public class SavedPhotoModel
    {
        [JsonProperty("response")]
        public List<SavedPhoto> Response { get; set; }
    }
    public class SavedPhoto
    {
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }
        [JsonProperty("date")]
        public int Date { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }
        [JsonProperty("sizes")]
        public List<Size> Sizes { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class Size
    {
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
