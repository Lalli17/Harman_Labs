using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFDbFirstApproachDemo.Models;

public partial class EfNewTableContext : DbContext
{
    public EfNewTableContext()
    {
    }

    public EfNewTableContext(DbContextOptions<EfNewTableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EfNewTable;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07E3AD0653");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Brand)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Category)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
