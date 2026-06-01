using Microsoft.AspNetCore.Mvc;
using Study.LabWork3.Logic;
using Study.LabWork3.Storage;

namespace Study.LabWork3.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    private readonly PetService _petService;

    public PetsController(PetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public List<Pet> Get() => _petService.GetAll();


    [HttpPost]
    public IActionResult Post(Pet pet)
    {
        _petService.Add(pet);
        return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Pet pet)
    {
        if (id != pet.Id) return BadRequest();
        _petService.Update(pet);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _petService.Delete(id);
        return NoContent();
    }
}
