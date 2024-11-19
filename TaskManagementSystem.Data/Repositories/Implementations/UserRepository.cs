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
        taskContext.Users.AddAsync(user);
    }
}
