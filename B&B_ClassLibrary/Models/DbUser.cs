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
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }

        public DbUser()
        {
            
        }

        public DbUser(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Country = user.Country;
            Username = user.Username;
            PhoneNumber = user.PhoneNumber;
            Created = user.Created; 
        }

        public DbUser(Landlord landlord)
        {
            Id = landlord.UserId;
            FirstName = landlord.FirstName;
            LastName= landlord.LastName;
            Email = landlord.Email;
            Country = landlord.Country;
            Username= landlord.Username;
            PhoneNumber = landlord.PhoneNumber;
            Created = landlord.Created;
        }

        public virtual ICollection<DbContract> ?Contracts { get; set; }
        public DbLandlord ?Landlord { get; set; }
    }
}