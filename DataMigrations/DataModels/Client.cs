using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ISRDataAccess.Models
{
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ClientId")]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public bool IsProspect { get; set; }

    }
}
