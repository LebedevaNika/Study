namespace Study.LabWork3.Storage;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string Treatment { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}
