using System.ComponentModel.DataAnnotations;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class RolMenu : SeconEntity
    {
        [Key] public int IdRolMenu { get; set; }
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }
    }
}
