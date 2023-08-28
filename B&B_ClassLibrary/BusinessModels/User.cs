using B_B_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class User
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Country { get; set; }

        public User()
        {
            
        }
        public User(DbUser dbUser)
        {
            Id = dbUser.Id;
            Created = dbUser.Created;
            FirstName = dbUser.FirstName;
            LastName = dbUser.LastName;
            Email = dbUser.Email;
            Username = dbUser.Username;
            Password = dbUser.Password;
            PhoneNumber = dbUser.PhoneNumber;
            Country = dbUser.Country;
        }
    }
}
