using cats_army_api.Models;
using cats_army_apim.Models;
using MongoDB.Driver;

namespace cats_army_api.services;

public class CatService : ICatService
{
  private readonly IMongoCollection<Cat> _cats;

  public  CatService(ICatStoreDatabaseSettings settings, IMongoClient mongoClient){
    var database = mongoClient.GetDatabase(settings.DatabaseName);
    _cats = database.GetCollection<Cat>(settings.catsCollectionName);
  }
  public Cat Create(Cat cat)
  {
    _cats.InsertOne(cat);
    return cat;
  }

  public List<Cat> Get()
  {
    return _cats.Find(cat => true).ToList();
  }

  public Cat Get(string catId)
  {
     return _cats.Find(cat => cat.catId==catId).FirstOrDefault();
  }

  public void Remove(string catId)
  {
    _cats.DeleteOne(cat => cat.catId==catId);
  }

  public void Update(string catId, Cat cat)
  {
     _cats.ReplaceOne(cat => cat.catId==catId, cat);
  }
}