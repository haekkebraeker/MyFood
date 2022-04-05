using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFood.Models
{
  class Product
  {
    [BsonId]
    public ObjectId Id { get; set; }
    // European Article No - einzigartige Artikelnr (Barcode)
    public string EAN { get; set; }
    // Mindesthaltbarkeitdatum
    public string MHD { get; set; }

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
