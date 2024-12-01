using SportPit.Models;

namespace SportPit.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(string id);
}