using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public int WorkstationID { get; set; }
        public int OperatorID { get; set; }
        public string TaskDescription { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public TaskStatus TaskStatus { get; set; }

        // Navigation properties
        public Workstation Workstation { get; set; }
        public Employee Employee { get; set; }
    }
}
