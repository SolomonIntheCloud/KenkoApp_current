using System;
using System.Collections.Generic;
using System.Text;
using KenkoApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KenkoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<CustomIdentityUser> CustomIdentityUsers { get; set; }
        public DbSet<CareAdministrator> CareAdministrator { get; set; }
        public DbSet<PCM> PCM { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
    }
}
