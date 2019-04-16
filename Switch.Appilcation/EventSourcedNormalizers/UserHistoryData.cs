using System;

namespace Switch.Appilcation.EventSourcedNormalizers
{
    public class UserHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Birthdate { get; set; }
        //public ESexo Sexo { get; set; }
        public string ImageUrl { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
