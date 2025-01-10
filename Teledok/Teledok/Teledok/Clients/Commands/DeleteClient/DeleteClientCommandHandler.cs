using MediatR;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommandHandler(IRepositoryClient repositoryClient) : IRequestHandler<DeleteClientCommand>
{
    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken) =>
        await repositoryClient.DeleteAsync(request.INN, cancellationToken);
}