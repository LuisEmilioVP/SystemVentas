using Microsoft.EntityFrameworkCore;
using SystemVentas.Domain.Entities;

namespace SystemVentas.Infrastructure.Context
{
    public class SystemVentasContext : DbContext
    {
        public SystemVentasContext()
        {
        }

        public SystemVentasContext(DbContextOptions<SystemVentasContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; } = null!;
        public DbSet<Configuracion> Configuracion { get; set; } = null!;
        public DbSet<DetalleVenta> DetalleVenta { get; set; } = null!;
        public DbSet<Menu> Menu { get; set; } = null!;
        public DbSet<Negocio> Negocio { get; set; } = null!;
        public DbSet<NumeroCorrelativo> NumeroCorrelativo { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Rol> Rol { get; set; } = null!;
        public DbSet<RolMenu> RolMenu { get; set; } = null!;
        public DbSet<Suplidor> Suplidor { get; set; } = null!;
        public DbSet<TipoDocumentoVenta> TipoDocumentoVenta { get; set; } = null!;
        public DbSet<Usuario> Usuario { get; set; } = null!;
        public DbSet<Venta> Venta { get; set; } = null!;
    }
}
