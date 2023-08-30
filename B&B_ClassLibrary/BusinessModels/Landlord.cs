using B_B_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class Landlord:User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CPRNumber { get; set; }
        public string AccountNumber { get; set; }
        public string RegistrationNumber { get; set; }

        public Landlord()
        {
            
        }

        public Landlord(DbLandlord landlord)
        {
            Id = landlord.Id;
            UserId = landlord.UserId;
            CPRNumber = landlord.CPRNumber;
            AccountNumber = landlord.AccountNumber;
            RegistrationNumber = landlord.RegistrationNumber;
        }

        public Landlord( User user, Landlord landlord) : base(user)
        {
            CPRNumber = landlord.CPRNumber;
            AccountNumber = landlord.AccountNumber;
            RegistrationNumber = landlord.RegistrationNumber;
        }
    }
}
