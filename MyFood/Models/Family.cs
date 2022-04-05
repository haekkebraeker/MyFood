using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFood.Models
{
  public class Family
  {
    [BsonId]
    public ObjectId Id { get; set; }
    public string FamilyName { get; set; }

    public Family Serialize(BsonDocument doc)
    {
      Family fam = BsonSerializer.Deserialize<Family>(doc);
      return fam;
    }
    public List<Family> Serialize(List<BsonDocument> docs)
    {
      List<Family> actions = new List<Family>();
      foreach (var doc in docs)
      {
        Family fam = BsonSerializer.Deserialize<Family>(doc);
        actions.Add(fam);
      }
      return actions;
    }
  }
}
