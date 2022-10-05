using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRDataAccess.Models
{
    public class LookUp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LookupId")]
        public int LookupId { get; set; }
        public string LookupName { get; set; }
        public string LookupValue { get; set; }

    }
}
