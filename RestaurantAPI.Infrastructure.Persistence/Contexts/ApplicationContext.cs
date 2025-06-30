using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Domain.Common;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "Application User";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "ApplicationUser";
                        entry.Property(x => x.Created).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId);
            modelBuilder.Entity<Order>()
                .Property(o => o.SubTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Dish>()
                .Property(o => o.Price)
                .HasPrecision(10, 2);
            
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);

        }

    }
}
