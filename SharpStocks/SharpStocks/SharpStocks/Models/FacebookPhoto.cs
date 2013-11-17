﻿using Newtonsoft.Json;

namespace SharpStocks.Models
{
    public class FacebookPhoto
    {
        [JsonProperty("picture")] // This renames the property to picture.
        public string ThumbnailUrl { get; set; }

        public string Link { get; set; }
    }
}