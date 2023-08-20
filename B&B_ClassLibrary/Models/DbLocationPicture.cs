using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.Models
{
    public class DbLocationPicture
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DbLocation")]
        public int LocationId { get; set; }
        public string Base64 { get; set; }

        public ICollection<DbLocation> ?Locations { get; set; }

    }
}
