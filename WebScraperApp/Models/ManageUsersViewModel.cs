using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WebScraperApp.Models;

namespace WebScraperApp.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set;}
    }
}