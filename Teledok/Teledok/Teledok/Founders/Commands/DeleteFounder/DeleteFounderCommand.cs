using MediatR;

namespace Teledok.Application.Founders.Commands.DeleteFounder;

public class DeleteFounderCommand : IRequest
{
    public required string INN { get; set; }
}
