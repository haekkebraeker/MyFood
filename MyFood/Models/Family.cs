using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFood.Models
{
  class Family
  {
    [BsonId]
    public ObjectId Id { get; set; }
    public string FamilyName { get; set; }
  }
}
