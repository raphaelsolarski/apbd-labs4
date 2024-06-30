using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("/api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> animals = new()
    {
        new Animal { IdAnimal = 1, Name = "Animal1", Wage = 10.0, Color = "Brown" },
        new Animal { IdAnimal = 2, Name = "Animal2", Wage = 10.0, Color = "White" },
        new Animal { IdAnimal = 3, Name = "Animal3", Wage = 10.0, Color = "Red" },
    };

    private static readonly List<Visit> visits = new()
    {
        new Visit { VisitDate = DateTime.Now, AnimalId = 1, Description = "Some desc", Price = 10.0m },
        new Visit { VisitDate = DateTime.Now, AnimalId = 1, Description = "Some desc2", Price = 20.0m },
        new Visit { VisitDate = DateTime.Now, AnimalId = 1, Description = "Some desc2", Price = 12.0m },
        new Visit { VisitDate = DateTime.Now, AnimalId = 2, Description = "Some desc3", Price = 15.0m },
    };

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = animals.FirstOrDefault(animal => animal.IdAnimal == id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult PostAnimal(Animal animal)
    {
        animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animalRequest)
    {
        var animal = animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal == null) return NotFound($"Animal with id {id} does not exist");
        animalRequest.IdAnimal = id;
        animals.Remove(animal);
        animals.Add(animalRequest);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal != null)
        {
            animals.Remove(animal);
        }

        return NoContent();
    }

    [HttpGet("{animalId:int}/visits")]
    public IActionResult GetVisits(int animalId)
    {
        if (animals.FirstOrDefault(a => a.IdAnimal == animalId) == null)
        {
            return NotFound($"Animal with id {animalId} does not exist");
        }

        return Ok(visits.Where(v => v.AnimalId == animalId).ToList());
    }

    [HttpPost("{animalId:int}/visits")]
    public IActionResult PostVisit(int animalId, Visit visit)
    {
        if (animals.FirstOrDefault(a => a.IdAnimal == animalId) == null)
        {
            return NotFound($"Animal with id {animalId} does not exist");
        }

        visit.AnimalId = animalId;
        visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}