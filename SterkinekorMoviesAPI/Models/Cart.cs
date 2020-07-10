using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SterkinekorMoviesAPI.Models
{
    public class Cart
    {
        [Key]
        public int cartId { get; set; }
        public double finalTotal { get; set; }
    }
}
