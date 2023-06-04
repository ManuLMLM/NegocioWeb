using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BaseDeDatos.Datos;

public partial class NegocioWebContext : DbContext
{
    Class1 validar = new Class1();
    public NegocioWebContext()
    {
    }

    public NegocioWebContext(DbContextOptions<NegocioWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Operacione> Operaciones { get; set; }

    public virtual DbSet<RelacionRolOperacion> RelacionRolOperacions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(("Data Source=LAPTOP-OIQBSE4M\\SQLEXPRESS; Initial Catalog="+validar.Base+"; User="+validar.Nombre+"; Password="+validar.Contra+";TrustServerCertificate=True"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.ToTable("Modulo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Operacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Operacion");

            entity.ToTable("Operacione");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Operaciones)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Operacion_Modulo1");
        });

        modelBuilder.Entity<RelacionRolOperacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RolOperacion");

            entity.ToTable("RelacionRolOperacion");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.RelacionRolOperacions)
                .HasForeignKey(d => d.IdOperacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolOperacion_Operacion1");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RelacionRolOperacions)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolOperacion_Rol");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Rol");

            entity.ToTable("Role");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
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
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
