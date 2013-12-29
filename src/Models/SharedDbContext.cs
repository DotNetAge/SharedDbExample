using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace SharedContextTest
{
    public class SharedDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }

        public SharedDbContext() : base("DNADB") { }

        public DbSet<Product> Products { get; set; }
    }

    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(c => c.ID).ToTable("pos_Products");
            Property(c => c.Name).HasMaxLength(50);
        }
    }
}
