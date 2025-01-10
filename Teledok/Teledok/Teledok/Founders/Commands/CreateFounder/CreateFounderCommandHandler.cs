using MediatR;
using Teledok.Application.Repositories.Interfaces;
using Teledok.Domain;

namespace Teledok.Application.Founders.Commands.CreateFounder;

public class CreateFounderCommandHandler(IRepositoryFounder repositoryFounder) : IRequestHandler<CreateFounderCommand>
{
    public async Task Handle(CreateFounderCommand request, CancellationToken cancellationToken)
    {
        var founder = new Founder
        {
            INN = request.INN,
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            AddDate = DateTime.UtcNow,
        };

        await repositoryFounder.AddAsync(founder, cancellationToken);
    }
}