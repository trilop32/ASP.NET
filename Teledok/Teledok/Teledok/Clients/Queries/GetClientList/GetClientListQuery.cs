using MediatR;

namespace Teledok.Application.Clients.Queries.GetClientList;

public class GetClientListQuery : IRequest<ClientListVM>
{
    public int CountSkip { get; set; }
    public int CountTake { get; set; }
}