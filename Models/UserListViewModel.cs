using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class FollowViewModel
    {
        public List<IdentityUser> Users { get; set; }
    }
}
