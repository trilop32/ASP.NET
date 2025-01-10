using MediatR;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Founders.Commands.DeleteFounder;

public class DeleteFounderCommandHandler(IRepositoryFounder repositoryFounder) : IRequestHandler<DeleteFounderCommand>
{
    public async Task Handle(DeleteFounderCommand request, CancellationToken cancellationToken) =>
        await repositoryFounder.DeleteAsync(request.INN, cancellationToken);
}