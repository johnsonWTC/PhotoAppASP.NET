﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Like> Likes { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Id { get; set; }
    }
}
