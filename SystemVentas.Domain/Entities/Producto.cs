using System.ComponentModel.DataAnnotations;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class Producto : SeconEntity
    {
        [Key] public int IdProducto { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdSuplidor { get; set; }
        public int? Stock { get; set; }
        public string? UrlImage { get; set; }
        public string? NombreImagen { get; set;  }
        public decimal Precio { get; set; }
    }
}
