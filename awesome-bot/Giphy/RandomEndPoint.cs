namespace awesome_bot.Giphy
{
    public static partial class GiphyEndPoints
    {
        public class RandomEndPoint
        {
            private const string RandomPath = "/v1/gifs/random";

            public string Build(string searchText, Rating rating = null)
                => string.Join(string.Empty, Root, RandomPath, "?",
                    $"api_key={ApiKey}&tag={searchText}&rating={rating ?? Rating.PG13}");
        }
    }
}