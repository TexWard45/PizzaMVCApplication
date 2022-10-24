using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Size = PizzaMVCApplication.Entity.Size;

namespace PizzaMVCApplication.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermisions { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupPermission> UserGroupPermissions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Base> Bases { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaDetail> PizzaDetails { get; set; }
        public DbSet<ToppingDetail> ToppingDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<StatusDetail> StatusDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusDetail>().HasKey(u => new
            {
                u.OrderId,
                u.StatusId
            });

            modelBuilder.Entity<ToppingDetail>().HasKey(u => new
            {
                u.PizzaId,
                u.ToppingId
            });

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Customer)
                .WithMany(z => z.CustomerOrders)
                .HasForeignKey(x => x.CustomerUsername)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Handler)
                .WithMany(z => z.HandlerOrders)
                .HasForeignKey(x => x.HandlerUsername)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
