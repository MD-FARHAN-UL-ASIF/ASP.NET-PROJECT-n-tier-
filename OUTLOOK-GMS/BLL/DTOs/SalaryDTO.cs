using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SalaryDTO
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } // Navigation property

        public decimal Amount { get; set; }

        public decimal Bonus { get; set; }

        public decimal Allowance { get; set; }

        public decimal Tax { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Status { get; set; }

        public decimal Net { get; set; }
    }
}
