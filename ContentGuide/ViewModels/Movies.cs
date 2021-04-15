using System;
using Newtonsoft.Json;

namespace ContentGuide.ViewModels
{
    public class Movies
    {
        public Movies()
        {
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("poster_path")]
        public string Image { get; set; }
    }
}
