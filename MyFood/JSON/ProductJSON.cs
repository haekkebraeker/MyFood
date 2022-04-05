using Newtonsoft.Json;
using System;

namespace MyFood.JSON
{
    class ProductJSON
    {
        [JsonProperty("EAN")]
        public string EAN { get; private set; }
        [JsonProperty("MHD")]
        public DateTime MHD { get; private set; }
        [JsonProperty("ID")]
        public int ID { get; private set; }
        [JsonProperty("Name")]
        public string Name { get; private set; }

    }
}
