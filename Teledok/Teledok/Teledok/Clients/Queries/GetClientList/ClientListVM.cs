namespace Teledok.Application.Clients.Queries.GetClientList;

public class ClientListVM
{
    public required IList<ClientLookupDto> Clients { get; set; }
}
