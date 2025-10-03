using DisasterAlleviationFoundation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Incident> Incidents => Set<Incident>();
        public DbSet<Donation> Donations => Set<Donation>();
        public DbSet<VolunteerTask> VolunteerTasks => Set<VolunteerTask>();
        public DbSet<VolunteerSignup> VolunteerSignups => Set<VolunteerSignup>();
    }
}
