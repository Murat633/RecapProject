using RecapProject1.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace RecapProject1
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}