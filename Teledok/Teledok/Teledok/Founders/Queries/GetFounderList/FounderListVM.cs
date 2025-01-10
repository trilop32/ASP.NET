namespace Teledok.Application.Founders.Queries.GetFounderList;

public class FounderListVM
{
    public required IList<FounderLookupDto> Founders { get; set; }
}