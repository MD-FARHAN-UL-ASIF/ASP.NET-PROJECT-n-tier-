using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RawMaterialDTO
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string supplier { get; set; }
        public int quantity { get; set; }
        public int percost { get; set; }
        public int totalcost { get; set; }
        public DateTime date { get; set; }
    }
}
