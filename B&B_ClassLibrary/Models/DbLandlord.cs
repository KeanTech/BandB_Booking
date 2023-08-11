using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbLandlord:DbUser
    {
        public string CPRNumber { get; set; }
        public string AccountNumber { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
