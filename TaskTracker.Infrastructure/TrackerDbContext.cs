using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Models;

namespace TaskTracker.Infrastructure
{
    public class TrackerDbContext: DbContext
    {
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options):base(options)
        {
        }
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "MyDb.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}