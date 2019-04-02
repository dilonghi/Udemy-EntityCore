﻿using Switch.Domain.Core.Entities;
using Switch.Domain.Enums;
using Switch.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Switch.Domain.Entities
{
    public class User : Entity
    {
        public User(Name name, Email email, string mobile, string password, DateTime birthdate, ESexo sexo, string imagem)
        {
            Name = name;
            Email = email;
            Mobile = mobile;
            Password = password;
            Birthdate = birthdate;
            Sexo = sexo;
            ImageUrl = imagem;

            Posts = new List<Post>();
            UserGroups = new List<UserGroup>();
            WorkCompanies = new List<WorkCompany>();
            EducationalInstitutions = new List<EducationalInstitution>();
            Friends = new List<Friend>();
            Comments = new List<Comment>();
        }

        protected User()
        {

        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Mobile { get; private set; }
        public string Password { get; private set; }
        public DateTime Birthdate { get; private set; }
        public ESexo Sexo { get; private set; }
        public string ImageUrl { get; private set; }

        public virtual Identification Identification { get; set; }
        public virtual RelationshipStatus RelationshipStatus { get; set; }
        public virtual SearchFor SearchFor { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<WorkCompany> WorkCompanies { get; set; }
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        

    }
}
