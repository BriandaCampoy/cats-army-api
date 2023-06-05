using cats_army_api.Models;

namespace cats_army_api.services;

public interface ICatTypeService{
  List<CatType> Get();
  CatType Get(string catTypeId);
  CatType Create(CatType catType);
  void Update(string catTypeId, CatType catType);
  void Remove(string catTypeId);
}