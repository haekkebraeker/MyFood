using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFood.Models
{
  class User
  {
    [BsonId]
    public ObjectId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string FirebaseUid { get; set; }
    public string FamilyId { get; set; }
    public string FamilyRole { get; set; }
  }
}
