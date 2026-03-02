using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Domain.Common;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

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
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrdersStatus { get; set; }
        public DbSet<Table> Tables {  get; set; }
        public DbSet<TableStatus> TablesStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region keys
            modelBuilder.Entity<Dish>().HasKey(a => a.Id);
            modelBuilder.Entity<DishCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<DishIngredient>().HasKey(a => new { a.DishId, a.IngredientId });
            modelBuilder.Entity<Ingredient>().HasKey(a => a.Id);
            modelBuilder.Entity<Order>().HasKey(a => a.Id);
            modelBuilder.Entity<DishOrder>().HasKey(a => new { a.DishId, a.OrderId });
            modelBuilder.Entity<OrderStatus>().HasKey(a => a.Id);
            modelBuilder.Entity<Table>().HasKey(a => a.Id);
            modelBuilder.Entity<TableStatus>().HasKey(a => a.Id);
            #endregion

            #region relationships

            modelBuilder.Entity<Dish>()
                .HasOne(a => a.DishCategory)
                .WithMany(a => a.Dishes)
                .HasForeignKey(a => a.DishCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.Table)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.OrderStatus)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.OrderStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Table>()
                .HasOne(a => a.TableStatus)
                .WithMany(a => a.Tables)
                .HasForeignKey(a => a.StatusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishOrder>()
                .HasOne(a => a.Dish)
                .WithMany(a => a.DishOrders)
                .HasForeignKey(a => a.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishOrder>()
                .HasOne(a => a.Order)
                .WithMany(a => a.DishOrders)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(a => a.Ingredient)
                .WithMany(a => a.DishIngredients)
                .HasForeignKey(a => a.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DishIngredient>()
               .HasOne(a => a.Dish)
               .WithMany(a => a.DishIngredients)
               .HasForeignKey(a => a.DishId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
