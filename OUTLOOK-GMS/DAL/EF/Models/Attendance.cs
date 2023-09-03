using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL.EF.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        [ForeignKey("Employee")] // Establish foreign key relationship
        public int EmployeeId { get; set; }

        [JsonIgnore]
        public virtual Employee Employee { get; set; } // Navigation property

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime? ClockInTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime? ClockOutTime { get; set; }
    }
}
