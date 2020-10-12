using AnimalFacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AnimalFacts.DataAccess.Database
{
    public class AnimalsContext : DbContext
    {
        public AnimalsContext(DbContextOptions options) : base(options) { }


        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Rabbit> Rabbits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseIdentityColumns();

            modelBuilder.ConfigureCat();
            modelBuilder.ConfiugreDog();
            modelBuilder.ConfigureRabbit();
        }
    }
}