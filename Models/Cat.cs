using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace cats_army_apim.Models;

public class Cat{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string catId{get;set;} = string.Empty;

  [BsonElement("catTypeId")]
  public string catTypeId{get;set;}

  [BsonElement("squadId")]

  public string squadId{get;set;}

  [BsonElement("name")]
  public string name{get;set;}

  [BsonElement("description")]
  public string description{get;set;}

  [BsonElement("defense")]
  public int defense{get;set;}

  [BsonElement("attack")]
  public int attack{get;set;}

  // [BsonIgnore]
  // public virtual catType catType {get;set;}

}
