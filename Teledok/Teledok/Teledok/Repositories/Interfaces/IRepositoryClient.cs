using Teledok.Application.Clients.Commands.CreateClient;
using Teledok.Application.Clients.Commands.UpdateClient;
using Teledok.Domain;

namespace Teledok.Application.Repositories.Interfaces;

public interface IRepositoryClient
{
    Task AddAsync(CreateClientCommand createClientCommand, CancellationToken cancellationToken = default);
    Task DeleteAsync(string iNN, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateClientCommand request, CancellationToken cancellationToken = default);
    Task<List<Client>> GetRangeAsync(int countSkip, int countTake, CancellationToken cancellationToken = default);
    Task<Client> GetDetailsAsync(string iNN, CancellationToken cancellationToken = default);
    Task<bool> IsExistsAsync(string iNN, CancellationToken cancellationToken = default);
    Task<Client> GetByInnAsync(string iNN, CancellationToken cancellationToken = default);
}