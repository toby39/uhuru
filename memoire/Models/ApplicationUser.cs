using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memoire.Models
{
    public class ApplicationUser : IdentityUser
    {
        public UserTypes UserType { get; set; }
    }
}
