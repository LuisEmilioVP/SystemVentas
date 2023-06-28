using System;
using SystemVentas.Domain.Core;

namespace SystemVentas.Domain.Entities
{
    public class Venta : BaseEntity
    {
        public int IdVentas { get; set; }
        public string? NumeroVenta { get; set; }
        public int? IdTipoDocumentoVenta { get; set; }
        public int? IdUsuario { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotla { get; set; }
        public decimal? Impuestos { get; set; }
        public decimal? Todal { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
