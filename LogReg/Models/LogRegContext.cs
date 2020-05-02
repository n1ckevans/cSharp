using Microsoft.EntityFrameworkCore;

namespace LogReg.Models
{
    public class LogRegContext : DbContext
    {
        public LogRegContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}