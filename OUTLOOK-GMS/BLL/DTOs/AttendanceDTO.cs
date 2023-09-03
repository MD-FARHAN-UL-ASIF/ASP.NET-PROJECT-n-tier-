using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } // Navigation property

        public DateTime Date { get; set; }

        public DateTime? ClockInTime { get; set; }

        public DateTime? ClockOutTime { get; set; }

    }
}
