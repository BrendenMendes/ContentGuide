using System;
using Newtonsoft.Json;

namespace ContentGuide.Singleton
{
    public class Login
    {
        public Login()
        {
        }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("preferences")]
        public string[] Preferences { get; set; }
    }
}
