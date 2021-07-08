using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker
{
    public class TrackerDbContext: DbContext
    {
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // todo: add connection string.
            // also check apppseetings json
            optionsBuilder.UseSqlite("~/Tracker.db");
        }
    }
}