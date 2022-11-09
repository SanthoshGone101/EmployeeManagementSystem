using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Registration
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,MinLength(4)]
        public string Password { get; set; }
        [Required,Compare("Password")]
        public string CofirmPassword { get; set; }
    }
}
