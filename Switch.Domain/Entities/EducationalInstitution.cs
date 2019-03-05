using System;

namespace Switch.Domain.Entities
{
    public  class EducationalInstitution
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string NameInstitution { get; set; }
        public DateTime? GraduateYear { get; set; }
        public bool StillStudying { get; set; }

    }
}
