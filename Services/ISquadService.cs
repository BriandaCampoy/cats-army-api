using cats_army_api.Models;

namespace cats_army_api.services;

public interface ISquadService{
  List<Squad> Get();
  Squad Get(string squadId);
  Squad Create(Squad squad);
  void Update(string squadId, Squad squad);
  void Remove(string squadId);
}