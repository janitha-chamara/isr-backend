using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigrations.Migrations
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int EmployeeId { get; set; }
        public string UUID { get; set; }
        public string FirstName { get; set; }
        public string EmployeeType { get; set; }



    }
}
