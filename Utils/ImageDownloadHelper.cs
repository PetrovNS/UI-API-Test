using AngleSharp.Dom;
using System.Net;

namespace VK_API.Utils
{
    public static class ImageDownloadHelper
    {
        public static void ImageDownloader(string imageUrl, string filePath)
        {
            WebClient client = new();
            client.DownloadFile(new Url(imageUrl), filePath);
        }
    }
}
