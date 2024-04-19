using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    Animal? GetAnimal(int idAniaml);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}