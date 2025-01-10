using Microsoft.EntityFrameworkCore;
using Teledok.Application.Common.Exceptions;
using Teledok.Application.Founders.Commands.UpdateFounder;
using Teledok.Application.Repositories.Interfaces;
using Teledok.Domain;

namespace Teledok.Persistence.Repositories;

public class RepositoryFounder(TeledokDbContext teledokDbContext) : IRepositoryFounder
{
    public async Task AddAsync(Founder founder, CancellationToken cancellationToken)
    {
        await teledokDbContext.AddAsync(founder, cancellationToken);
        await teledokDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(string iNN, CancellationToken cancellationToken)
    {
        var founder =
            await teledokDbContext.Founders
            .SingleOrDefaultAsync(founder => founder.INN == iNN, cancellationToken)
             ?? throw new NotFoundException(nameof(Founder), iNN);

        teledokDbContext.Remove(founder);
        await teledokDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Founder>> GetRangeAsync(int countSkip, int countTake, CancellationToken cancellationToken = default) => 
        await teledokDbContext.Founders
            .Skip(countSkip)
            .Take(countTake)
            .ToListAsync(cancellationToken);

    public async Task<Founder> GetDetailsAsync(string iNN, CancellationToken cancellationToken = default) =>
        await teledokDbContext.Founders
            .Include(founder => founder.Clients)
            .SingleOrDefaultAsync(founder => founder.INN == iNN, cancellationToken)
             ?? throw new NotFoundException(nameof(Founder), iNN);

    public async Task UpdateAsync(UpdateFounderCommand request, CancellationToken cancellationToken)
    {
        var founder = await teledokDbContext.Founders
            .SingleOrDefaultAsync(x => x.INN == request.INN, cancellationToken)
            ?? throw new NotFoundException(nameof(Founder), request.INN);

        try
        {
            founder.Name = request.Name;
            founder.Surname = request.Surname;
            founder.Patronymic = request.Patronymic;
            founder.EditDate = DateTime.UtcNow;

            await teledokDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            var isFounderExistsAsync = await IsExistsAsync(founder.INN, cancellationToken);

            if (isFounderExistsAsync)
            {
                throw new NotFoundException(nameof(Founder), request.INN);
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<List<Founder>> GetFoundersByListInnAsync(List<string> iNNFounders, CancellationToken cancellationToken)
    {
        var founders = await teledokDbContext.Founders
            .Where(founder => iNNFounders.Contains(founder.INN))
            .ToListAsync(cancellationToken);

        if (founders.Count != iNNFounders.Count)
        {
            throw new NotFoundException($"A certain number of Founders were not found, type: {nameof(List<Founder>)}", iNNFounders);
        }

        return founders;
    }

    public async Task<bool> IsExistsAsync(string iNN, CancellationToken cancellationToken) =>
        await teledokDbContext.Founders.AnyAsync(founder => founder.INN == iNN, cancellationToken);
}