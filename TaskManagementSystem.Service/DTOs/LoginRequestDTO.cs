﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Service.DTOs;

public class LoginRequestDTO
{
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }

}