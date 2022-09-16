using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using JungleBackCore.Entities;
using System.Configuration;

namespace JungleBackInfrastructure.Data
{
    public partial class JungleBaseContext : DbContext
    {
        public JungleBaseContext()
        {
        }

        public JungleBaseContext(DbContextOptions<JungleBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<DetalleCita> DetalleCita { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<MovimientoInventario> MovimientoInventario { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoMovimientoInventario> TipoMovimientoInventario { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<UsuarioXrol> UsuarioXrol { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["JungleDatabase"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.Property(e => e.Direccion).HasColumnType("text");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.HoraFin).HasColumnName("HoraFIn");

                entity.Property(e => e.Sede)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDetalleCitaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdDetalleCita)
                    .HasConstraintName("FK_Cita_DetalleCita");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_citas_Estados");

                entity.HasOne(d => d.IdUsuarioAgendaNavigation)
                    .WithMany(p => p.CitaIdUsuarioAgendaNavigation)
                    .HasForeignKey(d => d.IdUsuarioAgenda)
                    .HasConstraintName("FK_Cita_Usuarios");

                entity.HasOne(d => d.IdUsuarioAtiendeNavigation)
                    .WithMany(p => p.CitaIdUsuarioAtiendeNavigation)
                    .HasForeignKey(d => d.IdUsuarioAtiende)
                    .HasConstraintName("FK_Cita_Usuarios1");
            });

            modelBuilder.Entity<DetalleCita>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.HasOne(d => d.IdProductosNavigation)
                    .WithMany(p => p.DetalleCita)
                    .HasForeignKey(d => d.IdProductos)
                    .HasConstraintName("FK_DetalleCita_Productos");

                entity.HasOne(d => d.IdServiciosNavigation)
                    .WithMany(p => p.DetalleCita)
                    .HasForeignKey(d => d.IdServicios)
                    .HasConstraintName("FK_DetalleCita_Servicios");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovimientoInventario>(entity =>
            {


                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.MovimientoInventario)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovimientoInventario_Inventario");

                entity.HasOne(d => d.IdProductosNavigation)
                    .WithMany(p => p.MovimientoInventario)
                    .HasForeignKey(d => d.IdProductos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovimientoInventario_Productos");

                entity.HasOne(d => d.IdTipoMovimientoInventarioNavigation)
                    .WithMany(p => p.MovimientoInventario)
                    .HasForeignKey(d => d.IdTipoMovimientoInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovimientoInventario_TipoMovimientoInventario");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK_Personas_Tip_de_documento");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RefereciaMarca)
                    .IsRequired()
                    .HasColumnName("Referecia_marca")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ValorUnitario)
                    .IsRequired()
                    .HasColumnName("Valor_unitario")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .HasConstraintName("FK_Productos_TipoProducto");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servicios>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMovimientoInventario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salida)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioXrol>(entity =>
            {
                entity.ToTable("UsuarioXRol");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuarioXrol)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_por_Rol_Roles");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioXrol)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_por_Rol_Usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Contraseña)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
