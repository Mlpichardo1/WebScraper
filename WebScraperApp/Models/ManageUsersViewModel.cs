using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WebScraperApp.Models;

namespace WebScraperApp.Models
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Everyone { get; set;}
    }
}