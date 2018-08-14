namespace awesome_bot.Giphy
{
    public static partial class GiphyEndPoints
    {
        public class SearchEndPoint
        {
            private const string RandomPath = "/v1/gifs/search";

            public string Build(string searchText, Rating rating = null)
                => string.Join(string.Empty, Root, RandomPath, "?",
                    $"api_key={ApiKey}&q={searchText}&limit={1}&rating={rating ?? Rating.PG13}");
        }
    }
}