using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class Usuario : SeconEntity
    {
        public int IdUsuario { get; set; }
        public int? IdRol { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? UrlForo { get; set; }
        public string? NombreFoto { get; set; }
        public string? Clave { get; set; }

    }
}
