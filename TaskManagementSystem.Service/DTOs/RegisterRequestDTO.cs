using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Service.DTOs;

public class RegisterRequestDTO
{
    public required string username { get; set; }
    public required string password { get; set; }
    public required string email { get; set; }
}
