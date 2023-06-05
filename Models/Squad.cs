using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cats_army_api.Models;

public class Squad{

[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
  public string squadId{get; set; }
[BsonElement("nameSquad")]
  public string nameSquad{get; set; }

[BsonElement("color")]
  public string color {get;set;}
}