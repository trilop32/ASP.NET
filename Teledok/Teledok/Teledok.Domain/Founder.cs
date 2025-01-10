namespace Teledok.Domain;

public class Founder
{
    public required string INN { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string? Patronymic { get; set; }
    public required DateTime AddDate { get; set; }
    public DateTime? EditDate { get; set; }
    public List<Client>? Clients { get; set; }
}