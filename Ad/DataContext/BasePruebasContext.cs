using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using DTOs.Auditoria;
using DTOs.Cliente;
using DTOs.CredencialesUsuarios;
using DTOs.Deudas;
using DTOs.HistorialDeudas;
using DTOs.HistorialProductos;
using DTOs.Logs;
using DTOs.Persona;
using DTOs.Producto;
using DTOs.Proveedor;
using DTOs.Stock;
using DTOs.Usuarios;
using DTOs.Movimientos;
using DTOs.Categoria;
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
    public virtual DbSet<PersonaDTO> Persona{ get; set; }
    public virtual DbSet<ProveedorDTO> Proveedor { get; set; }
    public virtual DbSet<ProductoDTO> Producto { get; set; }

    public virtual DbSet<StockDTO> Stock { get; set; }

    public virtual DbSet<MovimientosDTO> Movimiento { get; set; }
    public virtual DbSet<HistorialProductosDTO> HistorialProductos { get; set; }

    public virtual DbSet<AuditoriaDTO> Auditoria { get; set; }

    public virtual DbSet<ClienteDTO> Cliente { get; set; }

    public virtual DbSet<DeudasDTO> Deudas { get; set; }

    public virtual DbSet<CategoriaDTO> Categoria { get; set; }
    public virtual DbSet<HistorialDeudasDTO> HistorialDeudas { get; set; }

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
        modelBuilder.Entity<PersonaDTO>(entity =>
        {
            entity.ToTable("PERSONA"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdPersona).HasName("PK_Id_persona");  // Definir la clave primaria correctamente
            entity.Property(e => e.Nombre).HasColumnName("Nombre");
            entity.Property(e => e.DNI).HasColumnName("DNI");
            entity.Property(e => e.Telefono).HasColumnName("Telefono");
            entity.Property(e => e.Mail).HasColumnName("Mail");
            // Otros mapeos de propiedades
        });
        modelBuilder.Entity<ProveedorDTO>(entity =>
        {
            entity.ToTable("PROVEEDOR"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdProveedor).HasName("PK__PROVEEDO__6704E5A88ECCE312");  // Definir la clave primaria correctamente
            entity.Property(e => e.IdProveedor).HasColumnName("Id_proveedor"); // Map
            entity.Property(e => e.NombreEmpresa).HasColumnName("NombreEmpresa");
            entity.Property(e => e.DiasVisita).HasColumnName("DiasVisita");
            entity.Property(e => e.TipoProducto).HasColumnName("TipoProducto");
            entity.Property(e => e.Estado).HasColumnName("Estado");
            // Otros mapeos de propiedades
        });
        modelBuilder.Entity<ProductoDTO>(entity =>
        {
            entity.ToTable("PRODUCTO"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__1D8EFF0143E5F3AC");  // Definir la clave primaria correctamente
            entity.Property(e => e.IdProducto).HasColumnName("Id_producto"); // Map
            entity.Property(e => e.ProveedorId).HasColumnName("Proveedor_id");
            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_id");
            entity.Property(e => e.Nombre).HasColumnName("Nombre");

            //// Configurar relación con Proveedor (FK)
            //entity.HasOne(p => p.Proveedor) // Relación uno a uno o uno a muchos
            //      .WithMany()
            //      .HasForeignKey(p => p.ProveedorId)
            //      .HasConstraintName("FK__PROVEEDO__6704E5A88ECCE312"); // Nombre de la FK en la base de datos

            // Configurar relación con Categoria (FK)
            //entity.HasOne(p => p.Categoria) // Relación uno a uno o uno a muchos
            //      .WithMany()
            //      .HasForeignKey(p => p.Categoria)
            //      .HasConstraintName("FK__CATEGORI__4A033A9350BC54B5"); // Nombre de la FK en la base de datos

        });
        modelBuilder.Entity<StockDTO>(entity =>
        {
            entity.ToTable("STOCK"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdStock).HasName("PK__STOCK__89C929190FCCB1A0");  // Definir la clave primaria correctamente
            entity.Property(e => e.IdStock).HasColumnName("Id_stock"); // Map
            entity.Property(e => e.ProductoId).HasColumnName("Producto_id");
            entity.Property(e => e.CantidadActual).HasColumnName("CantidadActual");
            entity.Property(e => e.FechaUltimaActualizacion).HasColumnName("FechaUltimaActualizacion");
            // Configurar relación con Producto (FK)
            //entity.HasOne(p => p.Producto) // Relación uno a uno o uno a muchos
            //      .WithMany()
            //      .HasForeignKey(p => p.Producto)
            //      .HasConstraintName("FK__STOCK__Producto___7F2BE32F"); // Nombre de la FK en la base de datos

        });
        modelBuilder.Entity<MovimientosDTO>(entity =>
        {
            entity.ToTable("MOVIMIENTOS"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdVenta).HasName("PK__MOVIMIEN__F077E880A6E0CF35");  // Definir la clave primaria correctamente 
            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.StockId).HasColumnName("Stock_id");
            entity.Property(e => e.Fecha).HasColumnName("Fecha");
            entity.Property(e => e.Cantidad).HasColumnName("Cantidad");
            entity.Property(e => e.TipoMovimiento).HasColumnName("TipoMovimiento");
            entity.Property(e => e.Descripcion).HasColumnName("Descripcion");
            entity.Property(e => e.Vendedor).HasColumnName("Vendedor");
            entity.Property(e => e.Cliente).HasColumnName("Cliente");

            // Otros mapeos de propiedades
        });
        modelBuilder.Entity<HistorialProductosDTO>(entity =>
        {
            entity.ToTable("HISTORIALPRODUCTOS"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdHistorial).HasName("PK__HISTORIA__EA5F513B60A3E306");  // Definir la clave primaria correctamente
            entity.Property(e => e.IdHistorial).HasColumnName("Id_historial");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_id");
            entity.Property(e => e.FechaCambio).HasColumnName("FechaCambio");
            entity.Property(e => e.PrecioUnitario).HasColumnName("PrecioUnitario");
            entity.Property(e => e.PorcentajeGanancia).HasColumnName("PorcentajeGanancia");
            entity.Property(e => e.PrecioAnterior).HasColumnName("PrecioAnterior");
            entity.Property(e => e.PrecioActual).HasColumnName("PrecioActual");
            entity.Property(e => e.PrecioPublico).HasColumnName("PrecioPublico");

            // Otros mapeos de propiedades
        });

        modelBuilder.Entity<AuditoriaDTO>(entity =>
        {
            entity.ToTable("Auditoria"); // Nombre correcto de la tabla
            entity.HasKey(e => e.idAuditoria).HasName("PK__Auditori__835B9D14687A898C");  // Definir la clave primaria correctamente
            entity.Property(e => e.idAuditoria).HasColumnName("Id_auditoria");
            entity.Property(e => e.IdEntidad).HasColumnName("IdEntidad");
            entity.Property(e => e.Usuario).HasColumnName("Usuario");
            entity.Property(e => e.Fecha).HasColumnName("Fecha");
            entity.Property(e => e.Operacion).HasColumnName("Operacion");
            entity.Property(e => e.EntidadModificada).HasColumnName("EntidadMoficada");

            // Otros mapeos de propiedades
        });


        modelBuilder.Entity<ClienteDTO>(entity =>
        {
            entity.ToTable("CLIENTE"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTE__FCE03992F12E2D1A");  // Definir la clave primaria correctamente
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.PersonaId).HasColumnName("Persona_id");
            entity.Property(e => e.UltimaCompra).HasColumnName("UltimaCompra");
            entity.Property(e => e.HistorialCompras).HasColumnName("HistorialCompras");
            entity.Property(e => e.Saldo).HasColumnName("Saldo");

            // Otros mapeos de propiedades
        });
        modelBuilder.Entity<DeudasDTO>(entity =>
        {
            entity.ToTable("DEUDAS"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdDeuda).HasName("PK__DEUDAS__F11EBF6AAB6BDB90");  // Definir la clave primaria correctamente
            entity.Property(e => e.IdDeuda).HasColumnName("Id_deuda");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_id");
            entity.Property(e => e.PersonaId).HasColumnName("Persona_id");
            entity.Property(e => e.Monto).HasColumnName("Monto");
            entity.Property(e => e.Fecha).HasColumnName("Fecha");
            entity.Property(e => e.Estado).HasColumnName("Estado");
            entity.Property(e => e.TipoDeuda).HasColumnName("TipoDeuda");

            // Otros mapeos de propiedades
        });
        modelBuilder.Entity<CategoriaDTO>(entity =>
        {
            entity.ToTable("CATEGORIA"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdCategoria).HasName("PK_Id_categoria");  // Definir la clave primaria correctamente
            entity.Property(e => e.Nombre).HasColumnName("Nombre");
            

            // Otros mapeos de propiedades
        });
        modelBuilder.Entity<HistorialDeudasDTO>(entity =>
        {
            entity.ToTable("HISTORIALDEUDAS"); // Nombre correcto de la tabla
            entity.HasKey(e => e.IdHistorialDeuda).HasName("PK_Id_historial");  // Definir la clave primaria correctamente
            entity.Property(e => e.DeudaId).HasColumnName("Deuda_id");

            // Otros mapeos de propiedades
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
