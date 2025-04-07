using CinemaWatcher.Entities.EntitiesModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaWatcher.Entities.DataAccess
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        { }

        public DbSet<Movies> Movies => Set<Movies>();
        public DbSet<Series> Series => Set<Series>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>(builder =>
            {
                builder.HasKey(p => p.MovieId);
                builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Category).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Duration);
                builder.Property(p => p.DateOfPublish);
            });

            modelBuilder.Entity<Series>(builder =>
            {
                builder.HasKey(p => p.SerieId);
                builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Category).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Duration);
                builder.Property(p => p.DateOfPublish);
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(p => p.UserId);
                builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
                builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
                builder.Property(p => p.Email).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Password).IsRequired().HasMaxLength(10);
                builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
                builder.Property(p => p.Age);
            });
        }
    }
}
