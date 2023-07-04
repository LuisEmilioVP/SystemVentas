using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemVentas.Domain.Entities
{
    [Table("Configuracion")]
    public class Configuracion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Recursos { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }
    }
}
