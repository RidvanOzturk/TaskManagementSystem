using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Service.Implementations;
using TaskManagementSystem.Service.Contacts;
using TaskManagementSystem.Service.DTOs;

namespace TaskManagementSystem.Api.Controllers;

[Authorize]
public class AuthController(IAuthService authService) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid model");
        }

        var token = await authService.LoginAsync(model);

        if (token != null)
        {
            return Ok(new { Token = token });
        }
        else
        {
            return Unauthorized("Invalid username or password");
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok(new { Message = "Successfully logged out. Please clear your token on the client side." });
    }
}
