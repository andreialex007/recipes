using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesSystem.Models
{
    public class AuthenticateRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
