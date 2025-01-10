using MediatR;
using AutoMapper;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Clients.Queries.GetClientDetails;

public class GetClientDetailsQueryHandler(IMapper mapper, IRepositoryClient repositoryClient) : IRequestHandler<GetClientDetailsQuery, ClientDetailsVM>
{
    public async Task<ClientDetailsVM> Handle(GetClientDetailsQuery request, CancellationToken cancellationToken)
    {
        var client = await repositoryClient.GetDetailsAsync(request.INN, cancellationToken);

        return mapper.Map<ClientDetailsVM>(client);
    }
}