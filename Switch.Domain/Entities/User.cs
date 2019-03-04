using Switch.Domain.Enums;
using System;

namespace Switch.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public ESexo Sexo { get; set; }
        public string ImageUrl { get; set; }

    }
}
