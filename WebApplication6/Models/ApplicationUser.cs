using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjektZespolowy.Models;

namespace WebApplication6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool UserConfirmed { get; set; }

        public Osoba osoba { get; set; }

        public Osoba createOsobaFromApplicationUser() {
            osoba = new Osoba { AppUserId = Id };
            return osoba;
        }
    }
}
