using cats_army_api.services;
using cats_army_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cats_army_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatTypeController : ControllerBase{

  private readonly ICatTypeService catTypeService;
  public CatTypeController(ICatTypeService catTypeService){
    this.catTypeService = catTypeService;
  }

  [HttpGet]
  public ActionResult<List<CatType>> Get(){
    return catTypeService.Get();
  }

  [HttpGet("{id}")]
  public ActionResult<CatType> Get(string id){
    var catType = catTypeService.Get(id);
    if(catType==null){
      return NotFound($"CatType with Id={id} not found");
    }

    return catType;
  }

  [HttpPost]
  public ActionResult<CatType> Post([FromBody] CatType catType){
    catTypeService.Create(catType);
    return CreatedAtAction(nameof(Get), new {id=catType.catTypeId}, catType);
  }

  [HttpPut("{id}")]
  public ActionResult Put(string id, [FromBody] CatType catType){
    var existing = catTypeService.Get(id);
    if(existing == null){
      return NotFound($"CatType with id = {id} not found");
    }
    catTypeService.Update(id, catType);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public ActionResult Delete(string id){
 var existing = catTypeService.Get(id);
    if(existing == null){
      return NotFound($"CatType with id = {id} not found");
    }
    catTypeService.Remove(id);
    return Ok($"CatType with id = {id} deleted");
  }

}