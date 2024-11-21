using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Repositories.Contracts;
using TaskManagementSystem.Service.Contacts;
using TaskManagementSystem.Service.DTOs;
using TaskManagementSystem.Service.Extensions;

namespace TaskManagementSystem.Service.Implementations;

public class AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IConfiguration configuration) : IAuthService
{
    public async Task<bool> RegisterAsync(RegisterRequestDTO requestDTO)
    {
        var user = await userRepository.GetByNamePassAsync(requestDTO.Name,requestDTO.Password);
        if (user != null)
        {
            return false;
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(requestDTO.Password);
        var newUser = requestDTO.UserMap();
        await userRepository.Create(newUser);
        var result = await userRepository.CommitAsync();

        return result != null;
    }

    public async Task<List<Claim>> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        var user = await userRepository.GetByNamePassAsync(loginRequestDTO.Name, loginRequestDTO.Password);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequestDTO.Password, user.PasswordHash))
        {
            return new List<Claim>();
        }


        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("UserId", user.Id.ToString())
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
        var authProperties = new AuthenticationProperties();
        await httpContextAccessor.HttpContext.
    }
}
