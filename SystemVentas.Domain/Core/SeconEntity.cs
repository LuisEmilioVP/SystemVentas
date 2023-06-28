using System;

namespace SystemVentas.Domain.Core
{
    public abstract class SeconEntity : BaseEntity
    {
        public SeconEntity()
        {
            this.Estado = false;
            this.FechaRegistro = DateTime.Now;
        }

        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
