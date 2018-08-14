using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace awesome_bot.Giphy
{
    public class GiphyResponse
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };

        [JsonProperty("data")] public Data[] Data { get; set; }

        public static GiphyResponse FromJson(string json)
            => JsonConvert.DeserializeObject<GiphyResponse>(json, Settings);

        public string ToJson() => JsonConvert.SerializeObject(this, Settings);
    }

    public class Data
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("slug")] public string Slug { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("bitly_gif_url")] public string BitlyGifUrl { get; set; }

        [JsonProperty("bitly_url")] public string BitlyUrl { get; set; }

        [JsonProperty("embed_url")] public string EmbedUrl { get; set; }

        [JsonProperty("username")] public string Username { get; set; }

        [JsonProperty("source")] public string Source { get; set; }

        [JsonProperty("rating")] public string Rating { get; set; }

        [JsonProperty("content_url")] public string ContentUrl { get; set; }

        [JsonProperty("source_tld")] public string SourceTld { get; set; }

        [JsonProperty("source_post_url")] public string SourcePostUrl { get; set; }

        [JsonProperty("is_sticker")] public long IsSticker { get; set; }

        [JsonProperty("import_datetime")] public DateTimeOffset ImportDatetime { get; set; }

        [JsonProperty("trending_datetime")] public DateTimeOffset TrendingDatetime { get; set; }

        [JsonProperty("images")] public Images Images { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("_score")] public double Score { get; set; }
    }

    public class Images
    {
        [JsonProperty("original")] public Dictionary<string, string> Original { get; set; }
    }

    public class Meta
    {
        [JsonProperty("status")] public long Status { get; set; }

        [JsonProperty("msg")] public string Msg { get; set; }

        [JsonProperty("response_id")] public string ResponseId { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("total_count")] public long TotalCount { get; set; }

        [JsonProperty("count")] public long Count { get; set; }

        [JsonProperty("offset")] public long Offset { get; set; }
    }
}