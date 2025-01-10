using MediatR;
using AutoMapper;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Founders.Queries.GetFounderDetails;

public class GetFounderDetailsQueryHandler(IMapper mapper, IRepositoryFounder repositoryFounder) : IRequestHandler<GetFounderDetailsQuery, FounderDetailsVM>
{
    public async Task<FounderDetailsVM> Handle(GetFounderDetailsQuery request, CancellationToken cancellationToken)
    {
        var founder = await repositoryFounder.GetDetailsAsync(request.INN, cancellationToken);

        return mapper.Map<FounderDetailsVM>(founder);
    }
}