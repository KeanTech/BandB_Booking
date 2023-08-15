using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbContract
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbUser")]
        public int UserId { get; set; }
        [ForeignKey("DbRoom")]
        public int RoomId { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        
        public DbUser ?User { get; set; }
        public DbRoom ?Room { get; set; }
    }
}
