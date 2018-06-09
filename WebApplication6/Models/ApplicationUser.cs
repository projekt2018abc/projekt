using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjektZespolowy.Models;
using ProjektZespolowy.Models.MyModels;

namespace WebApplication6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool UserConfirmed { get; set; }

        //public Podmiot podmiot { get; set; }

        public void createKlientFromApplicationUser() {
        new Klient { AppUserId = Id };

        }
    }
}
