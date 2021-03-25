using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ispit> Ispiti { get; set; }
        public DbSet<Polaganje> Polaganja { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
    }
}
