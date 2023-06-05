using cats_army_apim.Models;

namespace cats_army_api.services;

public interface ICatService{
  List<Cat> Get();
  Cat Get(string catId);
  Cat Create(Cat cat);
  void Update(string catId, Cat cat);
  void Remove(string catId);
}