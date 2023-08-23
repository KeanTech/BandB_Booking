using B_B_ClassLibrary.BusinessModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbLandlord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DbUser")]
        public int UserId { get; set; }
        public string AccountNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string CPRNumber { get; set; }

        public DbLandlord()
        {
            
        }

        public DbLandlord(Landlord landlord)
        {
            Id = landlord.Id;
            UserId = landlord.UserId;
            AccountNumber = landlord.AccountNumber;
            RegistrationNumber = landlord.RegistrationNumber;
            CPRNumber = landlord.CPRNumber;
        }

        public DbUser ?User { get; set; }
        public virtual ICollection<DbLocation> ?Locations { get; set; }
    }
}
