﻿using System.ComponentModel.DataAnnotations;

namespace B_B_ClassLibrary.Models
{
    public class DbUser
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }

        public DbLandlord ?Landlord { get; set; }
    }
}