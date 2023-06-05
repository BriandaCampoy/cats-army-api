using cats_army_api.services;
using cats_army_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cats_army_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SquadController : ControllerBase{

  private readonly ISquadService squadService;
  public SquadController(ISquadService squadService){
    this.squadService = squadService;
  }

  [HttpGet]
  public ActionResult<List<Squad>> Get(){
    return squadService.Get();
  }

  [HttpGet("{id}")]
  public ActionResult<Squad> Get(string id){
    var squad = squadService.Get(id);
    if(squad==null){
      return NotFound($"Squad with Id={id} not found");
    }

    return squad;
  }

  [HttpPost]
  public ActionResult<Squad> Post([FromBody] Squad squad){
    squadService.Create(squad);
    return CreatedAtAction(nameof(Get), new {id=squad.squadId}, squad);
  }

  [HttpPut("{id}")]
  public ActionResult Put(string id, [FromBody] Squad squad){
    var existing = squadService.Get(id);
    if(existing == null){
      return NotFound($"Squad with id = {id} not found");
    }
    squadService.Update(id, squad);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public ActionResult Delete(string id){
 var existing = squadService.Get(id);
    if(existing == null){
      return NotFound($"Squad with id = {id} not found");
    }
    squadService.Remove(id);
    return Ok($"Squad with id = {id} deleted");
  }

}