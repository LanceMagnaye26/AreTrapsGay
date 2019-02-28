using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TrapContext : DbContext
    {
        public TrapContext(DbContextOptions<TrapContext> options)
            : base(options)
        {
        }

        public DbSet<TrapItem> TrapItems { get; set; }
    }
}