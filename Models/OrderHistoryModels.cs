using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReapersTest3.Models
{
    public class OrderHistoryModel
    {
        [Key]
        public int OrderId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderValue { get; set; }
        public string OrderProduct { get; set; }

    }
}