using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = " Field missing.")]
        public int perprice { get; set; }

        [Required(ErrorMessage = " Field missing.")]
        public int totalprice { get; set; }

        [Required(ErrorMessage = " Field missing.")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Date and Time missing.")]
        public DateTime date { get; set; }
    }
}
