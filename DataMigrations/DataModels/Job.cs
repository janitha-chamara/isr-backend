using ISRDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigrations.DataModels
{
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        public string UUID { get; set; }
        public string JobNo { get; set; }
        public string JobName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ClientName { get; set; }
        public DateTime WFMLastUpdate { get; set; }
        public string ProjectManger { get; set; }
        public string SDM { get; set; }
        public decimal QuotedHours { get; set; }
        public decimal ActualHours { get; set; }


    }
}
