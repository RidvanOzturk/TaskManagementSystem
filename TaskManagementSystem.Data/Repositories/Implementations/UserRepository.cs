using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Data.Repositories.Contracts;
using Task = System.Threading.Tasks.Task;

namespace TaskManagementSystem.Data.Repositories.Implementations;

public class UserRepository(TaskContext taskContext) : IUserRepository
{
    public async Task Create(User? user)
    {
       await taskContext.Users.AddAsync(user);
    }
    public async Task<User?> GetByNamePassAsync(string name, string password)
    {
        return await taskContext.Users
            .FirstAsync(x => x.Name == name);
    }
    public async Task<bool> CommitAsync()
    {
        var changes = await taskContext.SaveChangesAsync();
        return changes > 0;
    }
}
