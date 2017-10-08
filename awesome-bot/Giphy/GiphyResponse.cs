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

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        public static GiphyResponse FromJson(string json)
            => JsonConvert.DeserializeObject<GiphyResponse>(json, Settings);

        public string ToJson() => JsonConvert.SerializeObject(this, Settings);
    }

    public class Data
    {
        [JsonProperty("fixed_height_small_width")]
        public string FixedHeightSmallWidth { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fixed_height_downsampled_width")]
        public string FixedHeightDownsampledWidth { get; set; }

        [JsonProperty("fixed_height_downsampled_height")]
        public string FixedHeightDownsampledHeight { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("fixed_height_downsampled_url")]
        public string FixedHeightDownsampledUrl { get; set; }

        [JsonProperty("fixed_height_small_still_url")]
        public string FixedHeightSmallStillUrl { get; set; }

        [JsonProperty("fixed_height_small_height")]
        public string FixedHeightSmallHeight { get; set; }

        [JsonProperty("fixed_height_small_url")]
        public string FixedHeightSmallUrl { get; set; }

        [JsonProperty("fixed_width_small_height")]
        public string FixedWidthSmallHeight { get; set; }

        [JsonProperty("fixed_width_downsampled_url")]
        public string FixedWidthDownsampledUrl { get; set; }

        [JsonProperty("fixed_width_downsampled_height")]
        public string FixedWidthDownsampledHeight { get; set; }

        [JsonProperty("fixed_width_downsampled_width")]
        public string FixedWidthDownsampledWidth { get; set; }

        [JsonProperty("fixed_width_small_url")]
        public string FixedWidthSmallUrl { get; set; }

        [JsonProperty("fixed_width_small_still_url")]
        public string FixedWidthSmallStillUrl { get; set; }

        [JsonProperty("fixed_width_small_width")]
        public string FixedWidthSmallWidth { get; set; }

        [JsonProperty("image_original_url")]
        public string ImageOriginalUrl { get; set; }

        [JsonProperty("image_height")]
        public string ImageHeight { get; set; }

        [JsonProperty("image_frames")]
        public string ImageFrames { get; set; }

        [JsonProperty("image_mp4_url")]
        public string ImageMp4Url { get; set; }

        [JsonProperty("image_width")]
        public string ImageWidth { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class Meta
    {
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }
}