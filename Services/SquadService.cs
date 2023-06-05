using cats_army_api.Models;
using cats_army_apim.Models;
using MongoDB.Driver;

namespace cats_army_api.services;

public class SquadService:ISquadService
{
  private readonly IMongoCollection<Squad> _squad;

  public  SquadService(ICatStoreDatabaseSettings settings, IMongoClient mongoClient){
    var database = mongoClient.GetDatabase(settings.DatabaseName);
    _squad = database.GetCollection<Squad>(settings.squadCollectionName);
  }
  public Squad Create(Squad squad)
  {
    _squad.InsertOne(squad);
    return squad;
  }

  public List<Squad> Get()
  {
    return _squad.Find(squad => true).ToList();
  }

  public Squad Get(string catId)
  {
     return _squad.Find(squad => squad.squadId==catId).FirstOrDefault();
  }

  public void Remove(string squadId)
  {
    _squad.DeleteOne(squad => squad.squadId==squadId);
  }

  public void Update(string squadId, Squad squad)
  {
     _squad.ReplaceOne(squad => squad.squadId==squadId, squad);
  }
}