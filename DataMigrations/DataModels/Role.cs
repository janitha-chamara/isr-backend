

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISRDataAccess.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RoleId")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleLevel { get; set; }


    }
}
