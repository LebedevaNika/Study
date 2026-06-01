using Study.LabWork3.Storage;

namespace Study.LabWork3.Logic;

public class PetService
{
    private readonly VetClinicDbContext _dbContext;

    public PetService(VetClinicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Pet> GetAll()
    {
        return _dbContext.Pets.ToList();
    }

    public void Add(Pet pet)
    {
        _dbContext.Pets.Add(pet);
        _dbContext.SaveChanges();
    }

    public void Update(Pet pet)
    {
        var existing = _dbContext.Pets.Find(pet.Id);
        if (existing != null)
        {
            existing.Name = pet.Name;
            existing.Species = pet.Species;
            existing.Breed = pet.Breed;
            existing.Age = pet.Age;
            existing.HealthStatus = pet.HealthStatus;
            _dbContext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var pet = _dbContext.Pets.Find(id);
        if (pet != null)
        {
            _dbContext.Pets.Remove(pet);
            _dbContext.SaveChanges();
        }
    }
}
