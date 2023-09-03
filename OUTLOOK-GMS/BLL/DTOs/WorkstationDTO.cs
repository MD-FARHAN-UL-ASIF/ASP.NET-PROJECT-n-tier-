using DAL.EF.Models;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class WorkstationDTO
    {
        public int WorkstationID { get; set; }
        public string WorkstationName { get; set; }
        public WorkstationType WorkstationType { get; set; }
        public string Supervisor { get; set; }
        public Shifts Shifts { get; set; }
        public decimal DefectRate { get; set; }
        public int ProductionVolume { get; set; }
        public Employee Employee { get; set; }
    }
}
