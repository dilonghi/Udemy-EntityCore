﻿using Switch.CrossCutting.Shared.Enums;
using System;

namespace Switch.Appilcation.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public ESexo Sexo { get; set; }
        public string ImageUrl { get; set; }
    }
}
