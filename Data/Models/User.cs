using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace Data.Models
{
    public class User : ClaimsPrincipal
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
