using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoreBiblioteca.Web.Models;

namespace SoreBiblioteca.Web.Persistence;

public partial class SoreLibraryContext : DbContext
{
    public SoreLibraryContext()
    {
    }

    public SoreLibraryContext(DbContextOptions<SoreLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SoreLibrary;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__clientes__95BA769A88433722");

            entity.ToTable("clientes");

            entity.Property(e => e.Idcliente).HasColumnName("IDcliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__empleado__333FEB98E25017D0");

            entity.ToTable("empleados");

            entity.Property(e => e.Idempleado).HasColumnName("IDempleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Puesto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("puesto");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Idlibro).HasName("PK__libros__2D1011BD3E644424");

            entity.ToTable("libros");

            entity.Property(e => e.Idlibro).HasColumnName("IDlibro");
            entity.Property(e => e.Autor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Titulo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.Idproveedor)
                .HasConstraintName("FK__libros__idprovee__4F7CD00D");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Idproveedor).HasName("PK__proveedo__2DCD485D0BEAF895");

            entity.ToTable("proveedores");

            entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
