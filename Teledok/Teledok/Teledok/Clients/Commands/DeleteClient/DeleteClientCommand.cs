using MediatR;

namespace Teledok.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommand : IRequest
{
    public required string INN { get; set; }
}