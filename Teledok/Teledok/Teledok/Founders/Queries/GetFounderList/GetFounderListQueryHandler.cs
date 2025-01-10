using MediatR;
using AutoMapper;
using Teledok.Application.Repositories.Interfaces;
using Teledok.Domain;

namespace Teledok.Application.Founders.Queries.GetFounderList;

public class GetFounderListQueryHandler(IMapper mapper, IRepositoryFounder repositoryFounder) : IRequestHandler<GetFounderListQuery, FounderListVM>
{
    public async Task<FounderListVM> Handle(GetFounderListQuery request, CancellationToken cancellationToken)
    {
        var founders = await repositoryFounder.GetRangeAsync(request.CountSkip, request.CountTake, cancellationToken);
        var foundersLookupDto = mapper.Map<List<Founder>, List<FounderLookupDto>>(founders);

        return new FounderListVM
        {
            Founders = foundersLookupDto
        };
    }
}