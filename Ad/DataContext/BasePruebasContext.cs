using System;
using System.Collections.Generic;
using DTOs.CredencialesUsuarios;
using DTOs.Logs;
using DTOs.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Ad.DataContext;

public partial class BasePruebasContext : DbContext
{
    public BasePruebasContext()
    {
    }

    public BasePruebasContext(DbContextOptions<BasePruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<CredencialUsuario> Credencial { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuarios"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__EF59F762872F3FD2");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });
        modelBuilder.Entity<CredencialUsuario>(entity =>
        {
            entity.ToTable("CredencialesUsuarios"); // Nombre correcto de la tabla
            entity.HasKey(e => e.Id_usuario).HasName("PK_CredencialUsuario");  // Definir la clave primaria correctamente
            entity.Property(e => e.Username).HasColumnName("Username");
            entity.Property(e => e.Password).HasColumnName("PasswordHash");
            // Otros mapeos de propiedades
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
