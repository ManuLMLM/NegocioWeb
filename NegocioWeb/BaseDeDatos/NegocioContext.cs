using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NegocioWeb.BaseDeDatos;

public partial class NegocioContext : DbContext
{
    public NegocioContext()
    {
    }

    public NegocioContext(DbContextOptions<NegocioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Operacione> Operaciones { get; set; }

    public virtual DbSet<RelacionRolOperacion> RelacionRolOperacions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Operacione>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Operaciones)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK_Operaciones_Modulos");
        });

        modelBuilder.Entity<RelacionRolOperacion>(entity =>
        {
            entity.ToTable("RelacionRolOperacion");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.RelacionRolOperacions)
                .HasForeignKey(d => d.IdOperacion)
                .HasConstraintName("FK_RelacionRolOperacion_Operaciones");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RelacionRolOperacions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_RelacionRolOperacion_Roles");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Contraseña)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Usuario_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
