using MediatR;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler(IRepositoryClient repositoryClient) : IRequestHandler<UpdateClientCommand>
{
    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken) =>
        await repositoryClient.UpdateAsync(request, cancellationToken);
}
