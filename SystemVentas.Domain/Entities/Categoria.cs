
using System.ComponentModel.DataAnnotations;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class Categoria : SeconEntity
    {
        [Key] public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
