﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoApp.Models;

namespace PhotoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }  
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Follow> Follows { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Post> Posts { get; set; }


    }
}
