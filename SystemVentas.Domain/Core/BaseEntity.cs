using System;

namespace SystemVentas.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.DateCreation = DateTime.Now;
            this.Deleted = false;
        }

        public int UserCreation { get; set; }
        public DateTime DateCreation { get; set; }
        public int? UserModify { get; set; }
        public DateTime? DateModify { get; set; }
        public int? UserDelete { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool Deleted { get; set; }
    }
}
