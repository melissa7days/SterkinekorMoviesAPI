using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SterkinekorMoviesAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public int orderId { get; set; }
        [ForeignKey("Payment")]
        public int paymentId { get; set; }
        [ForeignKey("Cart")]
        public int cartId { get; set; }
        [ForeignKey("Item")]
        public int id { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Item Item { get; set; }

    }
}
