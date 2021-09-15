using Microsoft.EntityFrameworkCore;
using PECargo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PECargo
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Oders { get; set; }
    }
}
