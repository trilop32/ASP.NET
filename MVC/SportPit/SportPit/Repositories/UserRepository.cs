using Microsoft.EntityFrameworkCore;
using SportPit.Data;
using SportPit.Models;
using SportPit.Repositories.Interfaces;

namespace SportPit.Repositories;

public class UserRepository(ApplicationContext context) : IUserRepository
{
    public Task<User> GetUserByIdAsync(string id) =>
        context.Users.SingleAsync(user => user.Id == id);
}