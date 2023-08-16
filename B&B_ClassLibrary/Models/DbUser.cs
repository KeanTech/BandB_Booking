using System.ComponentModel.DataAnnotations;
using B_B_ClassLibrary.BusinessModels;

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

        public DbUser(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Country = user.Country;
            Password = user.Password;
            PhoneNumber = user.PhoneNumber;
            Created = user.Created; 
        }

        public ICollection<DbContract> ?Contracts { get; set; }
        public DbLandlord ?Landlord { get; set; }
    }
}