using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class NumeroCorrelativo : BaseEntity
    {
        public int IdNumeroCorrelativo { get; set; }
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion { get; set; }
    }
}
