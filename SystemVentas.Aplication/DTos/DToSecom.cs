using System;

namespace SystemVentas.Application.DTos
{
    public abstract class DToSecom : DToBase
    {
        public DateTime? RegisterDateAndTime { get; set; }
        public bool? State { get; set; }
    }
}
