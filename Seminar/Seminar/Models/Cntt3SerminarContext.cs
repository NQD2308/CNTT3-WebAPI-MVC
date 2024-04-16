using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Seminar.Models;

public partial class Cntt3SerminarContext : DbContext
{
    public Cntt3SerminarContext()
    {
    }

    public Cntt3SerminarContext(DbContextOptions<Cntt3SerminarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ADMIN-GK4O6HCO7\\SQLEXPRESS;uid=sa;password=1;database=cntt3_serminar;Encrypt=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Img)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Product1)
                .HasMaxLength(100)
                .HasColumnName("product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
