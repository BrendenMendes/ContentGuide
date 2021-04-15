using System;
using Newtonsoft.Json;

namespace ContentGuide.ViewModels
{
    public class Trending
    {
        public Trending()
        {

        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("poster_path")]
        public string Image { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
