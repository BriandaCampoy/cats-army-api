namespace cats_army_api.Models;

public class CatStoreDatabaseSettings : ICatStoreDatabaseSettings{
  
    public string catsCollectionName{get; set; } = String.Empty;
    public string catTypeCollectionName{get; set; } = String.Empty;
    public string squadCollectionName{get; set; } = String.Empty;
    public string ConnectionString{get; set; } = String.Empty;
    public string DatabaseName{get;set;} = String.Empty;
}