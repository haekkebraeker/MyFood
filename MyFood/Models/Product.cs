using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyFood.Models
{
    public struct ProductList
    {
        [JsonProperty("Produkte")]
        public List<Product> Produkte { get; set; }
    }
    public struct Product
    {
        [JsonProperty("EAN")]
        public string EAN { get; set; }
        [JsonProperty("MHD")]
        public DateTime MHD { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
    // Usage (read):
    //string json = File.ReadAllText("./JSON/Product.json");
    //var product = JsonConvert.DeserializeObject<ProductList>(json);

    // Usage (write)
    // #1. Lesen + bearbeiten
    // File.WriteAllText("./JSON/Product.json", JsonConvert.SerializeObject(ProductList, Formatting.Indented));
}
