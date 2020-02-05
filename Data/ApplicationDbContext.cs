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
        public DbSet<KenkoApp.Models.CareAdministrator> CareAdministrator { get; set; }
        public DbSet<KenkoApp.Models.PCM> PCM { get; set; }
    }
}
