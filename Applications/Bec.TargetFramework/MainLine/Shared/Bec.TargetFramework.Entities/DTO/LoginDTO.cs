using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using Bec.TargetFramework.Entities.Validators;
using FluentValidation;

namespace Bec.TargetFramework.Entities
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        
        public string ReturnUrl { get; set; }

    }

    
}