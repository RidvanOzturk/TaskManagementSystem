using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Repositories.Contracts;
using TaskManagementSystem.Service.Contacts;

namespace TaskManagementSystem.Service.Implementations;

public class AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository) : IAuthService
{
}
