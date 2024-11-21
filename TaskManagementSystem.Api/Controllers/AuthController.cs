﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Service.Implementations;
using TaskManagementSystem.Service.Contacts;

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
    public async Task<IActionResult> Login(string username, string password)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        //var claims = await authService.LoginAsync(username, password);
        //if (claims.Count > 0)
        //{
        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        //    return RedirectToAction("Index", "Home");
        //}
        //else
        //{
        //    ModelState.AddModelError("", "Invalid username or password");
        //    return View();
        //}
        return View();
    }
}
