using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controller;
[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetStudents(string orderBy)
    {
        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }
    

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        int counter = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(Animal animal, int id)
    {
        
        int counter = _animalsService.UpdateAnimal(animal, id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        int conuter = _animalsService.DeleteAnimal(id);
        return NoContent();
    }
    
}