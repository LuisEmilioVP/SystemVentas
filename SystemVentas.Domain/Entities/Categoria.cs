using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class Categoria : SeconEntity
    {
        public int IdCategoria { get; set; }
        public string?Descripcion { get; set; }
    }
}
