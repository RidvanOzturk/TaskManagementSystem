using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Service.DTOs;

namespace TaskManagementSystem.Service.Contacts;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequestDTO requestDTO);
    Task<List<Claim>> LoginAsync(LoginRequestDTO loginRequestDTO);
}
