using MarioSamisonExamenASP.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarioSamisonExamenASP.Data
{
    public interface IEntityContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<Cartype> CarTypes { get; set; }
        DbSet<CarOwner> CarOwners { get; set; }
    }

    public class EntityContext : DbContext, IEntityContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cartype>().HasKey(b => b.Id);

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Cartype> CarTypes { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
    }
}
