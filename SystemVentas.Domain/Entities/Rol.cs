
using System.ComponentModel.DataAnnotations;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class Rol : SeconEntity
    {
        [Key] public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }
}
