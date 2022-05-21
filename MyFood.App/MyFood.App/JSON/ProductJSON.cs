using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyFood.App.JSON
{
    public struct ProductListJSON
    {
        [JsonProperty("ProductJSONs")]
        public List<Product> ProductJSONs { get; set; }
    }
    public struct Product
    {
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("eAN")]
        public string eAN { get; set; }
        [JsonProperty("anzahl")]
        public int anzahl { get; set; }
        [JsonProperty("ablaufdatum")]
        public DateTime ablaufdatum { get; set; }
    }
}
