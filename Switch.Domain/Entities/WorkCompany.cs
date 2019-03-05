using System;

namespace Switch.Domain.Entities
{
    public class WorkCompany
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string Name { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? OutDate { get; set; }
        public bool CurrentJob { get; set; }

    }
}
