using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase_sales.Models;


namespace P02_SalesDatabase_sales.Data
{
    internal class SalesSystemContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=PC-46;Initial Catalog=EFproject519-sale;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.Property(p => p.Name)
                 .HasMaxLength(50)
                 .IsUnicode(true);
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.Property(c => c.Name)
                 .HasMaxLength(100)
                 .IsUnicode(true);

                e.Property(c => c.Email)
                 .HasMaxLength(80)
                 .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(e =>
            {
                e.Property(s => s.Name)
                 .HasMaxLength(80)
                 .IsUnicode(true);
            });
            modelBuilder.Entity<Sale>(e =>
            {
                e.Property(s => s.Date)
                 .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
