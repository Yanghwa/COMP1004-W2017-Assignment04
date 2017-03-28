namespace DollarComputers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ComputersContext : DbContext
    {
        public ComputersContext()
            : base("name=ComputersContextConnection")
        {
        }

        public virtual DbSet<Product> products { get; set; } //Table in the DB

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.cost)
                .HasPrecision(19, 4);
        }
    }
}
