using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;

public partial class SiacContext : DbContext
{
    public SiacContext()
    {
    }

    public SiacContext(DbContextOptions<SiacContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Directorio> Directorios { get; set; }

    public virtual DbSet<FieldTypeFormat> FieldTypeFormats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MAQUINA;Database=SIAC;Trusted_Connection=false;Encrypt=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Directorio>(entity =>
        {
            entity.HasKey(e => e.IdDirectorio).HasName("PK__Director__2E6038EFAA613911");

            entity.Property(e => e.IdDirectorio)
                .ValueGeneratedNever()
                .HasColumnName("ID_Directorio");
            entity.Property(e => e.IdPadre).HasColumnName("ID_Padre");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<FieldTypeFormat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FieldTypeFormat");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
