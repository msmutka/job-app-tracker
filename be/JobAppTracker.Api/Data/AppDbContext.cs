using Microsoft.EntityFrameworkCore;
using JobAppTracker.Api.Models;

namespace JobAppTracker.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
