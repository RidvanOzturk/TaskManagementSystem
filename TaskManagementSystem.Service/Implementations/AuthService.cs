using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Repositories.Contracts;
using TaskManagementSystem.Service.Contacts;
using TaskManagementSystem.Service.DTOs;
using TaskManagementSystem.Service.Extensions;

namespace TaskManagementSystem.Service.Implementations;

public class AuthService(IHttpContextAccessor _httpContextAccessor, IUserRepository _userRepository, IConfiguration _configuration) : IAuthService
{
    public async Task<bool> RegisterAsync(RegisterRequestDTO requestDTO)
    {
        var user = await _userRepository.GetByNamePassAsync(requestDTO.Name, requestDTO.Password);
        if (user != null)
        {
            return false;  
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(requestDTO.Password);
        var newUser = requestDTO.UserMap();
        await _userRepository.Create(newUser);
        var result = await _userRepository.CommitAsync();

        return result != null;
    }
    public async Task<string> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        var user = await _userRepository.GetByNamePassAsync(loginRequestDTO.Name, loginRequestDTO.Password);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequestDTO.Password, user.PasswordHash))
        {
            return null;  
        }
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("UserId", user.Id.ToString())
        };
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddHours(1), 
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
