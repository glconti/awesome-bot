using System.Web.Configuration;

namespace awesome_bot.Giphy
{
    public static partial class GiphyEndPoints
    {
        private const string Root = "https://api.giphy.com";
        private static string ApiKey { get; } = WebConfigurationManager.AppSettings["GiphyAPIKey"];

        public static RandomEndPoint Random { get; } = new RandomEndPoint();
    }
}