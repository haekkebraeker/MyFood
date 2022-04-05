using MongoDB.Bson;
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
  }
}
