namespace Study.LabWork3.Storage;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;  
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public string HealthStatus { get; set; } = "Здоров";
}
