using MediatR;

namespace Teledok.Application.Founders.Commands.UpdateFounder;

public class UpdateFounderCommand : IRequest
{
    public required string INN { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string? Patronymic { get; set; }
}