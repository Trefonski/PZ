using PZ.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PZ
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        private DbContextOptions<AppDbContext> options;
        private IHttpContextAccessor _httpContextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this.options = options;

            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Addresses
                builder.Entity<Addresses>().HasKey(t => new {t.ID_Address, t.ID_Client});
                builder.Entity<Addresses>().HasOne(t => t.Clients)
                .WithMany(d => d.Addresses)
                .HasForeignKey(t => t.ID_Client)
                .HasConstraintName("FK_Addresses_Clients")
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Clients
                builder.Entity<Clients>().HasKey(t => t.ID_Client);
                builder.Entity<Clients>().HasMany(t => t.Addresses)
                .WithOne(d => d.Clients)
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Clients>().HasMany(t => t.Reviews)
                .WithOne(d => d.Clients)
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Clients>().HasMany(t => t.Orders)
                .WithOne(d => d.Clients)
                .OnDelete(DeleteBehavior.Restrict);                
            #endregion

            #region Orders
                builder.Entity<Orders>().HasKey(t => t.ID_Order);
                builder.Entity<Orders>().HasOne(t => t.Clients)
                .WithMany(d => d.Orders)
                .HasForeignKey(t => t.ID_Client)
                .HasConstraintName("FK_Orders_Clients")
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Orders>().HasMany(t => t.OrderDates)
                .WithOne(d => d.Orders)
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Orders>().HasMany(t => t.OrderQuantities)
                .WithOne(d => d.Orders)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region OrderDates
                builder.Entity<OrderDates>().HasKey(t => t.ID_Date);
                builder.Entity<OrderDates>().HasOne(t => t.Status)
                .WithMany(d => d.OrderDates)
                .HasForeignKey(t => t.ID_Status)
                .HasConstraintName("FK_OrderDates_Status")
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<OrderDates>().HasOne(t => t.Orders)
                .WithMany(d => d.OrderDates)
                .HasForeignKey(t => t.ID_Order)
                .HasConstraintName("FK_OrderDates_Orders")
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region OrderQuantities
                builder.Entity<OrderQuantities>().HasKey(t => new {t.ID_Order, t.ID_Item});
                builder.Entity<OrderQuantities>().HasOne(t => t.Orders)
                .WithMany(d => d.OrderQuantities)
                .HasForeignKey(t => t.ID_Order)
                .HasConstraintName("FK_OrderQuantities_Orders")
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<OrderQuantities>().HasOne(t => t.Items)
                .WithMany(d => d.OrderQuantities)
                .HasForeignKey(t => t.ID_Item)
                .HasConstraintName("FK_OrderQuantities_Items")
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Items
                builder.Entity<Items>().HasKey(t => t.ID_Item);
                builder.Entity<Items>().HasMany(t => t.OrderQuantities)
                .WithOne(d => d.Items)
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Items>().HasMany(t => t.Reviews)
                .WithOne(d => d.Items)
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Items>().HasMany(t => t.Pictures)
                .WithOne(d => d.Items)
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Items>().HasOne<Brands>(t => t.Brands) //https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluent-api-in-ef-core.aspx
                .WithOne(d => d.Items)
                .HasForeignKey<Brands>(t => t.ID_Brand)
                .HasConstraintName("FK_Items_Brands")
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Status
                builder.Entity<Status>().HasKey(t => t.ID_Status);
                builder.Entity<Status>().HasMany(t => t.OrderDates)
                .WithOne(d => d.Status)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Reviews
                builder.Entity<Reviews>().HasKey(t => new {t.ID_Client, t.ID_Item});
                builder.Entity<Reviews>().HasOne(t => t.Clients)
                .WithMany(d => d.Reviews)
                .HasForeignKey(t => t.ID_Client)
                .HasConstraintName("FK_Reviews_Clients")
                .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Reviews>().HasOne(t => t.Items)
                .WithMany(d => d.Reviews)
                .HasForeignKey(t => t.ID_Item)
                .HasConstraintName("FK_Reviews_Items")
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Pictures
                builder.Entity<Pictures>().HasKey(t => t.ID_Picture);
                builder.Entity<Pictures>().HasOne(t => t.Items)
                .WithMany(d => d.Pictures)
                .HasForeignKey(t => t.ID_Item)
                .HasConstraintName("FK_Pictures_Items")
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Brands
                builder.Entity<Brands>().HasKey(t => t.ID_Brand);
                builder.Entity<Brands>().HasOne(t => t.Items)
                .WithOne(d => d.Brands)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }

        public DbSet<Addresses> Addresses {get; set;}
        public DbSet<Clients> Clients {get; set;}
        public DbSet<Orders> Orders {get; set;}
        public DbSet<OrderDates> OrderDates {get; set;}
        public DbSet<OrderQuantities> OrderQuantities {get; set;}
        public DbSet<Status> Status {get; set;}
        public DbSet<Reviews> Reviews {get; set;}
        public DbSet<Items> Items {get; set;}
        public DbSet<Pictures> Pictures {get; set;}
        public DbSet<Brands> Brands {get; set;}
    }
}