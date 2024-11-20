using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Service.DTOs;

namespace TaskManagementSystem.Service.Extensions;

public static class MapperExtension
{
    public static User UserMap(this RegisterRequestDTO registerRequest)
    {
        return new User
        {
            Id = registerRequest.Id,
            Name = registerRequest.Name,
            PasswordHash = registerRequest.Password,
            Role = registerRequest.Role
        };
    }
}
