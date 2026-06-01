using Study.LabWork3.Storage;

namespace Study.LabWork3.Logic;

public class AppointmentService
{
    private readonly VetClinicDbContext _dbContext;

    public AppointmentService(VetClinicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Appointment> GetAll()
    {
        return _dbContext.Appointments.ToList();
    }

    public void Add(Appointment appointment)
    {
        _dbContext.Appointments.Add(appointment);
        _dbContext.SaveChanges();
    }

    public void Update(Appointment appointment)
    {
        var existing = _dbContext.Appointments.Find(appointment.Id);
        if (existing != null)
        {
            existing.Date = appointment.Date;
            existing.Diagnosis = appointment.Diagnosis;
            existing.Treatment = appointment.Treatment;
            existing.Cost = appointment.Cost;
            _dbContext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var appointment = _dbContext.Appointments.Find(id);
        if (appointment != null)
        {
            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
        }
    }
}
