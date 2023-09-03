using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductionPlanDTO
    {
        public int PlanID { get; set; }
        public int OrderID { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public int QuantityToProduce { get; set; }
        public string OutputProduct { get; set; }
    }
}
