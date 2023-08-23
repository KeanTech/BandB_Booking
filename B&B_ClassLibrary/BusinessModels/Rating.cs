using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class Rating
    {
        public int Id { get; set; }
        //TypeId is either a LocationId or RoomId
        public int TypeId { get; set; }
        public double? Value { get; set; }
    }
}
