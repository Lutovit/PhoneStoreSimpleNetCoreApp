using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
