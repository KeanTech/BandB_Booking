﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbLocation
    {
        public int Id { get; set; }
        public int LandlordId { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DbLocation()
        {
            
        }
    }
}
