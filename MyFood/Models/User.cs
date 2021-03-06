using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFood.Models
{
  public class User
  {
    [BsonId]
    public ObjectId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string FirebaseUid { get; set; }
    public string FamilyId { get; set; }
    public string FamilyRole { get; set; }
    public Family Family { get; set; }

    public static User ThisUser = new User();

    public User Serialize(BsonDocument doc)
    {
      User user = BsonSerializer.Deserialize<User>(doc);
      return user;
    }
    public List<User> Serialize(List<BsonDocument> docs)
    {
      List<User> actions = new List<User>();
      foreach (var doc in docs)
      {
        User user = BsonSerializer.Deserialize<User>(doc);
        actions.Add(user);
      }
      return actions;
    }
  }
}
