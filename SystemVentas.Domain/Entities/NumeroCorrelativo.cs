using System.ComponentModel.DataAnnotations;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class NumeroCorrelativo : BaseEntity
    {
        [Key] public int IdNumeroCorrelativo { get; set; }
        public string? UltimoNumero { get; set; }
        public string? CantidadDigitos { get; set; }
        public string? Gestion { get; set; }
    }
}
