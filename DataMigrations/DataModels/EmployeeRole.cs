

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMigrations.DataModels
{
    public class EmployeeRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EmpRoleId")]
        public int EmpRoleId { get; set; }
        public string UUID { get; set; }
        public int EmployeeID { get; set; }
        [ForeignKey("RoleID")] 
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
