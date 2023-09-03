using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]


        [ForeignKey("Employee")] // Establish foreign key relationship
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Leave type is required.")]
        public string LeaveType { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        // Use enum for leave status
        public string Reason { get; set; }

        [Required(ErrorMessage = "Total annual leave entitlement is required.")]
        public int TotalAnnualLeaveEntitlement { get; set; }

        [Required(ErrorMessage = "Remaining leave is required.")]
        public int RemainingLeave { get; set; }

        public LeaveStatus Status { get; set; }

        [JsonIgnore]
        public virtual Employee Employee { get; set; } // Navigation property
    }
}


