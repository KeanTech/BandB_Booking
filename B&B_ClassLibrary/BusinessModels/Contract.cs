﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class Contract
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime? SignedDate { get; set; } = DateTime.Now;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Contract()
        {
            
        }
    }
}
