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

        public DateTime time { get; set; }
    }
}
