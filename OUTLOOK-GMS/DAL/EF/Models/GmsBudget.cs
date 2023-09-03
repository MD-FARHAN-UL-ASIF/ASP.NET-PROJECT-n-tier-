using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class GmsBudget
    {
        public int Id { get; set; }

        public decimal BudgetAmount { get; set; }

        public DateTime StartDate { get; set; }    // Budget period start date
        public DateTime EndDate { get; set; }      // Budget period end date

        //active status 
        public string Status { get; set; }

        public decimal SalaryPercentage { get; set; }

        public decimal ProductionPercentage { get; set; }

        public decimal OtherExpensesPercentage { get; set; }

        //remaining budget
        public decimal RemainingAmount { get; set; }

        public decimal SalaryAllocation { get; set; }

        public decimal ProductionAllocation { get; set; }

        public decimal OtherExpensesAllocation { get; set; }

        public decimal RemainingBudget { get; set; }
    }
}
