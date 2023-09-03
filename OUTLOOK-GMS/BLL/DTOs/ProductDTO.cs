using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }


        public string name { get; set; }


        public int perprice { get; set; }


        public int totalprice { get; set; }


        public int quantity { get; set; }


        public DateTime date { get; set; }
    }
}
