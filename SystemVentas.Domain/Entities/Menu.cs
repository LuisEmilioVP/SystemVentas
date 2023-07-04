using System.ComponentModel.DataAnnotations;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class Menu : SeconEntity
    {
        [Key] public int IdMenu { get; set; }
        public string? Descripcion { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
    }
}
