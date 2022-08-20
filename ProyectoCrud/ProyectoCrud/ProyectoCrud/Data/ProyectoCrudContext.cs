using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoCrud.Models;

namespace ProyectoCrud.Data
{
    public partial class ProyectoCrudContext : DbContext
    {
        public ProyectoCrudContext()
        {
        }

        public ProyectoCrudContext(DbContextOptions<ProyectoCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detalleventum> Detalleventa { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cliente1)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(12);
            });

            modelBuilder.Entity<Detalleventum>(entity =>
            {
                entity.ToTable("detalleventa");

                entity.HasIndex(e => e.IdProducto, "FK_DETALLEVENTA_PRODUCTO");

                entity.HasIndex(e => e.IdVenta, "FK_DETALLEVENTA_VENTA");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Producto");

                entity.Property(e => e.IdVenta)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Venta");

                entity.Property(e => e.PrecioTotal).HasPrecision(8, 2);

                entity.Property(e => e.PrecioUnitario).HasPrecision(8, 2);

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLEVENTA_PRODUCTO");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLEVENTA_VENTA");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoria).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Precio)
                    .HasPrecision(8, 2)
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("ventas");

                entity.HasIndex(e => e.IdCliente, "FK_CLIENTES_VENTAS");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Cliente");

                entity.Property(e => e.Total)
                    .HasPrecision(8, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTES_VENTAS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
