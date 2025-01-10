using MediatR;

namespace Teledok.Application.Founders.Commands.CreateFounder;

public class CreateFounderCommand : IRequest
{
    public required string INN { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string? Patronymic { get; set; }
}