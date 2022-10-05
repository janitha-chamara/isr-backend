using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataMigrations.DataModels
{
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ClientId")]
        public int ClientId { get; set; }
        public string UUID { get; set; }
        public string ClientName { get; set; }
     

    }
}
