using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NcNews.Models;

namespace NcNews.Data
{

    public class NcNewsContext : DbContext
    {
        public NcNewsContext(DbContextOptions<NcNewsContext> options) : base(options)
        {

        }
        public DbSet<Articles> Article { get; set; }
        public DbSet<Comments> Comment { get; set; }
        public DbSet<Topics> Topic { get; set; }
        public DbSet<Users> User { get; set; }
    }
}

