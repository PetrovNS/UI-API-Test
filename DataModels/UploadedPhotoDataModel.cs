using Newtonsoft.Json;

namespace VK_API.DataModels
{
    public class UploadedPhotoDataModel
    {
        [JsonProperty("server")]
        public int Server { get; set; }
        [JsonProperty("photo")]
        public string Photo { get; set; }
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
