using System;
using Newtonsoft.Json;

namespace ContentGuide.ViewModels
{
    public class TVshows
    {
        public TVshows()
        {
        }

        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("poster_path")]
        public string Image { get; set; }
    }
}
