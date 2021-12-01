using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Emprender.Models;

namespace Emprender.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Emprender.Models.ProvincesClass> ProvincesClass { get; set; }
        public DbSet<Emprender.Models.User> User { get; set; }
    }
}
