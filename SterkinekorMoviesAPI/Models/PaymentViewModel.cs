using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SterkinekorMoviesAPI.Models
{
    public class PaymentViewModel
    {
        [Key]
        public int paymentId { get; set; }
        public string paymentMessage { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public double itemCost { get; set; }
        public int quantity { get; set; }
        public double totalCost { get; set; }
        public int cartId { get; set; }
        public double finalTotal { get; set; }
    }
}
