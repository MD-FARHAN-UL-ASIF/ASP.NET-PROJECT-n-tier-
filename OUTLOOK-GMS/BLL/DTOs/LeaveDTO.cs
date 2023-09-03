using DAL.EF.Models;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LeaveDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public int TotalAnnualLeaveEntitlement { get; set; }
        public int RemainingLeave { get; set; }
        public LeaveStatus Status { get; set; }
        public Employee Employee { get; set; } // Navigation property

    }
}

