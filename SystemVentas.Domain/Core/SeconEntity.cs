using System;

namespace SystemVentas.Domain.Core
{
    public abstract class SeconEntity : BaseEntity
    {
        protected SeconEntity() 
        {
            this.FechaRegistro = DateTime.Now;
            this.Estado = false;
        }

        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }
    }
}
