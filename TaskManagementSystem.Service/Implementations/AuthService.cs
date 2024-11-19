using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Repositories.Contracts;
using TaskManagementSystem.Service.Contacts;
using TaskManagementSystem.Service.DTOs;

namespace TaskManagementSystem.Service.Implementations;

public class AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository) : IAuthService
{
    public async Task<bool> RegisterAsync(RegisterRequestDTO requestDTO)
    {
        var user = await userRepository.GetByNameAsync(requestDTO.username, requestDTO.email);
        if (user != null)
        {
            return false;
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(requestDTO.password);
        var newUser = requestDTO.UserMap();
        await userRepository.Create(newUser);
        var result = await userRepository.CommitAsync();

        return result != null;
    }

    public async Task<List<Claim>> LoginAsync(string username, string password)
    {
        var user = await userRepository.GetByNameandEmailAsync(username, password);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return new List<Claim>();
        }


        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("UserId", user.Id.ToString())
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
        };

        await httpContextAccessor.HttpContext.SignInAsync(
            "Cookies",
            new ClaimsPrincipal(claimsIdentity),
            authProperties
        );
        return claims;



    }

    public async Task LogoutAsync()
    {
        await httpContextAccessor.HttpContext.SignOutAsync("Cookies");
    }
}
