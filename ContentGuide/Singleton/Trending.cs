﻿using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ContentGuide.ViewModels
{
    public class Trending
    {
        public Command TapCommand { get; set; }
        public EventHandler TapClickEventHandler;

        public Trending()
        {
            TapCommand = new Command(() => OnItemClicked());
        }

        public void OnItemClicked()
        {
            TapClickEventHandler?.Invoke(this, EventArgs.Empty);
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("poster_path")]
        public string Image { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
