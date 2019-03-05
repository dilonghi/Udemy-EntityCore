using Switch.Domain.Enums;

namespace Switch.Domain.Entities
{
    public class Identification
    {
        public int Id { get; set; }
        public ETipoDocumento TipoDocumento { get; set; }
        public string Numero { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
