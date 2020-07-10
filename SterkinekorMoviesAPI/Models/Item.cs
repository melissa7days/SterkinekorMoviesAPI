using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SterkinekorMoviesAPI.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Cart")]
        public int cartId { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public double itemCost { get; set; }
        public double totalCost { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
