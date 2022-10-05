

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMigrations.DataModels
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RoleId")]
        public int RoleId { get; set; }
        public string UUID { get; set; }
        public string RoleName { get; set; }
        public string RoleLevel { get; set; }


    }
}
