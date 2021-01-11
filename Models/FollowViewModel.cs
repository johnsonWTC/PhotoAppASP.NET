﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class FollowViewModel
    {
        public List<Follow> Follows { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
