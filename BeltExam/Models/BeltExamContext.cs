using Microsoft.EntityFrameworkCore;

namespace BeltExam.Models
{
    public class BeltExamContext : DbContext
    {
        public BeltExamContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}