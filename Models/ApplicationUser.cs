using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        public List<Photo> Photos { get; set; }
    }
}
