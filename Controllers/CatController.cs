using cats_army_api.services;
using cats_army_apim.Models;
using Microsoft.AspNetCore.Mvc;

namespace cats_army_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class catsController : ControllerBase{

  private readonly ICatService catService;
  public catsController(ICatService catService){
    this.catService = catService;
  }

  [HttpGet]
  public ActionResult<List<Cat>> Get(){
    return catService.Get();
  }

  [HttpGet("{id}")]
  public ActionResult<Cat> Get(string id){
    var cat = catService.Get(id);
    if(cat==null){
      return NotFound($"Cat with Id={id} not found");
    }

    return cat;
  }

  [HttpPost]
  public ActionResult<Cat> Post([FromBody] Cat cat){
    catService.Create(cat);
    return CreatedAtAction(nameof(Get), new {id=cat.catId}, cat);
  }

  [HttpPut("{id}")]
  public ActionResult Put(string id, [FromBody] Cat cat){
    var existing = catService.Get(id);
    if(existing == null){
      return NotFound($"Cat with id = {id} not found");
    }
    catService.Update(id, cat);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public ActionResult Delete(string id){
 var existing = catService.Get(id);
    if(existing == null){
      return NotFound($"Cat with id = {id} not found");
    }
    catService.Remove(id);
    return Ok($"Cat with id = {id} deleted");
  }

}