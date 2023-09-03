using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Salary
    {
        public int Id { get; set; }

        [ForeignKey("Employee")] // Establish foreign key relationship
        public int EmployeeId { get; set; }

        [JsonIgnore]
        public virtual Employee Employee { get; set; } // Navigation property


        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        public decimal Bonus { get; set; }


        public decimal Allowance { get; set; }


        [Required]
        public decimal Tax { get; set; }


        [Required(ErrorMessage = "Date is required")]
        public DateTime PaymentDate { get; set; }


        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public decimal Net { get; set; }

    }
}
