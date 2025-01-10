using MediatR;
using Teledok.Application.Repositories.Interfaces;

namespace Teledok.Application.Founders.Commands.UpdateFounder;

public class UpdateFounderCommandHandler(IRepositoryFounder repositoryFounder) : IRequestHandler<UpdateFounderCommand>
{
    public async Task Handle(UpdateFounderCommand request, CancellationToken cancellationToken) =>
        await repositoryFounder.UpdateAsync(request, cancellationToken);
}