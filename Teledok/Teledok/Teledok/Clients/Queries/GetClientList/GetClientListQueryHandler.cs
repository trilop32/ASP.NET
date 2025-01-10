using MediatR;
using AutoMapper;
using Teledok.Domain;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Clients.Queries.GetClientList;

public class GetClientListQueryHandler(IMapper mapper, IRepositoryClient repositoryClient) : IRequestHandler<GetClientListQuery, ClientListVM>
{
    public async Task<ClientListVM> Handle(GetClientListQuery request, CancellationToken cancellationToken)
    {
        var clients = await repositoryClient.GetRangeAsync(request.CountSkip, request.CountTake, cancellationToken);
        var clientsLookupDto = mapper.Map<List<Client>, List<ClientLookupDto>>(clients);

        return new ClientListVM
        {
            Clients = clientsLookupDto
        };
    }
}