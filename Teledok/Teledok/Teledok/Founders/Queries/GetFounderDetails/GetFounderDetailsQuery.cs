using MediatR;

namespace Teledok.Application.Founders.Queries.GetFounderDetails;

public class GetFounderDetailsQuery : IRequest<FounderDetailsVM>
{
    public required string INN { get; set; }
}