using Switch.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Switch.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public ESexo Sexo { get; set; }
        public string ImageUrl { get; set; }

        public virtual Identification Identification { get; set; }
        public virtual RelationshipStatus RelationshipStatus { get; set; }
        public virtual SearchFor SearchFor { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<WorkCompany> WorkCompanies { get; set; }
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public User()
        {
            Posts = new List<Post>();
            UserGroups = new List<UserGroup>();
            WorkCompanies = new List<WorkCompany>();
            EducationalInstitutions = new List<EducationalInstitution>();
            Friends = new List<Friend>();
            Comments = new List<Comment>();
        }

    }
}
