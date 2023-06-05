namespace cats_army_api.Models{

  public interface ICatStoreDatabaseSettings{
    string catsCollectionName{get; set; }
    string catTypeCollectionName{get; set; }
    string squadCollectionName{get; set; }
    string ConnectionString{get; set; }
    string DatabaseName{get;set;}
  }
}