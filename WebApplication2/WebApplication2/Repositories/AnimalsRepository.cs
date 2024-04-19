using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Repositories;

public class AnimalsRepository : IAnimalsRepository
{

    private IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        List<string> sortStyles = new List<string>();
        sortStyles.Add("Name");
        sortStyles.Add("Description");
        sortStyles.Add("Area");
        sortStyles.Add("Category");
        if (!sortStyles.Contains(orderBy))
        {
            orderBy = "Name";
        }
        string req = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY " + orderBy;
        cmd.CommandText = req;
        cmd.Parameters.AddWithValue("@orderBy", orderBy);
        var dr = cmd.ExecuteReader();
        List<Animal> animals = new List<Animal>();
        while (dr.Read())
        {
            Animal animal = new Animal()
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
            };
            animals.Add(animal);
        }

        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var counter = cmd.ExecuteNonQuery();
        return counter;
    }

    
    public int UpdateAnimal(Animal animal, int id)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        cmd.Parameters.AddWithValue("@IdAnimal", id);

        var counter = cmd.ExecuteNonQuery();
        return counter;
        
    }

    public int DeleteAnimal(int id)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", id);
        
        var counter = cmd.ExecuteNonQuery();
        return counter;
    }

}