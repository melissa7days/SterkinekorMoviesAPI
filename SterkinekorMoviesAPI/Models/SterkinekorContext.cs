using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterkinekorMoviesAPI.Models
{
    public class SterkinekorContext : DbContext
    {
        public SterkinekorContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Item> Item { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<PaymentViewModel> PaymentViewModels { get; set; }
        public DbSet<OrderViewModel> OrderViewModels { get; set; }
    }
}
