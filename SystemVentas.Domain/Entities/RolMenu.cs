using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class RolMenu : SeconEntity
    {
        public int IdRolMenu { get; set; }
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }
    }
}
