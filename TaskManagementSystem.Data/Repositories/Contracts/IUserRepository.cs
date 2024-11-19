using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagementSystem.Data.Repositories.Contracts;

public interface IUserRepository
{
    Task Create(User? user);
    Task<User?> GetByNameAsync(string name);
    Task<bool> CommitAsync();
}
