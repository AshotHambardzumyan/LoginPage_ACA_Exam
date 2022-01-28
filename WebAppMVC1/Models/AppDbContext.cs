using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAppMVC1.Models;

#nullable disable

namespace WebAppMVC1.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Demo> Demos { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=Data\\sqlite.db ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demo>(entity =>
            {
                entity.ToTable("demo");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Hint).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<WebAppMVC1.Models.Account> Account { get; set; }
    }
}
