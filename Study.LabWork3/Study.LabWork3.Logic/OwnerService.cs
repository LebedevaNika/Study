using Study.LabWork3.Storage;

namespace Study.LabWork3.Logic;

public class OwnerService
{
    private readonly VetClinicDbContext _dbContext;

    public OwnerService(VetClinicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Owner> GetAll()
    {
        return _dbContext.Owners.ToList();
    }

    public void Add(Owner owner)
    {
        _dbContext.Owners.Add(owner);
        _dbContext.SaveChanges();
    }

    public void Update(Owner owner)
    {
        var existing = _dbContext.Owners.Find(owner.Id);
        if (existing != null)
        {
            existing.FullName = owner.FullName;
            existing.Phone = owner.Phone;
            existing.Address = owner.Address;
            existing.Email = owner.Email;
            _dbContext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var owner = _dbContext.Owners.Find(id);
        if (owner != null)
        {
            _dbContext.Owners.Remove(owner);
            _dbContext.SaveChanges();
        }
    }
}
