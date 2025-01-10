using MediatR;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler(IRepositoryClient repositoryClient) : IRequestHandler<CreateClientCommand>
{
    public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken) =>
        await repositoryClient.AddAsync(request, cancellationToken);
}