using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        [ForeignKey("Workstation")]
        public int WorkstationID { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public string TaskDescription { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public TaskStatus TaskStatus { get; set; }

        // Navigation properties
        public virtual Workstation Workstation { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
