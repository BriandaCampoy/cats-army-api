using cats_army_api.Models;
using cats_army_apim.Models;
using MongoDB.Driver;

namespace cats_army_api.services;

public class CatTypeService:ICatTypeService
{
  private readonly IMongoCollection<CatType> _catType;

  public  CatTypeService(ICatStoreDatabaseSettings settings, IMongoClient mongoClient){
    var database = mongoClient.GetDatabase(settings.DatabaseName);
    _catType = database.GetCollection<CatType>(settings.catTypeCollectionName);
  }
  public CatType Create(CatType catType)
  {
    _catType.InsertOne(catType);
    return catType;
  }

  public List<CatType> Get()
  {
    return _catType.Find(catType => true).ToList();
  }

  public CatType Get(string catTypeId)
  {
     return _catType.Find(catType => catType.catTypeId==catTypeId).FirstOrDefault();
  }

  public void Remove(string catTypeId)
  {
    _catType.DeleteOne(catType => catType.catTypeId==catTypeId);
  }

  public void Update(string catTypeId, CatType catType)
  {
     _catType.ReplaceOne(catType => catType.catTypeId==catTypeId, catType);
  }
}