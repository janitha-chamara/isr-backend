using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISRDataAccess.Models
{
    public class BusinessUnit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BusinessUnitId")]
        public int BusinessUnitId { get; set; }
        public string JobBusinessUnit { get; set; }
        public string LeadBusinessUnit { get; set; }

    }
}
