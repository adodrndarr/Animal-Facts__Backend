using AnimalFacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AnimalFacts.DataAccess.Database
{
    public static class ModelBuilderExtensions
    {
        public static void ConfiugreDog(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                        .HasKey(d => d.Id);

            modelBuilder.Entity<Dog>()
                        .Property(d => d.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Dog>()
                        .Property(d => d.Fact)
                        .HasMaxLength(500);

            modelBuilder.Entity<Dog>()
                        .Property(d => d.Source)
                        .HasMaxLength(500);
        }

        public static void ConfigureCat(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>()
                       .HasKey(c => c.Id);

            modelBuilder.Entity<Cat>()
                        .Property(c => c.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cat>()
                        .Property(c => c.Fact)
                        .HasMaxLength(500);

            modelBuilder.Entity<Cat>()
                        .Property(c => c.Source)
                        .HasMaxLength(500);
        }

        public static void ConfigureRabbit(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rabbit>()
                        .HasKey(r => r.Id);

            modelBuilder.Entity<Rabbit>()
                        .Property(r => r.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Rabbit>()
                        .Property(r => r.Fact)
                        .HasMaxLength(500);

            modelBuilder.Entity<Rabbit>()
                        .Property(r => r.Source)
                        .HasMaxLength(500);
        }
    }
}
