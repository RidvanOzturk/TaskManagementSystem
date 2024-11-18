using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Api.Controllers;

public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
}
