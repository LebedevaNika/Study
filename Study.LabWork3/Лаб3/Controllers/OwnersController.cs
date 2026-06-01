using Microsoft.AspNetCore.Mvc;
using Study.LabWork3.Logic;
using Study.LabWork3.Storage;

namespace Study.LabWork3.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnersController : ControllerBase
{
    private readonly OwnerService _ownerService;

    public OwnersController(OwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public List<Owner> Get() => _ownerService.GetAll();


    [HttpPost]
    public IActionResult Post(Owner owner)
    {
        _ownerService.Add(owner);
        return CreatedAtAction(nameof(Get), new { id = owner.Id }, owner);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Owner owner)
    {
        if (id != owner.Id) return BadRequest();
        _ownerService.Update(owner);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _ownerService.Delete(id);
        return NoContent();
    }
}
