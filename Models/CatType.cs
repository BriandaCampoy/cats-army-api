using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cats_army_api.Models;
public class CatType{

[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
  public string catTypeId {get; set;}

[BsonElement("catTypeName")]
  public string catTypeName {get; set;}
  
}