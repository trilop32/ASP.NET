using MediatR;

namespace Teledok.Application.Founders.Queries.GetFounderList;

public class GetFounderListQuery : IRequest<FounderListVM>
{
    public int CountSkip { get; set; }
    public int CountTake { get; set; }
}