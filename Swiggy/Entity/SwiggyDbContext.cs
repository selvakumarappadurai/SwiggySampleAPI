using Microsoft.EntityFrameworkCore;

namespace Swiggy.Entity
{
    public class SwiggyDbContext : DbContext
    {
        //public SwiggyDbContext(DbContextOptions<SwiggyDbContext> options)
        //  : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            //.UseInMemoryDatabase("Swiggy");
            // .UseLoggerFactory(ConsoleLoggerFactory)
            .UseSqlServer("Data Source = LAPTOP-S1O8TQHL\\SQLEXPRESS;Initial Catalog = Swiggy;User Id=sa;Password=welcome123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Restaurant>(x =>
            {
                x.ToTable("Restaurants").HasKey(x => x.Id);
                x.HasIndex(y => y.Name).IsUnique();
                x.HasMany(r => r.FoodItems).WithOne()
                .Metadata.PrincipalToDependent
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            //var navigation = modelBuilder.Metadata.FindNavigation(nameof(Order.OrderItems));

            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<FoodItem>(x =>
            {
                x.ToTable("FoodItems").HasKey(x => x.Id);
            });

            modelBuilder.Entity<Customer>(x =>
            {
                x.ToTable("Customers")
                .HasKey(x => x.Id);
            });
            modelBuilder.Entity<Customer>().HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<Order>(x =>
            {
                x.ToTable("Orders").HasKey(x => x.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
