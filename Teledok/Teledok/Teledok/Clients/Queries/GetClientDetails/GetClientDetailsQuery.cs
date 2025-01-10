using MediatR;

namespace Teledok.Application.Clients.Queries.GetClientDetails;

public class GetClientDetailsQuery : IRequest<ClientDetailsVM>
{
    public required string INN { get; set; }
}