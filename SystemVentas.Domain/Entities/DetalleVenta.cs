using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class DetalleVenta : BaseEntity
    {
        public int IdDetalleVenta { get; set; }
        public int? IdVentas { get; set; }
        public int? IdProducto { get; set; }
        public string? MarcaProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public string? CategoriaProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
