

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISRDataAccess.Models
{
    public class EmployeeRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EmpRoleId")]
        public int EmpRoleId { get; set; }
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }

    }
}
