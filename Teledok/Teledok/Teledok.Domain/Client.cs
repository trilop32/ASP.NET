namespace Teledok.Domain;

public class Client
{
    public required string INN { get; set; }
    public required string TitleCompany { get; set; }
    public required TypeCompany TypeCompany { get; set; }
    public required DateTime DateAdd { get; set; }
    public DateTime? DateEdit { get; set; }
    public required List<Founder> Founders { get; set; }
}