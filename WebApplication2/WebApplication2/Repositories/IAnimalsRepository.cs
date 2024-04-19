using WebApplication2.Models;

namespace WebApplication2.Repositories;


public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal, int id);
    int DeleteAnimal(int idAnimal);

}