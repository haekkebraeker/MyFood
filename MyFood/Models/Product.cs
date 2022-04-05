using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MyFood.Models
{
  class Product
  {
    [BsonId]
        [JsonProperty("EAN")]
        public string EAN { get; private set; }
        [JsonProperty("MHD")]
        public DateTime MHD { get; private set; }
        [JsonProperty("ID")]
        public int ID { get; private set; }
        [JsonProperty("Name")]
        public string Name { get; private set; }

        public Product Serialize(BsonDocument doc)
    {
      Product prod = BsonSerializer.Deserialize<Product>(doc);
      return prod;
    }
    public List<Product> Serialize(List<BsonDocument> docs)
    {
      List<Product> actions = new List<Product>();
      foreach (var doc in docs)
      {
        Product prod = BsonSerializer.Deserialize<Product>(doc);
        actions.Add(prod);
      }
      return actions;
    }
  }
}
