using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ComerciarAxiesBackend.Models.Context
{
    public partial class AxieInfinityContext : DbContext
    {
        public AxieInfinityContext()
        {
        }

        public AxieInfinityContext(DbContextOptions<AxieInfinityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<DetalleOperacion> DetalleOperacions { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.50;Initial Catalog=AxieInfinity;User ID=sa;Password=sqlLove;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra);

                entity.ToTable("Compra");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.MontoCompraEth)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("montoCompraEth");

                entity.Property(e => e.MontoCompraUsd)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("montoCompraUsd");

                entity.Property(e => e.ValorEth)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("valorEth");
            });

            modelBuilder.Entity<DetalleOperacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.ToTable("DetalleOperacion");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

                entity.Property(e => e.ComisionMercado)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("comisionMercado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.GananciaEth)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("gananciaEth");

                entity.Property(e => e.GananciaUsd)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("gananciaUsd");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.LinkAxie)
                    .HasMaxLength(100)
                    .HasColumnName("linkAxie")
                    .IsFixedLength(true);

                entity.Property(e => e.MontoComisionOperacion)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("montoComisionOperacion");

                entity.Property(e => e.MontoComisionOperacionEth)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("montoComisionOperacionEth");

                entity.Property(e => e.ValorEth)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("valorEth");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleOperacions)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK_DetalleOperacion_Compra");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleOperacions)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK_DetalleOperacion_Ventas");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaVenta");

                entity.Property(e => e.MontoVentaEth)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("montoVentaEth");

                entity.Property(e => e.MontoVentaUsd)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("montoVentaUsd");

                entity.Property(e => e.ValorEth)
                    .HasColumnType("decimal(18, 5)")
                    .HasColumnName("valorEth");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
