using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class ProductionPlan
    {
        [Key]
        public int PlanID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public int QuantityToProduce { get; set; }
        public string OutputProduct { get; set; }
        public virtual Order Order { get; set; }
    }
}
