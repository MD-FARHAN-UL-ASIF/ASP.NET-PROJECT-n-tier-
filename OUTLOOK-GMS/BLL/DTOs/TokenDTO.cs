using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }

        public string TokenKey { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ExpiredAt { get; set; }

    }
}
