using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVCApplication.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermision { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupPermission> UserGroupPermissions { get; set; }
    }
}
