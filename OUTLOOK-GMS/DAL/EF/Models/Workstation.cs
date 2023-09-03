using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Workstation
    {
        [Key]
        public int WorkstationID { get; set; }
        public string WorkstationName { get; set; }
        public WorkstationType WorkstationType { get; set; }
        public string Supervisor { get; set; }
        public Shifts Shifts { get; set; }
        public decimal DefectRate { get; set; }
        public int ProductionVolume { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
