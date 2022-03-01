using Microsoft.EntityFrameworkCore;

namespace RestApi.Entity.Core6.Modelos
{
    public class Db_Context : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

    
        public Db_Context(DbContextOptions<Db_Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
