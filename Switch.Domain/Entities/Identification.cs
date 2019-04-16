using Switch.Domain.Core.Entities;
using System;

namespace Switch.Domain.Entities
{
    public class Identification : Entity
    {
        //public ETipoDocumento TipoDocumento { get; set; }
        public string Numero { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
