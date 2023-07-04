using System.ComponentModel.DataAnnotations;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class TipoDocumentoVenta : SeconEntity
    {
        [Key] public int IdTipoDocumentoVenta { get; set; }
        public string? Descripcion { get; set; }
    }
}
