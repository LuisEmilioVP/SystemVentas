using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class TipoDocumentoVenta : SeconEntity
    {
        public int IdTipoDocumentoVenta { get; set; }
        public string? Descripcion { get; set; }
    }
}
