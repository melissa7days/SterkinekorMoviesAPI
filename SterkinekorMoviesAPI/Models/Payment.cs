using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SterkinekorMoviesAPI.Models
{
    public class Payment
    {
        [Key]
        public int paymentId { get; set; }
        public string paymentMessage { get; set; }
        [ForeignKey("Item")]
        public int id { get; set; }
        [ForeignKey("Cart")]
        public int cartId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
