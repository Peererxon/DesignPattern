using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesingPatterns.Models;

public partial class DesignPatternsContext : DbContext
{
    public DesignPatternsContext()
    {
    }

    public DesignPatternsContext(DbContextOptions<DesignPatternsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=DesignPatterns; User Id=sa;Password=Anderson2.; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.BeerId).HasName("PK__Beer__293C94BF04CFA952");

            entity.ToTable("Beer");

            entity.Property(e => e.BeerId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Style).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
